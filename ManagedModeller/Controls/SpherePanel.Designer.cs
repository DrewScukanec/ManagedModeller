namespace ManagedModeller.Controls {
    partial class SpherePanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpherePanel));
            this.transformationPanel = new ManagedModeller.Controls.TransformationPanel();
            this.colorPanel = new ManagedModeller.Controls.Vector3Panel();
            this.namePanel = new ManagedModeller.Controls.StringPanel();
            this.maxDepthPanel = new ManagedModeller.Controls.IntPanel();
            this.SuspendLayout();
            // 
            // transformationPanel
            // 
            this.transformationPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transformationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.transformationPanel.Location = new System.Drawing.Point(0, 101);
            this.transformationPanel.MaximumSize = new System.Drawing.Size(0, 164);
            this.transformationPanel.MinimumSize = new System.Drawing.Size(98, 164);
            this.transformationPanel.Name = "transformationPanel";
            this.transformationPanel.Size = new System.Drawing.Size(116, 164);
            this.transformationPanel.TabIndex = 2;
            // 
            // colorPanel
            // 
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorPanel.Label = "Color";
            this.colorPanel.Location = new System.Drawing.Point(0, 20);
            this.colorPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.colorPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(116, 81);
            this.colorPanel.TabIndex = 1;
            this.colorPanel.Value = ((OpenTK.Vector3)(resources.GetObject("colorPanel.Value")));
            // 
            // namePanel
            // 
            this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.namePanel.Label = "Name";
            this.namePanel.Location = new System.Drawing.Point(0, 0);
            this.namePanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(116, 20);
            this.namePanel.TabIndex = 0;
            this.namePanel.Value = "";
            // 
            // maxDepthPanel
            // 
            this.maxDepthPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.maxDepthPanel.Label = "Max Depth";
            this.maxDepthPanel.Location = new System.Drawing.Point(0, 265);
            this.maxDepthPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.maxDepthPanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.maxDepthPanel.Name = "maxDepthPanel";
            this.maxDepthPanel.Size = new System.Drawing.Size(116, 20);
            this.maxDepthPanel.TabIndex = 3;
            // 
            // SpherePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maxDepthPanel);
            this.Controls.Add(this.transformationPanel);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.namePanel);
            this.MaximumSize = new System.Drawing.Size(0, 285);
            this.MinimumSize = new System.Drawing.Size(116, 285);
            this.Name = "SpherePanel";
            this.Size = new System.Drawing.Size(116, 285);
            this.ResumeLayout(false);

        }

        #endregion

        private StringPanel namePanel;
        private Vector3Panel colorPanel;
        private TransformationPanel transformationPanel;
        private IntPanel maxDepthPanel;
    }
}
