namespace ManagedModeller.Controls {
    partial class OrthographicCameraPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.stringPanel1 = new ManagedModeller.Controls.StringPanel();
            this.SuspendLayout();
            // 
            // stringPanel1
            // 
            this.stringPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.stringPanel1.Label = "Name";
            this.stringPanel1.Location = new System.Drawing.Point(0, 0);
            this.stringPanel1.MinimumSize = new System.Drawing.Size(50, 20);
            this.stringPanel1.Name = "stringPanel1";
            this.stringPanel1.Size = new System.Drawing.Size(517, 20);
            this.stringPanel1.TabIndex = 0;
            this.stringPanel1.Value = "";
            // 
            // OrthographicCameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stringPanel1);
            this.Name = "OrthographicCameraPanel";
            this.Size = new System.Drawing.Size(517, 529);
            this.ResumeLayout(false);

        }

        #endregion

        private StringPanel stringPanel1;
    }
}
