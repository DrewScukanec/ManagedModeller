namespace ManagedModeller.Controls {
    partial class Vector3dPanel {
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.xPanel = new ManagedModeller.Controls.DoublePanel();
            this.yPanel = new ManagedModeller.Controls.DoublePanel();
            this.zPanel = new ManagedModeller.Controls.DoublePanel();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.zPanel);
            this.groupBox.Controls.Add(this.yPanel);
            this.groupBox.Controls.Add(this.xPanel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.MaximumSize = new System.Drawing.Size(0, 81);
            this.groupBox.MinimumSize = new System.Drawing.Size(70, 81);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(70, 81);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Group";
            // 
            // xPanel
            // 
            this.xPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel.Label = "X";
            this.xPanel.Location = new System.Drawing.Point(3, 16);
            this.xPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.xPanel.MinimumSize = new System.Drawing.Size(55, 20);
            this.xPanel.Name = "xPanel";
            this.xPanel.Size = new System.Drawing.Size(64, 20);
            this.xPanel.TabIndex = 1;
            this.xPanel.Value = 0D;
            // 
            // yPanel
            // 
            this.yPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.yPanel.Label = "Y";
            this.yPanel.Location = new System.Drawing.Point(3, 36);
            this.yPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.yPanel.MinimumSize = new System.Drawing.Size(55, 20);
            this.yPanel.Name = "yPanel";
            this.yPanel.Size = new System.Drawing.Size(64, 20);
            this.yPanel.TabIndex = 2;
            this.yPanel.Value = 0D;
            // 
            // zPanel
            // 
            this.zPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.zPanel.Label = "Z";
            this.zPanel.Location = new System.Drawing.Point(3, 56);
            this.zPanel.MaximumSize = new System.Drawing.Size(0, 20);
            this.zPanel.MinimumSize = new System.Drawing.Size(55, 20);
            this.zPanel.Name = "zPanel";
            this.zPanel.Size = new System.Drawing.Size(64, 20);
            this.zPanel.TabIndex = 3;
            this.zPanel.Value = 0D;
            // 
            // Vector3dPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.MaximumSize = new System.Drawing.Size(0, 81);
            this.MinimumSize = new System.Drawing.Size(70, 81);
            this.Name = "Vector3dPanel";
            this.Size = new System.Drawing.Size(70, 81);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private DoublePanel xPanel;
        private DoublePanel yPanel;
        private DoublePanel zPanel;
    }
}
