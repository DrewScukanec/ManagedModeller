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
    public partial class DoublePanel : UserControl {

        private const string FORMAT = "0.######";

        public delegate void ValueUpdated(double newValue);

        private double lastGoodValue;
        public event ValueUpdated valueUpdated;

        public DoublePanel() {
            InitializeComponent();
        }

        [Category("User"), Description("Specifies the value of the textbox")]
        public double Value {
            get {
                return Double.Parse(textBox.Text);
            }
            set {
                lastGoodValue = value;
                UpdateTextBoxFromLastGoodValue();
            }
        }

        [Category("User"), Description("Specifies the label on the textbox")]
        public String Label {
            get { return label.Text; }
            set { label.Text = value; }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                TryUpdateValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
                ParentForm.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void textBox_Enter(object sender, EventArgs e) {
            textBox.SelectAll();
        }

        private void textBox_Leave(object sender, EventArgs e) {
            TryUpdateValue();
        }

        private void TryUpdateValue() {
            double result = 0;
            bool success = Double.TryParse(textBox.Text, out result);
            if (success) {
                lastGoodValue = result;
                NotifyListeners();
            } else {
                UpdateTextBoxFromLastGoodValue();
            }
        }

        private void NotifyListeners() {
            if (valueUpdated != null) {
                valueUpdated.Invoke(lastGoodValue);
            }
        }

        private void UpdateTextBoxFromLastGoodValue() {
            textBox.Text = lastGoodValue.ToString(FORMAT);
        }
    }
}
