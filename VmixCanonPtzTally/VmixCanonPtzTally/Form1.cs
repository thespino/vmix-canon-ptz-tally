using System.Net;
using System.Net.Sockets;
using System.Text;

namespace VmixCanonPtzTally
{
    public partial class Form1 : Form
    {
        private bool _isRunning = false;
        private TcpClient? _vmixTcpClient;
        private Thread? _listenerThread;
        private int? _currentActiveInput = null;
        private readonly object _lockObject = new object();
        private CancellationTokenSource? _cancellationTokenSource;
        private string? _currentFilePath = null;
        private bool _hasUnsavedChanges = false;

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set default values
            txtVmixIp.Text = "127.0.0.1";
            txtVmixPort.Text = "8099";
            lblVmixStatus.Text = "Not connected";
            lblVmixStatus.ForeColor = Color.Gray;
            lblCamerasStatus.Text = "Not configured";
            lblCamerasStatus.ForeColor = Color.Gray;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Try to load last file
            var lastFile = SettingsManager.GetLastFile();
            if (lastFile != null)
            {
                try
                {
                    LoadSettingsFromFile(lastFile);
                }
                catch
                {
                    // Ignore error, use defaults
                }
            }

            UpdateTitle();
        }

        private void Settings_Changed(object? sender, EventArgs e)
        {
            if (_isRunning) return; // Don't mark as changed while running
            _hasUnsavedChanges = true;
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            string title = "Vmix Canon PTZ Tally";
            if (_currentFilePath != null)
            {
                title += $" - {Path.GetFileName(_currentFilePath)}";
            }
            else
            {
                title += " - Untitled";
            }
            if (_hasUnsavedChanges)
            {
                title += " *";
            }
            this.Text = title;
        }

        #region vMix Connection Testing

        private async void TxtVmix_Leave(object? sender, EventArgs e)
        {
            if (_isRunning) return; // Don't test while running
            await TestVmixConnection();
        }

        private async Task<bool> TestVmixConnection()
        {
            if (string.IsNullOrWhiteSpace(txtVmixIp.Text) || string.IsNullOrWhiteSpace(txtVmixPort.Text))
            {
                UpdateVmixStatus("Configuration incomplete", Color.Orange);
                return false;
            }

            if (!int.TryParse(txtVmixPort.Text, out int port))
            {
                UpdateVmixStatus("Invalid port", Color.Red);
                return false;
            }

            UpdateVmixStatus("Testing...", Color.Orange);

            try
            {
                using var testClient = new TcpClient();
                var connectTask = testClient.ConnectAsync(txtVmixIp.Text, port);

                if (await Task.WhenAny(connectTask, Task.Delay(2000)) == connectTask && testClient.Connected)
                {
                    UpdateVmixStatus("Connected", Color.Green);
                    return true;
                }
                else
                {
                    UpdateVmixStatus("Connection timeout", Color.Red);
                    return false;
                }
            }
            catch (Exception ex)
            {
                UpdateVmixStatus($"Error: {ex.Message}", Color.Red);
                return false;
            }
        }

        private void UpdateVmixStatus(string message, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateVmixStatus(message, color));
                return;
            }
            lblVmixStatus.Text = message;
            lblVmixStatus.ForeColor = color;
        }

        #endregion

        #region Camera Connection Testing

        private async void DgvCameras_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (_isRunning) return;
            if (e.RowIndex >= 0)
            {
                await TestCameraConnection(e.RowIndex);
            }
        }

        private async void DgvCameras_RowValidated(object? sender, DataGridViewCellEventArgs e)
        {
            if (_isRunning) return;
            if (e.RowIndex >= 0)
            {
                await TestCameraConnection(e.RowIndex);
            }
        }

        private async Task TestCameraConnection(int rowIndex)
        {
            var row = dgvCameras.Rows[rowIndex];

            // Skip if row is incomplete
            if (row.Cells[colCameraNum.Index].Value == null ||
                row.Cells[colCameraIp.Index].Value == null)
            {
                UpdateCamerasStatus();
                return;
            }

            string? ip = row.Cells[colCameraIp.Index].Value?.ToString();
            if (string.IsNullOrWhiteSpace(ip))
            {
                row.Cells[colStatus.Index].Value = "No IP";
                UpdateCamerasStatus();
                return;
            }

            row.Cells[colStatus.Index].Value = "Testing...";
            UpdateCamerasStatus();

            try
            {
                string username = row.Cells[colCameraUsername.Index].Value?.ToString() ?? "";
                string password = row.Cells[colCameraPassword.Index].Value?.ToString() ?? "";

                HttpResponseMessage response;
                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    // Use authentication if credentials are provided
                    var handler = new HttpClientHandler
                    {
                        Credentials = new NetworkCredential(username, password),
                        PreAuthenticate = true
                    };
                    using var client = new HttpClient(handler);
                    client.Timeout = TimeSpan.FromSeconds(2);
                    response = await client.GetAsync($"http://{ip}/-wvhttp-01-/control.cgi");
                }
                else
                {
                    // No authentication if credentials are not specified
                    using var client = new HttpClient();
                    client.Timeout = TimeSpan.FromSeconds(2);
                    response = await client.GetAsync($"http://{ip}/-wvhttp-01-/control.cgi");
                }

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    row.Cells[colStatus.Index].Value = "Connected";
                }
                else
                {
                    row.Cells[colStatus.Index].Value = $"HTTP {(int)response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                row.Cells[colStatus.Index].Value = $"Error: {ex.Message.Substring(0, Math.Min(20, ex.Message.Length))}";
            }

            UpdateCamerasStatus();
        }

        private void UpdateCamerasStatus()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateCamerasStatus);
                return;
            }

            int total = 0;
            int connected = 0;
            int errors = 0;

            foreach (DataGridViewRow row in dgvCameras.Rows)
            {
                if (row.IsNewRow) continue;

                var status = row.Cells[colStatus.Index].Value?.ToString() ?? "";
                if (status.Contains("Connected"))
                {
                    connected++;
                    total++;
                }
                else if (status.Contains("Error") || status.Contains("HTTP") || status.Contains("timeout"))
                {
                    errors++;
                    total++;
                }
                else if (!string.IsNullOrEmpty(status) && status != "Not tested")
                {
                    total++;
                }
            }

            if (total == 0)
            {
                lblCamerasStatus.Text = "Not configured";
                lblCamerasStatus.ForeColor = Color.Gray;
            }
            else if (connected == total)
            {
                lblCamerasStatus.Text = $"All {total} cameras OK";
                lblCamerasStatus.ForeColor = Color.Green;
            }
            else if (errors > 0)
            {
                lblCamerasStatus.Text = $"{connected}/{total} cameras OK";
                lblCamerasStatus.ForeColor = Color.Red;
            }
            else
            {
                lblCamerasStatus.Text = $"{connected}/{total} cameras OK";
                lblCamerasStatus.ForeColor = Color.Orange;
            }
        }

        #endregion

        #region Camera Tally Control

        private async Task<bool> SetCameraTally(string cameraIp, string username, string password, bool state)
        {
            try
            {
                string url;
                if (state)
                {
                    // Turn on RED tally for on-air
                    url = $"http://{cameraIp}/-wvhttp-01-/control.cgi?tally=on&tally.mode=program";
                }
                else
                {
                    // Turn off tally
                    url = $"http://{cameraIp}/-wvhttp-01-/control.cgi?tally=off";
                }

                HttpResponseMessage response;
                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    // Use authentication if credentials are provided
                    var handler = new HttpClientHandler
                    {
                        Credentials = new NetworkCredential(username, password),
                        PreAuthenticate = true
                    };
                    using var client = new HttpClient(handler);
                    client.Timeout = TimeSpan.FromSeconds(1);
                    response = await client.GetAsync(url);
                }
                else
                {
                    // No authentication if credentials are not specified
                    using var client = new HttpClient();
                    client.Timeout = TimeSpan.FromSeconds(1);
                    response = await client.GetAsync(url);
                }

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                LogMessage($"Error controlling camera {cameraIp}: {ex.Message}");
                return false;
            }
        }

        private async Task UpdateTallyLights(int? activeInput)
        {
            if (activeInput == _currentActiveInput)
                return;

            // Turn off previous camera's tally
            if (_currentActiveInput.HasValue)
            {
                var prevRow = FindCameraRow(_currentActiveInput.Value);
                if (prevRow != null)
                {
                    string ip = prevRow.Cells[colCameraIp.Index].Value?.ToString() ?? "";
                    string username = prevRow.Cells[colCameraUsername.Index].Value?.ToString() ?? "";
                    string password = prevRow.Cells[colCameraPassword.Index].Value?.ToString() ?? "";

                    if (await SetCameraTally(ip, username, password, false))
                    {
                        UpdateCameraOnAirStatus(_currentActiveInput.Value, false);
                        LogMessage($"Camera {_currentActiveInput.Value} ({ip}): Tally OFF");
                    }
                }
            }

            // Turn on new camera's tally
            if (activeInput.HasValue)
            {
                var row = FindCameraRow(activeInput.Value);
                if (row != null)
                {
                    string ip = row.Cells[colCameraIp.Index].Value?.ToString() ?? "";
                    string username = row.Cells[colCameraUsername.Index].Value?.ToString() ?? "";
                    string password = row.Cells[colCameraPassword.Index].Value?.ToString() ?? "";

                    if (await SetCameraTally(ip, username, password, true))
                    {
                        UpdateCameraOnAirStatus(activeInput.Value, true);
                        LogMessage($"Camera {activeInput.Value} ({ip}): Tally ON (RED)");
                    }
                }
                else
                {
                    LogMessage($"Active input {activeInput.Value} is not a configured camera");
                }
            }

            _currentActiveInput = activeInput;
        }

        private DataGridViewRow? FindCameraRow(int cameraNumber)
        {
            foreach (DataGridViewRow row in dgvCameras.Rows)
            {
                if (row.IsNewRow) continue;

                var numValue = row.Cells[colCameraNum.Index].Value;
                if (numValue != null && int.TryParse(numValue.ToString(), out int num) && num == cameraNumber)
                {
                    return row;
                }
            }
            return null;
        }

        private void UpdateCameraOnAirStatus(int cameraNumber, bool onAir)
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateCameraOnAirStatus(cameraNumber, onAir));
                return;
            }

            var row = FindCameraRow(cameraNumber);
            if (row != null)
            {
                row.Cells[colOnAir.Index].Value = onAir;
            }
        }

        #endregion

        #region vMix TCP Listener

        private async void StartListener()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            LogMessage("Starting vMix TCP listener...");

            while (_isRunning && !token.IsCancellationRequested)
            {
                try
                {
                    if (!int.TryParse(txtVmixPort.Text, out int port))
                    {
                        LogMessage("Invalid vMix port");
                        await Task.Delay(5000, token);
                        continue;
                    }

                    _vmixTcpClient = new TcpClient();
                    await _vmixTcpClient.ConnectAsync(txtVmixIp.Text, port);

                    UpdateVmixStatus("Connected", Color.Green);
                    LogMessage($"Connected to vMix at {txtVmixIp.Text}:{port}");

                    var stream = _vmixTcpClient.GetStream();

                    // Subscribe to TALLY events
                    byte[] subscribeCommand = Encoding.UTF8.GetBytes("SUBSCRIBE TALLY\r\n");
                    await stream.WriteAsync(subscribeCommand, token);

                    // Read responses
                    var buffer = new byte[1024];
                    var messageBuilder = new StringBuilder();

                    while (_isRunning && !token.IsCancellationRequested && _vmixTcpClient.Connected)
                    {
                        int bytesRead = await stream.ReadAsync(buffer, token);
                        if (bytesRead == 0)
                            break;

                        string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        messageBuilder.Append(data);

                        string messages = messageBuilder.ToString();
                        var lines = messages.Split(new[] { "\r\n" }, StringSplitOptions.None);

                        // Keep the last incomplete line
                        messageBuilder.Clear();
                        messageBuilder.Append(lines[^1]);

                        // Process complete lines
                        for (int i = 0; i < lines.Length - 1; i++)
                        {
                            ProcessTallyMessage(lines[i]);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Normal cancellation
                    break;
                }
                catch (Exception ex)
                {
                    LogMessage($"Connection error: {ex.Message}");
                    UpdateVmixStatus("Disconnected", Color.Red);

                    if (_isRunning && !token.IsCancellationRequested)
                    {
                        LogMessage("Retrying in 2 seconds...");
                        await Task.Delay(2000, token);
                    }
                }
                finally
                {
                    _vmixTcpClient?.Close();
                    _vmixTcpClient?.Dispose();
                    _vmixTcpClient = null;
                }
            }

            UpdateVmixStatus("Stopped", Color.Gray);
            LogMessage("vMix TCP listener stopped");
        }

        private void ProcessTallyMessage(string message)
        {
            if (message.StartsWith("TALLY OK"))
            {
                // Parse tally string (e.g., "TALLY OK 012000")
                // Each digit represents an input: 0=off, 1=program, 2=preview
                string tallyStatus = message.Replace("TALLY OK", "").Trim();

                // Find which input is on program (1 in the tally string)
                for (int i = 0; i < tallyStatus.Length; i++)
                {
                    if (tallyStatus[i] == '1')
                    {
                        int inputNum = i + 1; // vMix uses 1-based indexing
                        Task.Run(() => UpdateTallyLights(inputNum));
                        return;
                    }
                }

                // No input on program - turn off all tallies
                Task.Run(() => UpdateTallyLights(null));
            }
        }

        #endregion

        #region Start/Stop Logic

        private async void BtnStartStop_Click(object? sender, EventArgs e)
        {
            btnStartStop.Enabled = false;
            try
            {
                if (_isRunning)
                {
                    StopTallyController();
                }
                else
                {
                    await StartTallyController();
                }
            }
            finally
            {
                btnStartStop.Enabled = true;
            }
        }

        private async Task<bool> StartTallyController()
        {
            // Verify vMix connection
            if (!await TestVmixConnection())
            {
                MessageBox.Show("Cannot connect to vMix. Please check the IP and port settings.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Test camera connections (but allow to continue even if some fail)
            LogMessage("Checking camera connections...");
            for (int i = 0; i < dgvCameras.Rows.Count; i++)
            {
                if (!dgvCameras.Rows[i].IsNewRow)
                {
                    await TestCameraConnection(i);
                }
            }

            _isRunning = true;

            // Update UI
            btnStartStop.Text = "STOP";
            btnStartStop.BackColor = Color.FromArgb(255, 200, 200); // Light red
            pnlMain.Enabled = false;
            UpdateTrayMenuStartStopText();

            // Start the listener thread
            _listenerThread = new Thread(() => StartListener())
            {
                IsBackground = true
            };
            _listenerThread.Start();

            LogMessage("Tally controller started");
            return true;
        }

        private void StopTallyController()
        {
            _isRunning = false;

            // Cancel the listener
            _cancellationTokenSource?.Cancel();

            // Turn off all tally lights
            LogMessage("Turning off all tally lights...");
            foreach (DataGridViewRow row in dgvCameras.Rows)
            {
                if (row.IsNewRow) continue;

                var numValue = row.Cells[colCameraNum.Index].Value;
                if (numValue != null && int.TryParse(numValue.ToString(), out int num))
                {
                    string ip = row.Cells[colCameraIp.Index].Value?.ToString() ?? "";
                    string username = row.Cells[colCameraUsername.Index].Value?.ToString() ?? "";
                    string password = row.Cells[colCameraPassword.Index].Value?.ToString() ?? "";

                    if (!string.IsNullOrWhiteSpace(ip))
                    {
                        _ = SetCameraTally(ip, username, password, false);
                        UpdateCameraOnAirStatus(num, false);
                    }
                }
            }

            _currentActiveInput = null;

            // Update UI
            btnStartStop.Text = "START";
            btnStartStop.BackColor = Color.FromArgb(128, 255, 128); // Light green
            pnlMain.Enabled = true;
            UpdateTrayMenuStartStopText();

            LogMessage("Tally controller stopped");
        }

        #endregion

        #region System Tray

        private void NotifyIcon_Click(object? sender, EventArgs e)
        {
            // Single click shows the form
            ShowForm();
        }

        private void NotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            // Double click also shows the form
            ShowForm();
        }

        private void TrayMenuOpenDashboard_Click(object? sender, EventArgs e)
        {
            ShowForm();
        }

        private async void TrayMenuStartStop_Click(object? sender, EventArgs e)
        {
            btnStartStop.Enabled = false;
            trayMenuStartStop.Enabled = false;
            try
            {
                if (_isRunning)
                {
                    StopTallyController();
                }
                else
                {
                    await StartTallyController();
                }
            }
            finally
            {
                btnStartStop.Enabled = true;
                trayMenuStartStop.Enabled = true;
            }
        }

        private void TrayMenuExit_Click(object? sender, EventArgs e)
        {
            ExitApplication();
        }

        private void UpdateTrayMenuStartStopText()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateTrayMenuStartStopText);
                return;
            }
            trayMenuStartStop.Text = _isRunning ? "Stop" : "Start";
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            Activate();
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Minimize to tray instead of closing
                e.Cancel = true;
                Hide();
            }
        }

        private void ExitApplication()
        {
            // Stop the controller
            if (_isRunning)
            {
                StopTallyController();
            }

            // Wait a moment for tally lights to turn off
            Thread.Sleep(500);

            // Actually exit
            notifyIcon.Visible = false;
            Application.Exit();
        }

        #endregion

        #region Exit Handler

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to exit? \nThis will stop the connection and switch off tallys",
                "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                ExitApplication();
            }
        }

        #endregion

        #region Info Dialog

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formInformation = new FormInformation();
            formInformation.ShowDialog();
        }

        #endregion

        #region Logging

        private void LogMessage(string message)
        {
            // TODO: TO IMPLEMENT CORRECTLY
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            System.Diagnostics.Debug.WriteLine($"[{timestamp}] {message}");
        }

        #endregion

        #region File Operations

        private void NewToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!PromptSaveIfNeeded())
                return;

            // Clear current settings
            txtVmixIp.Text = "127.0.0.1";
            txtVmixPort.Text = "8099";
            dgvCameras.Rows.Clear();
            dgvCameras.Rows.Add(1, "192.168.100.1", "", "", "Not tested", false);

            _currentFilePath = null;
            _hasUnsavedChanges = false;
            UpdateTitle();
        }

        private void OpenToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!PromptSaveIfNeeded())
                return;

            using var openDialog = new OpenFileDialog
            {
                Filter = "Tally Settings (*.xml)|*.xml|All Files (*.*)|*.*",
                Title = "Open Tally Settings"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadSettingsFromFile(openDialog.FileName);
                    SettingsManager.AddRecentFile(openDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading settings: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (_currentFilePath == null)
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                SaveSettings(_currentFilePath);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Tally Settings (*.xml)|*.xml|All Files (*.*)|*.*",
                Title = "Save Tally Settings",
                FileName = _currentFilePath != null ? Path.GetFileName(_currentFilePath) : "tally-settings.xml"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveSettings(saveDialog.FileName);
            }
        }

        private void RecentFilesToolStripMenuItem_DropDownOpening(object? sender, EventArgs e)
        {
            // Clear existing items
            recentFilesToolStripMenuItem.DropDownItems.Clear();

            var recentFiles = SettingsManager.GetRecentFiles();

            if (recentFiles.Count == 0)
            {
                var noFilesItem = new ToolStripMenuItem("(No recent files)") { Enabled = false };
                recentFilesToolStripMenuItem.DropDownItems.Add(noFilesItem);
            }
            else
            {
                foreach (var file in recentFiles)
                {
                    var item = new ToolStripMenuItem(Path.GetFileName(file))
                    {
                        Tag = file,
                        ToolTipText = file
                    };
                    item.Click += RecentFile_Click;
                    recentFilesToolStripMenuItem.DropDownItems.Add(item);
                }
            }
        }

        private void RecentFile_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is string filePath)
            {
                if (!PromptSaveIfNeeded())
                    return;

                try
                {
                    LoadSettingsFromFile(filePath);
                    SettingsManager.AddRecentFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading settings: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool PromptSaveIfNeeded()
        {
            if (!_hasUnsavedChanges)
                return true;

            var result = MessageBox.Show("You have unsaved changes. Do you want to save them?",
                "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveToolStripMenuItem_Click(null, EventArgs.Empty);
                return !_hasUnsavedChanges; // Return true if save was successful
            }
            else if (result == DialogResult.No)
            {
                return true;
            }
            else // Cancel
            {
                return false;
            }
        }

        private void LoadSettingsFromFile(string filePath)
        {
            var settings = SettingsManager.LoadFromFile(filePath);

            // Load vMix settings
            txtVmixIp.Text = settings.VmixIp;
            txtVmixPort.Text = settings.VmixPort.ToString();

            // Load cameras
            dgvCameras.Rows.Clear();
            foreach (var camera in settings.Cameras)
            {
                dgvCameras.Rows.Add(camera.Number, camera.IpAddress, camera.Username, camera.Password, "Not tested", false);
            }

            _currentFilePath = filePath;
            _hasUnsavedChanges = false;
            SettingsManager.SetLastFile(filePath);
            UpdateTitle();

            LogMessage($"Settings loaded from {filePath}");
        }

        private void SaveSettings(string filePath)
        {
            try
            {
                var settings = new AppSettings
                {
                    VmixIp = txtVmixIp.Text,
                    VmixPort = int.TryParse(txtVmixPort.Text, out int port) ? port : 8099
                };

                // Save cameras
                foreach (DataGridViewRow row in dgvCameras.Rows)
                {
                    if (row.IsNewRow) continue;

                    var numValue = row.Cells[colCameraNum.Index].Value;
                    var ipValue = row.Cells[colCameraIp.Index].Value;

                    if (numValue != null && ipValue != null)
                    {
                        if (int.TryParse(numValue.ToString(), out int num))
                        {
                            var camera = new CameraConfig
                            {
                                Number = num,
                                IpAddress = ipValue.ToString() ?? "",
                                Username = row.Cells[colCameraUsername.Index].Value?.ToString() ?? "",
                                Password = row.Cells[colCameraPassword.Index].Value?.ToString() ?? ""
                            };
                            settings.Cameras.Add(camera);
                        }
                    }
                }

                SettingsManager.SaveToFile(filePath, settings);

                _currentFilePath = filePath;
                _hasUnsavedChanges = false;
                SettingsManager.SetLastFile(filePath);
                SettingsManager.AddRecentFile(filePath);
                UpdateTitle();

                LogMessage($"Settings saved to {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
