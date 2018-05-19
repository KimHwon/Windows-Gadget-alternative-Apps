namespace GadgetAlternativeApps
{
    partial class GadgetForm
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
            this.gadgetDisplay = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // gadgetDisplay
            // 
            this.gadgetDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gadgetDisplay.Location = new System.Drawing.Point(0, 0);
            this.gadgetDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.gadgetDisplay.Name = "gadgetDisplay";
            this.gadgetDisplay.ScrollBarsEnabled = false;
            this.gadgetDisplay.Size = new System.Drawing.Size(282, 253);
            this.gadgetDisplay.TabIndex = 0;
            this.gadgetDisplay.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.gadgetDisplay_DocumentCompleted);
            // 
            // GadgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.gadgetDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GadgetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GadgetForm";
            this.Load += new System.EventHandler(this.GadgetForm_Load);
            this.LocationChanged += new System.EventHandler(this.GadgetForm_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser gadgetDisplay;
    }
}