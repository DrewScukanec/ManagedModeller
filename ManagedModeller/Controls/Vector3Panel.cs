using OpenTK;
using System.ComponentModel;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class Vector3Panel : UserControl {

        public delegate void Vector3Updated(Vector3d newValue);

        public event Vector3Updated vector3Updated;

        public Vector3Panel() {
            InitializeComponent();
            xPanel.valueUpdated += ValueUpdated;
            yPanel.valueUpdated += ValueUpdated;
            zPanel.valueUpdated += ValueUpdated;
        }

        public Vector3d Value {
            get {
                return new Vector3d(xPanel.Value, yPanel.Value, zPanel.Value);
            }
            set {
                xPanel.Value = value.X;
                yPanel.Value = value.Y;
                zPanel.Value = value.Z;
            }
        }

        private void ValueUpdated(double newValue) {
            NotifyListeners();
        }

        private void NotifyListeners() {
            if (vector3Updated != null) {
                vector3Updated.Invoke(Value);
            }
        }

        [Category("User Properties"), Description("Specifies the text identifying the vector")]
        public string Label {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }
    }
}
