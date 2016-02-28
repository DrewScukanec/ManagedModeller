using OpenTK;
using System.ComponentModel;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class Vector4Panel : UserControl {

        public delegate void Vector4Updated(Vector4d newValue);

        public event Vector4Updated vector4Updated;

        public Vector4Panel() {
            InitializeComponent();
            xPanel.valueUpdated += ValueUpdated;
            yPanel.valueUpdated += ValueUpdated;
            zPanel.valueUpdated += ValueUpdated;
            wPanel.valueUpdated += ValueUpdated;
        }

        public Vector4d Value {
            get {
                return new Vector4d(xPanel.Value, yPanel.Value, zPanel.Value, wPanel.Value);
            }
            set {
                xPanel.Value = value.X;
                yPanel.Value = value.Y;
                zPanel.Value = value.Z;
                wPanel.Value = value.W;
            }
        }

        private void ValueUpdated(double newValue) {
            NotifyListeners();
        }

        private void NotifyListeners() {
            if (vector4Updated != null) {
                vector4Updated.Invoke(Value);
            }
        }

        [Category("User Properties"), Description("Specifies the text identifying the vector")]
        public string Label {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }
    }
}
