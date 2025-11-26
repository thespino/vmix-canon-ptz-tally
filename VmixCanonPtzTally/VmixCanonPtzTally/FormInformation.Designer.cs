namespace VmixCanonPtzTally
{
    partial class FormInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformation));
            pictureBox1 = new PictureBox();
            btnOK = new Button();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            linkLabel2 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.icon_png;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 190);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.FlatStyle = FlatStyle.System;
            btnOK.Location = new Point(227, 416);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 211);
            label1.Name = "label1";
            label1.Size = new Size(290, 31);
            label1.TabIndex = 2;
            label1.Text = "Vmix Canon PTZ Tally";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(12, 242);
            label2.Name = "label2";
            label2.Size = new Size(290, 54);
            label2.TabIndex = 3;
            label2.Text = "Windows app to switch on tally on Canon PTZ Cameras from Vmix (i.e. CR-N300, CR-N500, CR-N700)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel1.Location = new Point(12, 327);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(290, 18);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "thespino";
            linkLabel1.TextAlign = ContentAlignment.TopCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Location = new Point(12, 307);
            label3.Name = "label3";
            label3.Size = new Size(290, 20);
            label3.TabIndex = 5;
            label3.Text = "Author";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.Location = new Point(12, 345);
            label4.Name = "label4";
            label4.Size = new Size(290, 20);
            label4.TabIndex = 7;
            label4.Text = "GitHub";
            label4.TextAlign = ContentAlignment.BottomCenter;
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel2.Location = new Point(12, 365);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(290, 18);
            linkLabel2.TabIndex = 6;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "thespino/vmix-canon-ptz-tally";
            linkLabel2.TextAlign = ContentAlignment.TopCenter;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // FormInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 451);
            Controls.Add(label4);
            Controls.Add(linkLabel2);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOK);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInformation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Information";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnOK;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel2;
    }
}