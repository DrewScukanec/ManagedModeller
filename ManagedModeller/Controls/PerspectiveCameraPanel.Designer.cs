namespace ManagedModeller.Controls {
    partial class PerspectiveCameraPanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerspectiveCameraPanel));
            this.namePanel = new ManagedModeller.Controls.StringPanel();
            this.nearPanel = new ManagedModeller.Controls.FloatPanel();
            this.farPanel = new ManagedModeller.Controls.FloatPanel();
            this.fovyPanel = new ManagedModeller.Controls.FloatPanel();
            this.locationPanel = new ManagedModeller.Controls.Vector3Panel();
            this.lookAtPanel = new ManagedModeller.Controls.Vector3Panel();
            this.upPanel = new ManagedModeller.Controls.Vector3Panel();
            this.SuspendLayout();
            // 
            // namePanel
            // 
            this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.namePanel.Label = "Name";
            this.namePanel.Location = new System.Drawing.Point(0, 0);
            this.namePanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(83, 20);
            this.namePanel.TabIndex = 0;
            this.namePanel.Value = "";
            // 
            // nearPanel
            // 
            this.nearPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nearPanel.Label = "Near";
            this.nearPanel.Location = new System.Drawing.Point(0, 20);
            this.nearPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.nearPanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.nearPanel.Name = "nearPanel";
            this.nearPanel.Size = new System.Drawing.Size(83, 20);
            this.nearPanel.TabIndex = 1;
            this.nearPanel.Value = 0F;
            // 
            // farPanel
            // 
            this.farPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.farPanel.Label = "Far ";
            this.farPanel.Location = new System.Drawing.Point(0, 40);
            this.farPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.farPanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.farPanel.Name = "farPanel";
            this.farPanel.Size = new System.Drawing.Size(83, 20);
            this.farPanel.TabIndex = 2;
            this.farPanel.Value = 0F;
            // 
            // fovyPanel
            // 
            this.fovyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fovyPanel.Label = "FOVy";
            this.fovyPanel.Location = new System.Drawing.Point(0, 60);
            this.fovyPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.fovyPanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.fovyPanel.Name = "fovyPanel";
            this.fovyPanel.Size = new System.Drawing.Size(83, 20);
            this.fovyPanel.TabIndex = 3;
            this.fovyPanel.Value = 0F;
            // 
            // locationPanel
            // 
            this.locationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.locationPanel.Label = "Location";
            this.locationPanel.Location = new System.Drawing.Point(0, 80);
            this.locationPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.locationPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(83, 81);
            this.locationPanel.TabIndex = 4;
            this.locationPanel.Value = ((OpenTK.Vector3)(resources.GetObject("locationPanel.Value")));
            // 
            // lookAtPanel
            // 
            this.lookAtPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lookAtPanel.Label = "Look At";
            this.lookAtPanel.Location = new System.Drawing.Point(0, 161);
            this.lookAtPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.lookAtPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.lookAtPanel.Name = "lookAtPanel";
            this.lookAtPanel.Size = new System.Drawing.Size(83, 81);
            this.lookAtPanel.TabIndex = 5;
            this.lookAtPanel.Value = ((OpenTK.Vector3)(resources.GetObject("lookAtPanel.Value")));
            // 
            // upPanel
            // 
            this.upPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upPanel.Label = "Up";
            this.upPanel.Location = new System.Drawing.Point(0, 242);
            this.upPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.upPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.upPanel.Name = "upPanel";
            this.upPanel.Size = new System.Drawing.Size(83, 81);
            this.upPanel.TabIndex = 6;
            this.upPanel.Value = ((OpenTK.Vector3)(resources.GetObject("upPanel.Value")));
            // 
            // PerspectiveCameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upPanel);
            this.Controls.Add(this.lookAtPanel);
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.fovyPanel);
            this.Controls.Add(this.farPanel);
            this.Controls.Add(this.nearPanel);
            this.Controls.Add(this.namePanel);
            this.MaximumSize = new System.Drawing.Size(0, 327);
            this.MinimumSize = new System.Drawing.Size(83, 327);
            this.Name = "PerspectiveCameraPanel";
            this.Size = new System.Drawing.Size(83, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private StringPanel namePanel;
        private FloatPanel nearPanel;
        private FloatPanel farPanel;
        private FloatPanel fovyPanel;
        private Vector3Panel locationPanel;
        private Vector3Panel lookAtPanel;
        private Vector3Panel upPanel;
    }
}
