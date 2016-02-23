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
            this.translateGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scalePanel = new ManagedModeller.Controls.Vector3Panel();
            this.translatePanel = new ManagedModeller.Controls.Vector3Panel();
            this.translateGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translateGroupBox
            // 
            this.translateGroupBox.AutoSize = true;
            this.translateGroupBox.Controls.Add(this.translatePanel);
            this.translateGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.translateGroupBox.Location = new System.Drawing.Point(0, 0);
            this.translateGroupBox.MaximumSize = new System.Drawing.Size(0, 97);
            this.translateGroupBox.MinimumSize = new System.Drawing.Size(87, 97);
            this.translateGroupBox.Name = "translateGroupBox";
            this.translateGroupBox.Size = new System.Drawing.Size(87, 97);
            this.translateGroupBox.TabIndex = 4;
            this.translateGroupBox.TabStop = false;
            this.translateGroupBox.Text = "Translation";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.scalePanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 97);
            this.groupBox1.MaximumSize = new System.Drawing.Size(0, 97);
            this.groupBox1.MinimumSize = new System.Drawing.Size(87, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale";
            // 
            // scalePanel
            // 
            this.scalePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.scalePanel.Location = new System.Drawing.Point(3, 16);
            this.scalePanel.MaximumSize = new System.Drawing.Size(0, 78);
            this.scalePanel.MinimumSize = new System.Drawing.Size(80, 78);
            this.scalePanel.Name = "scalePanel";
            this.scalePanel.Size = new System.Drawing.Size(81, 78);
            this.scalePanel.TabIndex = 0;
            this.scalePanel.Value = ((OpenTK.Vector3d)(resources.GetObject("scalePanel.Value")));
            // 
            // translatePanel
            // 
            this.translatePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.translatePanel.Location = new System.Drawing.Point(3, 16);
            this.translatePanel.MaximumSize = new System.Drawing.Size(0, 78);
            this.translatePanel.MinimumSize = new System.Drawing.Size(80, 78);
            this.translatePanel.Name = "translatePanel";
            this.translatePanel.Size = new System.Drawing.Size(81, 78);
            this.translatePanel.TabIndex = 1;
            this.translatePanel.Value = ((OpenTK.Vector3d)(resources.GetObject("translatePanel.Value")));
            // 
            // TransformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.translateGroupBox);
            this.MinimumSize = new System.Drawing.Size(87, 194);
            this.Name = "TransformationPanel";
            this.Size = new System.Drawing.Size(87, 194);
            this.translateGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vector3Panel scalePanel;
        private Vector3Panel translatePanel;
        private System.Windows.Forms.GroupBox translateGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
