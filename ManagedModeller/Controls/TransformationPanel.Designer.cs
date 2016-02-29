namespace ManagedModeller.Controls {
    partial class TransformationPanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransformationPanel));
            this.translatePanel = new ManagedModeller.Controls.Vector3dPanel();
            this.scalePanel = new ManagedModeller.Controls.Vector3dPanel();
            this.SuspendLayout();
            // 
            // translatePanel
            // 
            this.translatePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.translatePanel.Label = "Translation";
            this.translatePanel.Location = new System.Drawing.Point(0, 0);
            this.translatePanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.translatePanel.MinimumSize = new System.Drawing.Size(70, 81);
            this.translatePanel.Name = "translatePanel";
            this.translatePanel.Size = new System.Drawing.Size(98, 81);
            this.translatePanel.TabIndex = 0;
            this.translatePanel.Value = ((OpenTK.Vector3d)(resources.GetObject("translatePanel.Value")));
            // 
            // scalePanel
            // 
            this.scalePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.scalePanel.Label = "Scale";
            this.scalePanel.Location = new System.Drawing.Point(0, 81);
            this.scalePanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.scalePanel.MinimumSize = new System.Drawing.Size(70, 81);
            this.scalePanel.Name = "scalePanel";
            this.scalePanel.Size = new System.Drawing.Size(98, 81);
            this.scalePanel.TabIndex = 1;
            this.scalePanel.Value = ((OpenTK.Vector3d)(resources.GetObject("scalePanel.Value")));
            // 
            // TransformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.scalePanel);
            this.Controls.Add(this.translatePanel);
            this.MaximumSize = new System.Drawing.Size(0, 164);
            this.MinimumSize = new System.Drawing.Size(98, 164);
            this.Name = "TransformationPanel";
            this.Size = new System.Drawing.Size(98, 164);
            this.ResumeLayout(false);

        }

        #endregion

        private Vector3dPanel translatePanel;
        private Vector3dPanel scalePanel;
    }
}
