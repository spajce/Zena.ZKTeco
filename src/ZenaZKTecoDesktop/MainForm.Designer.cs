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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DonwloadLogsButton
            // 
            this.DonwloadLogsButton.Location = new System.Drawing.Point(199, 25);
            this.DonwloadLogsButton.Margin = new System.Windows.Forms.Padding(4);
            this.DonwloadLogsButton.Name = "DonwloadLogsButton";
            this.DonwloadLogsButton.Size = new System.Drawing.Size(228, 68);
            this.DonwloadLogsButton.TabIndex = 0;
            this.DonwloadLogsButton.Text = "Download Logs";
            this.DonwloadLogsButton.UseVisualStyleBackColor = true;
            this.DonwloadLogsButton.Click += new System.EventHandler(this.DonwloadLogsButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(82, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(500, 202);
            this.dataGridView1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 374);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DonwloadLogsButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zena ZKTeco Desktop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DonwloadLogsButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

