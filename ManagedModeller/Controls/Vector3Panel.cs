using OpenTK;
using System;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class Vector3Panel : UserControl {

        private const string FORMAT = "0.######";

        public delegate void Vector3Updated(double x, double y, double z);

        private Vector3d lastGoodVector;
        private event Vector3Updated vector3Updated;

        public Vector3Panel() {
            InitializeComponent();
        }

        public void SetVector(Vector3d vector) {
            lastGoodVector = new Vector3d(vector);
            UpdateTextBoxesFromVector();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                TryUpdateVector();
            }
        }

        private void textBox_Leave(object sender, EventArgs e) {
            TryUpdateVector();
        }

        private void TryUpdateVector() {
            double x = 0;
            double y = 0;
            double z = 0;
            bool success = true;
            success = success && Double.TryParse(textBox1.Text, out x);
            success = success && Double.TryParse(textBox2.Text, out y);
            success = success && Double.TryParse(textBox3.Text, out z);
            if (success) {
                lastGoodVector.X = x;
                lastGoodVector.Y = y;
                lastGoodVector.Z = z;
                NotifyListeners();
            } else {
                UpdateTextBoxesFromVector();
            }
        }

        private void NotifyListeners() {
            if (vector3Updated != null) {
                vector3Updated.Invoke(lastGoodVector.X, lastGoodVector.Y, lastGoodVector.Z);
            }
        }

        private void UpdateTextBoxesFromVector() {
            textBox1.Text = lastGoodVector.X.ToString(FORMAT);
            textBox2.Text = lastGoodVector.Y.ToString(FORMAT);
            textBox3.Text = lastGoodVector.Z.ToString(FORMAT);
        }
    }
}
