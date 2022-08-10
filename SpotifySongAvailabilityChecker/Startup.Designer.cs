
namespace SpotifySongAvailabilityChecker
{
    partial class Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.pbxSplashScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSplashScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxSplashScreen
            // 
            this.pbxSplashScreen.Image = ((System.Drawing.Image)(resources.GetObject("pbxSplashScreen.Image")));
            this.pbxSplashScreen.Location = new System.Drawing.Point(-1, -1);
            this.pbxSplashScreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbxSplashScreen.Name = "pbxSplashScreen";
            this.pbxSplashScreen.Size = new System.Drawing.Size(650, 201);
            this.pbxSplashScreen.TabIndex = 0;
            this.pbxSplashScreen.TabStop = false;
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 199);
            this.Controls.Add(this.pbxSplashScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup";
            this.Load += new System.EventHandler(this.Startup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSplashScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxSplashScreen;
    }
}