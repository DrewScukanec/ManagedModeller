namespace ManagedModeller.Controls {
    partial class CylinderPanel {
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
            ManagedModeller.Model.Transformation transformation2 = new ManagedModeller.Model.Transformation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CylinderPanel));
            this.divisionPanel = new ManagedModeller.Controls.IntPanel();
            this.transformationPanel = new ManagedModeller.Controls.TransformationPanel();
            this.colorPanel = new ManagedModeller.Controls.Vector3Panel();
            this.namePanel = new ManagedModeller.Controls.StringPanel();
            this.SuspendLayout();
            // 
            // divisionPanel
            // 
            this.divisionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.divisionPanel.Label = "Divisions";
            this.divisionPanel.Location = new System.Drawing.Point(0, 265);
            this.divisionPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.divisionPanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.divisionPanel.Name = "divisionPanel";
            this.divisionPanel.Size = new System.Drawing.Size(113, 20);
            this.divisionPanel.TabIndex = 3;
            this.divisionPanel.Value = 0;
            // 
            // transformationPanel
            // 
            this.transformationPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transformationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.transformationPanel.Location = new System.Drawing.Point(0, 101);
            this.transformationPanel.MaximumSize = new System.Drawing.Size(0, 164);
            this.transformationPanel.MinimumSize = new System.Drawing.Size(98, 164);
            this.transformationPanel.Name = "transformationPanel";
            this.transformationPanel.Size = new System.Drawing.Size(113, 164);
            this.transformationPanel.TabIndex = 2;
            transformation2.Rotation = ((OpenTK.Quaterniond)(resources.GetObject("transformation2.Rotation")));
            transformation2.Scale = ((OpenTK.Vector3d)(resources.GetObject("transformation2.Scale")));
            transformation2.Translation = ((OpenTK.Vector3d)(resources.GetObject("transformation2.Translation")));
            this.transformationPanel.Value = transformation2;
            // 
            // colorPanel
            // 
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorPanel.Label = "Color";
            this.colorPanel.Location = new System.Drawing.Point(0, 20);
            this.colorPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.colorPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(113, 81);
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
            this.namePanel.Size = new System.Drawing.Size(113, 20);
            this.namePanel.TabIndex = 0;
            this.namePanel.Value = "";
            // 
            // CylinderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.divisionPanel);
            this.Controls.Add(this.transformationPanel);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.namePanel);
            this.MaximumSize = new System.Drawing.Size(0, 285);
            this.MinimumSize = new System.Drawing.Size(113, 285);
            this.Name = "CylinderPanel";
            this.Size = new System.Drawing.Size(113, 285);
            this.ResumeLayout(false);

        }

        #endregion

        private StringPanel namePanel;
        private Vector3Panel colorPanel;
        private TransformationPanel transformationPanel;
        private IntPanel divisionPanel;
    }
}
