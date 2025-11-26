namespace VmixCanonPtzTally
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            recentFilesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            btnStartStop = new Button();
            panel1 = new Panel();
            lblCamerasStatus = new Label();
            label5 = new Label();
            lblVmixStatus = new Label();
            label3 = new Label();
            pnlMain = new Panel();
            dgvCameras = new DataGridView();
            colCameraNum = new DataGridViewTextBoxColumn();
            colCameraIp = new DataGridViewTextBoxColumn();
            colCameraUsername = new DataGridViewTextBoxColumn();
            colCameraPassword = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colOnAir = new DataGridViewCheckBoxColumn();
            grpVmixConfig = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            txtVmixPort = new TextBox();
            txtVmixIp = new TextBox();
            notifyIcon = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            trayMenuOpenDashboard = new ToolStripMenuItem();
            trayMenuStartStop = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            trayMenuExit = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCameras).BeginInit();
            grpVmixConfig.SuspendLayout();
            trayContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            //
            // fileToolStripMenuItem
            //
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator2, recentFilesToolStripMenuItem, toolStripSeparator3, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            //
            // newToolStripMenuItem
            //
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(195, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            //
            // openToolStripMenuItem
            //
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(195, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            //
            // saveToolStripMenuItem
            //
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(195, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            //
            // saveAsToolStripMenuItem
            //
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(195, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            //
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(192, 6);
            //
            // recentFilesToolStripMenuItem
            //
            recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            recentFilesToolStripMenuItem.Size = new Size(195, 22);
            recentFilesToolStripMenuItem.Text = "Recent Files";
            recentFilesToolStripMenuItem.DropDownOpening += RecentFilesToolStripMenuItem_DropDownOpening;
            //
            // toolStripSeparator3
            //
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(192, 6);
            //
            // exitToolStripMenuItem
            //
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(195, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { infoToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(95, 22);
            infoToolStripMenuItem.Text = "Info";
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            //
            // btnStartStop
            //
            btnStartStop.BackColor = Color.FromArgb(128, 255, 128);
            btnStartStop.Location = new Point(12, 8);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(75, 39);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "START";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += BtnStartStop_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(lblCamerasStatus);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblVmixStatus);
            panel1.Controls.Add(btnStartStop);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(634, 55);
            panel1.TabIndex = 5;
            // 
            // lblCamerasStatus
            // 
            lblCamerasStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCamerasStatus.Location = new Point(273, 23);
            lblCamerasStatus.Name = "lblCamerasStatus";
            lblCamerasStatus.Size = new Size(154, 24);
            lblCamerasStatus.TabIndex = 10;
            lblCamerasStatus.Text = "...";
            lblCamerasStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(273, 8);
            label5.Name = "label5";
            label5.Size = new Size(154, 15);
            label5.TabIndex = 9;
            label5.Text = "Cameras status:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVmixStatus
            // 
            lblVmixStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVmixStatus.Location = new Point(113, 23);
            lblVmixStatus.Name = "lblVmixStatus";
            lblVmixStatus.Size = new Size(154, 24);
            lblVmixStatus.TabIndex = 8;
            lblVmixStatus.Text = "...";
            lblVmixStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Location = new Point(113, 8);
            label3.Name = "label3";
            label3.Size = new Size(154, 15);
            label3.TabIndex = 7;
            label3.Text = "Vmix status:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvCameras);
            pnlMain.Controls.Add(grpVmixConfig);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 79);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(634, 292);
            pnlMain.TabIndex = 6;
            //
            // dgvCameras
            //
            dgvCameras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCameras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCameras.Columns.AddRange(new DataGridViewColumn[] { colCameraNum, colCameraIp, colCameraUsername, colCameraPassword, colStatus, colOnAir });
            dgvCameras.Location = new Point(12, 103);
            dgvCameras.Name = "dgvCameras";
            dgvCameras.Size = new Size(610, 177);
            dgvCameras.TabIndex = 10;
            dgvCameras.CellEndEdit += DgvCameras_CellEndEdit;
            dgvCameras.CellValueChanged += Settings_Changed;
            dgvCameras.RowValidated += DgvCameras_RowValidated;
            dgvCameras.RowsAdded += Settings_Changed;
            dgvCameras.RowsRemoved += Settings_Changed;
            // 
            // colCameraNum
            // 
            colCameraNum.HeaderText = "NR";
            colCameraNum.MinimumWidth = 40;
            colCameraNum.Name = "colCameraNum";
            colCameraNum.ToolTipText = "Input number inside Vmix";
            colCameraNum.Width = 40;
            // 
            // colCameraIp
            // 
            colCameraIp.HeaderText = "Camera IP";
            colCameraIp.MinimumWidth = 70;
            colCameraIp.Name = "colCameraIp";
            colCameraIp.ToolTipText = "Camera IP i.e. 192.168.100.1";
            colCameraIp.Width = 150;
            // 
            // colCameraUsername
            // 
            colCameraUsername.HeaderText = "Username";
            colCameraUsername.Name = "colCameraUsername";
            // 
            // colCameraPassword
            // 
            colCameraPassword.HeaderText = "Password";
            colCameraPassword.Name = "colCameraPassword";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 50;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.ToolTipText = "Camera connection status";
            colStatus.Width = 120;
            // 
            // colOnAir
            // 
            colOnAir.HeaderText = "On Air";
            colOnAir.MinimumWidth = 50;
            colOnAir.Name = "colOnAir";
            colOnAir.ReadOnly = true;
            colOnAir.ToolTipText = "Is camera On Air?";
            colOnAir.Width = 50;
            // 
            // grpVmixConfig
            // 
            grpVmixConfig.Controls.Add(label2);
            grpVmixConfig.Controls.Add(label1);
            grpVmixConfig.Controls.Add(txtVmixPort);
            grpVmixConfig.Controls.Add(txtVmixIp);
            grpVmixConfig.Location = new Point(12, 9);
            grpVmixConfig.Name = "grpVmixConfig";
            grpVmixConfig.Size = new Size(255, 88);
            grpVmixConfig.TabIndex = 9;
            grpVmixConfig.TabStop = false;
            grpVmixConfig.Text = "Vmix config";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 55);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Vmix port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 26);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 2;
            label1.Text = "Vmix IP";
            //
            // txtVmixPort
            //
            txtVmixPort.Location = new Point(72, 52);
            txtVmixPort.Name = "txtVmixPort";
            txtVmixPort.Size = new Size(165, 23);
            txtVmixPort.TabIndex = 6;
            txtVmixPort.Leave += TxtVmix_Leave;
            txtVmixPort.TextChanged += Settings_Changed;
            //
            // txtVmixIp
            //
            txtVmixIp.Location = new Point(72, 23);
            txtVmixIp.Name = "txtVmixIp";
            txtVmixIp.Size = new Size(165, 23);
            txtVmixIp.TabIndex = 3;
            txtVmixIp.Leave += TxtVmix_Leave;
            txtVmixIp.TextChanged += Settings_Changed;
            //
            // notifyIcon
            //
            notifyIcon.ContextMenuStrip = trayContextMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
            notifyIcon.Text = "Vmix Canon PTZ Tally";
            notifyIcon.Visible = true;
            notifyIcon.Click += NotifyIcon_Click;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            //
            // trayContextMenu
            //
            trayContextMenu.Items.AddRange(new ToolStripItem[] { trayMenuOpenDashboard, trayMenuStartStop, toolStripSeparator1, trayMenuExit });
            trayContextMenu.Name = "trayContextMenu";
            trayContextMenu.Size = new Size(181, 76);
            //
            // trayMenuOpenDashboard
            //
            trayMenuOpenDashboard.Name = "trayMenuOpenDashboard";
            trayMenuOpenDashboard.Size = new Size(180, 22);
            trayMenuOpenDashboard.Text = "Open Dashboard";
            trayMenuOpenDashboard.Click += TrayMenuOpenDashboard_Click;
            //
            // trayMenuStartStop
            //
            trayMenuStartStop.Name = "trayMenuStartStop";
            trayMenuStartStop.Size = new Size(180, 22);
            trayMenuStartStop.Text = "Start";
            trayMenuStartStop.Click += TrayMenuStartStop_Click;
            //
            // toolStripSeparator1
            //
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            //
            // trayMenuExit
            //
            trayMenuExit.Name = "trayMenuExit";
            trayMenuExit.Size = new Size(180, 22);
            trayMenuExit.Text = "Exit";
            trayMenuExit.Click += TrayMenuExit_Click;
            //
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 371);
            Controls.Add(pnlMain);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(550, 400);
            Name = "Form1";
            Text = "Vmix Canon PTZ Tally";
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCameras).EndInit();
            grpVmixConfig.ResumeLayout(false);
            grpVmixConfig.PerformLayout();
            trayContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem recentFilesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private Button btnStartStop;
        private Panel panel1;
        private Label lblVmixStatus;
        private Label label3;
        private Label lblCamerasStatus;
        private Label label5;
        private Panel pnlMain;
        private DataGridView dgvCameras;
        private GroupBox grpVmixConfig;
        private Label label2;
        private Label label1;
        private TextBox txtVmixPort;
        private TextBox txtVmixIp;
        private DataGridViewTextBoxColumn colCameraNum;
        private DataGridViewTextBoxColumn colCameraIp;
        private DataGridViewTextBoxColumn colCameraUsername;
        private DataGridViewTextBoxColumn colCameraPassword;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewCheckBoxColumn colOnAir;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem trayMenuOpenDashboard;
        private ToolStripMenuItem trayMenuStartStop;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem trayMenuExit;
    }
}
