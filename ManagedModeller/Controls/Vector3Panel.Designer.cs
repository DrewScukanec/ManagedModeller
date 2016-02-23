namespace ManagedModeller.Controls {
    partial class Vector3Panel {
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
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.xPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.zPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.yPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(69, 78);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // xPanel
            // 
            this.xPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel.Label = "X";
            this.xPanel.Location = new System.Drawing.Point(3, 3);
            this.xPanel.Name = "xPanel";
            this.xPanel.Size = new System.Drawing.Size(63, 19);
            this.xPanel.TabIndex = 6;
            this.xPanel.Value = 0D;
            // 
            // zPanel
            // 
            this.zPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zPanel.Label = "Z";
            this.zPanel.Location = new System.Drawing.Point(3, 53);
            this.zPanel.Name = "zPanel";
            this.zPanel.Size = new System.Drawing.Size(63, 22);
            this.zPanel.TabIndex = 8;
            this.zPanel.Value = 0D;
            // 
            // yPanel
            // 
            this.yPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yPanel.Label = "Y";
            this.yPanel.Location = new System.Drawing.Point(3, 28);
            this.yPanel.Name = "yPanel";
            this.yPanel.Size = new System.Drawing.Size(63, 19);
            this.yPanel.TabIndex = 7;
            this.yPanel.Value = 0D;
            // 
            // Vector3Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Vector3Panel";
            this.Size = new System.Drawing.Size(69, 78);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DoublePanel xPanel;
        private DoublePanel yPanel;
        private DoublePanel zPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
