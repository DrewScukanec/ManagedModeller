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
            this.translateLabel = new System.Windows.Forms.Label();
            this.scalePanel = new ManagedModeller.Controls.Vector3Panel();
            this.translatePanel = new ManagedModeller.Controls.Vector3Panel();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // translateLabel
            // 
            this.translateLabel.AutoSize = true;
            this.translateLabel.Location = new System.Drawing.Point(0, 0);
            this.translateLabel.Name = "translateLabel";
            this.translateLabel.Size = new System.Drawing.Size(59, 13);
            this.translateLabel.TabIndex = 2;
            this.translateLabel.Text = "Translation";
            // 
            // scalePanel
            // 
            this.scalePanel.Location = new System.Drawing.Point(3, 113);
            this.scalePanel.Name = "scalePanel";
            this.scalePanel.Size = new System.Drawing.Size(161, 78);
            this.scalePanel.TabIndex = 0;
            // 
            // translatePanel
            // 
            this.translatePanel.Location = new System.Drawing.Point(3, 16);
            this.translatePanel.Name = "translatePanel";
            this.translatePanel.Size = new System.Drawing.Size(161, 78);
            this.translatePanel.TabIndex = 1;
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(0, 97);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(34, 13);
            this.scaleLabel.TabIndex = 3;
            this.scaleLabel.Text = "Scale";
            // 
            // TransformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleLabel);
            this.Controls.Add(this.translateLabel);
            this.Controls.Add(this.translatePanel);
            this.Controls.Add(this.scalePanel);
            this.Name = "TransformationPanel";
            this.Size = new System.Drawing.Size(167, 194);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vector3Panel scalePanel;
        private Vector3Panel translatePanel;
        private System.Windows.Forms.Label translateLabel;
        private System.Windows.Forms.Label scaleLabel;
    }
}
