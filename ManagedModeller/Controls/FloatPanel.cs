using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class FloatPanel : UserControl {

        private const string FORMAT = "0.######";

        public delegate void ValueUpdated(float newValue);

        private float lastGoodValue;
        public event ValueUpdated valueUpdated;

        public FloatPanel() {
            InitializeComponent();
        }

        [Category("User"), Description("Specifies the value of the textbox")]
        public float Value {
            get {
                return Single.Parse(textBox.Text);
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
            }
        }

        private void textBox_Enter(object sender, EventArgs e) {
            textBox.SelectAll();
        }

        private void textBox_Leave(object sender, EventArgs e) {
            TryUpdateValue();
        }

        private void TryUpdateValue() {
            float result = 0;
            bool success = Single.TryParse(textBox.Text, out result);
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
