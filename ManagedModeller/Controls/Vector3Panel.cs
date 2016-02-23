using OpenTK;
using System;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class Vector3Panel : UserControl {

        public delegate void Vector3Updated(double x, double y, double z);

        public event Vector3Updated vector3Updated;

        public Vector3Panel() {
            InitializeComponent();
            xPanel.valueUpdated += ValueUpdated;
            yPanel.valueUpdated += ValueUpdated;
            zPanel.valueUpdated += ValueUpdated;
        }

        public void SetVector(Vector3d vector) {
            xPanel.Value = vector.X;
            yPanel.Value = vector.Y;
            zPanel.Value = vector.Z;
        }

        private void ValueUpdated(double newValue) {
            NotifyListeners();
        }

        private void NotifyListeners() {
            if (vector3Updated != null) {
                double x = xPanel.Value;
                double y = yPanel.Value;
                double z = zPanel.Value;

                vector3Updated.Invoke(x, y, z);
            }
        }
    }
}
