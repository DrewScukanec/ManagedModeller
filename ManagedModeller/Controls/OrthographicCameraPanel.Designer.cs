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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrthographicCameraPanel));
            this.farPanel = new ManagedModeller.Controls.FloatPanel();
            this.nearPanel = new ManagedModeller.Controls.FloatPanel();
            this.namePanel = new ManagedModeller.Controls.StringPanel();
            this.locationPanel = new ManagedModeller.Controls.Vector3Panel();
            this.lookAtPanel = new ManagedModeller.Controls.Vector3Panel();
            this.upPanel = new ManagedModeller.Controls.Vector3Panel();
            this.SuspendLayout();
            // 
            // farPanel
            // 
            this.farPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.farPanel.Label = "Far ";
            this.farPanel.Location = new System.Drawing.Point(0, 40);
            this.farPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.farPanel.MinimumSize = new System.Drawing.Size(75, 20);
            this.farPanel.Name = "farPanel";
            this.farPanel.Size = new System.Drawing.Size(79, 20);
            this.farPanel.TabIndex = 2;
            this.farPanel.Value = 0F;
            // 
            // nearPanel
            // 
            this.nearPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nearPanel.Label = "Near";
            this.nearPanel.Location = new System.Drawing.Point(0, 20);
            this.nearPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.nearPanel.MinimumSize = new System.Drawing.Size(75, 20);
            this.nearPanel.Name = "nearPanel";
            this.nearPanel.Size = new System.Drawing.Size(79, 20);
            this.nearPanel.TabIndex = 1;
            this.nearPanel.Value = 0F;
            // 
            // namePanel
            // 
            this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.namePanel.Label = "Name";
            this.namePanel.Location = new System.Drawing.Point(0, 0);
            this.namePanel.MinimumSize = new System.Drawing.Size(50, 20);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(79, 20);
            this.namePanel.TabIndex = 0;
            this.namePanel.Value = "";
            // 
            // locationPanel
            // 
            this.locationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.locationPanel.Label = "Location";
            this.locationPanel.Location = new System.Drawing.Point(0, 60);
            this.locationPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.locationPanel.MinimumSize = new System.Drawing.Size(79, 81);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(79, 81);
            this.locationPanel.TabIndex = 3;
            // 
            // lookAtPanel
            // 
            this.lookAtPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lookAtPanel.Label = "Look At";
            this.lookAtPanel.Location = new System.Drawing.Point(0, 141);
            this.lookAtPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.lookAtPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.lookAtPanel.Name = "lookAtPanel";
            this.lookAtPanel.Size = new System.Drawing.Size(79, 81);
            this.lookAtPanel.TabIndex = 4;
            // 
            // upPanel
            // 
            this.upPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upPanel.Label = "Up";
            this.upPanel.Location = new System.Drawing.Point(0, 222);
            this.upPanel.MaximumSize = new System.Drawing.Size(0, 81);
            this.upPanel.MinimumSize = new System.Drawing.Size(62, 81);
            this.upPanel.Name = "upPanel";
            this.upPanel.Size = new System.Drawing.Size(79, 81);
            this.upPanel.TabIndex = 5;
            // 
            // OrthographicCameraPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upPanel);
            this.Controls.Add(this.lookAtPanel);
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.farPanel);
            this.Controls.Add(this.nearPanel);
            this.Controls.Add(this.namePanel);
            this.MaximumSize = new System.Drawing.Size(0, 303);
            this.MinimumSize = new System.Drawing.Size(79, 303);
            this.Name = "OrthographicCameraPanel";
            this.Size = new System.Drawing.Size(79, 303);
            this.ResumeLayout(false);

        }

        #endregion

        private StringPanel namePanel;
        private FloatPanel nearPanel;
        private FloatPanel farPanel;
        private Vector3Panel locationPanel;
        private Vector3Panel lookAtPanel;
        private Vector3Panel upPanel;
    }
}
