using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class StringPanel : UserControl {
        public delegate void ValueUpdated(string newValue);

        public event ValueUpdated valueUpdated;

        public StringPanel() {
            InitializeComponent();
        }

        [Category("User"), Description("Specifies the value of the textbox")]
        public string Value {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        [Category("User"), Description("Specifies the label on the textbox")]
        public String Label {
            get { return label.Text; }
            set { label.Text = value; }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                NotifyListeners();
                e.Handled = true;
                e.SuppressKeyPress = true;
                ParentForm.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void textBox_Enter(object sender, EventArgs e) {
            textBox.SelectAll();
        }

        private void textBox_Leave(object sender, EventArgs e) {
            NotifyListeners();
        }

        private void NotifyListeners() {
            if (valueUpdated != null) {
                valueUpdated.Invoke(textBox.Text);
            }
        }
    }
}
