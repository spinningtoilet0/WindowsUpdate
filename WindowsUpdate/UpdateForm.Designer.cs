namespace WindowsUpdate
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.UpdateLbl = new System.Windows.Forms.Label();
            this.LoadingLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateLbl
            // 
            this.UpdateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateLbl.Font = new System.Drawing.Font("Yu Gothic UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLbl.ForeColor = System.Drawing.Color.White;
            this.UpdateLbl.Location = new System.Drawing.Point(0, 0);
            this.UpdateLbl.Name = "UpdateLbl";
            this.UpdateLbl.Size = new System.Drawing.Size(1722, 909);
            this.UpdateLbl.TabIndex = 0;
            this.UpdateLbl.Text = "Working on updates\r\nDon\'t turn off your computer";
            this.UpdateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingLogo
            // 
            this.LoadingLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoadingLogo.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.LoadingLogo.Image = global::WindowsUpdate.Properties.Resources.loading;
            this.LoadingLogo.Location = new System.Drawing.Point(823, 319);
            this.LoadingLogo.Name = "LoadingLogo";
            this.LoadingLogo.Size = new System.Drawing.Size(102, 94);
            this.LoadingLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadingLogo.TabIndex = 1;
            this.LoadingLogo.TabStop = false;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1722, 909);
            this.Controls.Add(this.LoadingLogo);
            this.Controls.Add(this.UpdateLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateForm";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.Resize += new System.EventHandler(this.UpdateForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UpdateLbl;
        private System.Windows.Forms.PictureBox LoadingLogo;
    }
}