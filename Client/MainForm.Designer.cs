namespace Client
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.link = new System.Windows.Forms.LinkLabel();
            this.WindowHandle = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.About = new System.Windows.Forms.Button();
            this.fd = new System.Windows.Forms.OpenFileDialog();
            this.ServStopBTN = new System.Windows.Forms.Button();
            this.actionText = new System.Windows.Forms.TextBox();
            this.actionIcon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SetCustomActionBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WindowHandle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // link
            // 
            this.link.ActiveLinkColor = System.Drawing.Color.Gray;
            this.link.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
            this.link.LinkColor = System.Drawing.Color.White;
            this.link.Location = new System.Drawing.Point(26, 42);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(285, 76);
            this.link.TabIndex = 0;
            this.link.Text = "Link label";
            this.link.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.link.VisitedLinkColor = System.Drawing.Color.White;
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CopyLink);
            // 
            // WindowHandle
            // 
            this.WindowHandle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.WindowHandle.Controls.Add(this.button5);
            this.WindowHandle.Controls.Add(this.Minimize);
            this.WindowHandle.ForeColor = System.Drawing.Color.White;
            this.WindowHandle.Location = new System.Drawing.Point(-2, -2);
            this.WindowHandle.Name = "WindowHandle";
            this.WindowHandle.Size = new System.Drawing.Size(345, 30);
            this.WindowHandle.TabIndex = 1;
            this.WindowHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.Cursor = System.Windows.Forms.Cursors.Default;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(2, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 3;
            this.button5.TabStop = false;
            this.button5.Text = "&Close";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ExitWindow);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Minimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.Minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Minimize.FlatAppearance.BorderSize = 0;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.ForeColor = System.Drawing.Color.White;
            this.Minimize.Location = new System.Drawing.Point(267, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(75, 30);
            this.Minimize.TabIndex = 2;
            this.Minimize.TabStop = false;
            this.Minimize.Text = "&Minimize";
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.MinimizeWindow);
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Actions by macedonga";
            this.notify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OpenWindow);
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.About.ForeColor = System.Drawing.Color.White;
            this.About.Location = new System.Drawing.Point(29, 158);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(281, 32);
            this.About.TabIndex = 10;
            this.About.TabStop = false;
            this.About.Text = "&About";
            this.About.UseVisualStyleBackColor = false;
            this.About.Click += new System.EventHandler(this.AboutShow);
            // 
            // fd
            // 
            this.fd.DefaultExt = "exe";
            this.fd.InitialDirectory = "C:/";
            this.fd.Title = "Program Path - Actions by macedonga";
            // 
            // ServStopBTN
            // 
            this.ServStopBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ServStopBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServStopBTN.ForeColor = System.Drawing.Color.White;
            this.ServStopBTN.Location = new System.Drawing.Point(30, 121);
            this.ServStopBTN.Name = "ServStopBTN";
            this.ServStopBTN.Size = new System.Drawing.Size(281, 31);
            this.ServStopBTN.TabIndex = 11;
            this.ServStopBTN.TabStop = false;
            this.ServStopBTN.Text = "&Stop service";
            this.ServStopBTN.UseVisualStyleBackColor = false;
            this.ServStopBTN.Click += new System.EventHandler(this.ServStop);
            // 
            // actionText
            // 
            this.actionText.Location = new System.Drawing.Point(32, 30);
            this.actionText.Name = "actionText";
            this.actionText.Size = new System.Drawing.Size(281, 21);
            this.actionText.TabIndex = 0;
            this.actionText.Text = "Action text";
            // 
            // actionIcon
            // 
            this.actionIcon.Location = new System.Drawing.Point(32, 57);
            this.actionIcon.Name = "actionIcon";
            this.actionIcon.Size = new System.Drawing.Size(281, 21);
            this.actionIcon.TabIndex = 1;
            this.actionIcon.Text = "Action icon";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Set custom action";
            // 
            // SetCustomActionBTN
            // 
            this.SetCustomActionBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SetCustomActionBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetCustomActionBTN.ForeColor = System.Drawing.Color.White;
            this.SetCustomActionBTN.Location = new System.Drawing.Point(32, 84);
            this.SetCustomActionBTN.Name = "SetCustomActionBTN";
            this.SetCustomActionBTN.Size = new System.Drawing.Size(281, 30);
            this.SetCustomActionBTN.TabIndex = 15;
            this.SetCustomActionBTN.TabStop = false;
            this.SetCustomActionBTN.Text = "Set &custom action";
            this.SetCustomActionBTN.UseVisualStyleBackColor = false;
            this.SetCustomActionBTN.Click += new System.EventHandler(this.SetCustomAction);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.actionText);
            this.panel1.Controls.Add(this.SetCustomActionBTN);
            this.panel1.Controls.Add(this.actionIcon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 130);
            this.panel1.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(337, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ServStopBTN);
            this.Controls.Add(this.About);
            this.Controls.Add(this.WindowHandle);
            this.Controls.Add(this.link);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(23, 25, 23, 25);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actions";
            this.TopMost = true;
            this.WindowHandle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel link;
        private System.Windows.Forms.Panel WindowHandle;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.OpenFileDialog fd;
        private System.Windows.Forms.Button ServStopBTN;
        private System.Windows.Forms.TextBox actionText;
        private System.Windows.Forms.TextBox actionIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SetCustomActionBTN;
        private System.Windows.Forms.Panel panel1;
    }
}

