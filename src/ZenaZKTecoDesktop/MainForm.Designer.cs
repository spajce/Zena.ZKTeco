namespace ZenaZKTecoDesktop
{
    partial class MainForm
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
            this.DonwloadLogsButton = new System.Windows.Forms.Button();
            this.ClearAdministratorsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DonwloadLogsButton
            // 
            this.DonwloadLogsButton.Location = new System.Drawing.Point(67, 38);
            this.DonwloadLogsButton.Name = "DonwloadLogsButton";
            this.DonwloadLogsButton.Size = new System.Drawing.Size(171, 55);
            this.DonwloadLogsButton.TabIndex = 0;
            this.DonwloadLogsButton.Text = "Download Logs";
            this.DonwloadLogsButton.UseVisualStyleBackColor = true;
            this.DonwloadLogsButton.Click += new System.EventHandler(this.DonwloadLogsButton_Click);
            // 
            // ClearAdministratorsButton
            // 
            this.ClearAdministratorsButton.Location = new System.Drawing.Point(585, 49);
            this.ClearAdministratorsButton.Name = "ClearAdministratorsButton";
            this.ClearAdministratorsButton.Size = new System.Drawing.Size(171, 55);
            this.ClearAdministratorsButton.TabIndex = 2;
            this.ClearAdministratorsButton.Text = "Clear Administrators";
            this.ClearAdministratorsButton.UseVisualStyleBackColor = true;
            this.ClearAdministratorsButton.Click += new System.EventHandler(this.ClearAdministratorsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 519);
            this.Controls.Add(this.ClearAdministratorsButton);
            this.Controls.Add(this.DonwloadLogsButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zena ZKTeco Desktop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DonwloadLogsButton;
        private System.Windows.Forms.Button ClearAdministratorsButton;
    }
}

