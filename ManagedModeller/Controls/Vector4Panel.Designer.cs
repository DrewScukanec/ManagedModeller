namespace ManagedModeller.Controls {
    partial class Vector4Panel {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xPanel = new ManagedModeller.Controls.DoublePanel();
            this.zPanel = new ManagedModeller.Controls.DoublePanel();
            this.yPanel = new ManagedModeller.Controls.DoublePanel();
            this.wPanel = new ManagedModeller.Controls.DoublePanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.wPanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.xPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.zPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.yPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(82, 104);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // xPanel
            // 
            this.xPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel.Label = "X";
            this.xPanel.Location = new System.Drawing.Point(3, 3);
            this.xPanel.Name = "xPanel";
            this.xPanel.Size = new System.Drawing.Size(76, 20);
            this.xPanel.TabIndex = 6;
            this.xPanel.Value = 0D;
            // 
            // zPanel
            // 
            this.zPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zPanel.Label = "Z";
            this.zPanel.Location = new System.Drawing.Point(3, 55);
            this.zPanel.Name = "zPanel";
            this.zPanel.Size = new System.Drawing.Size(76, 20);
            this.zPanel.TabIndex = 8;
            this.zPanel.Value = 0D;
            // 
            // yPanel
            // 
            this.yPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yPanel.Label = "Y";
            this.yPanel.Location = new System.Drawing.Point(3, 29);
            this.yPanel.Name = "yPanel";
            this.yPanel.Size = new System.Drawing.Size(76, 20);
            this.yPanel.TabIndex = 7;
            this.yPanel.Value = 0D;
            // 
            // wPanel
            // 
            this.wPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wPanel.Label = "W";
            this.wPanel.Location = new System.Drawing.Point(3, 81);
            this.wPanel.Name = "wPanel";
            this.wPanel.Size = new System.Drawing.Size(76, 20);
            this.wPanel.TabIndex = 9;
            this.wPanel.Value = 0D;
            // 
            // Vector4Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Vector4Panel";
            this.Size = new System.Drawing.Size(82, 104);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DoublePanel wPanel;
        private DoublePanel xPanel;
        private DoublePanel zPanel;
        private DoublePanel yPanel;
    }
}
