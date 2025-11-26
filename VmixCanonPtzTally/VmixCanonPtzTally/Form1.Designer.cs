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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
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
            dataGridView1 = new DataGridView();
            colCameraNum = new DataGridViewTextBoxColumn();
            colCameraIp = new DataGridViewTextBoxColumn();
            colCameraUsername = new DataGridViewTextBoxColumn();
            colCameraPassword = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colOnAir = new DataGridViewCheckBoxColumn();
            grpVmixConfig = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grpVmixConfig.SuspendLayout();
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
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
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
            pnlMain.Controls.Add(dataGridView1);
            pnlMain.Controls.Add(grpVmixConfig);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 79);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(634, 292);
            pnlMain.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCameraNum, colCameraIp, colCameraUsername, colCameraPassword, colStatus, colOnAir });
            dataGridView1.Location = new Point(12, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(610, 177);
            dataGridView1.TabIndex = 10;
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
            grpVmixConfig.Controls.Add(textBox2);
            grpVmixConfig.Controls.Add(textBox1);
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
            // textBox2
            // 
            textBox2.Location = new Point(72, 52);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(165, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 23);
            textBox1.TabIndex = 3;
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grpVmixConfig.ResumeLayout(false);
            grpVmixConfig.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
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
        private DataGridView dataGridView1;
        private GroupBox grpVmixConfig;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn colCameraNum;
        private DataGridViewTextBoxColumn colCameraIp;
        private DataGridViewTextBoxColumn colCameraUsername;
        private DataGridViewTextBoxColumn colCameraPassword;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewCheckBoxColumn colOnAir;
    }
}
