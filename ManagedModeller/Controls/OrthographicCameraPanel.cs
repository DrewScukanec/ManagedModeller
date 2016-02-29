using ManagedModeller.Model;
using OpenTK;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class OrthographicCameraPanel : UserControl {

        private void OnNameUpdated(string value) {
            camera.Name = value;
        }

        private void OnNearUpdated(float value) {
            camera.Near = value;
        }

        private void OnFarUpdated(float value) {
            camera.Far = value;
        }

        private void OnLocationUpdated(Vector3 value) {
            camera.Location = value;
        }

        private void OnLookAtUpdated(Vector3 value) {
            camera.LookAt = value;
        }

        private void OnUpUpdated(Vector3 value) {
            camera.Up = value;
        }

        public OrthographicCameraPanel() {
            InitializeComponent();
            namePanel.valueUpdated += OnNameUpdated;
            nearPanel.valueUpdated += OnNearUpdated;
            farPanel.valueUpdated += OnFarUpdated;
            locationPanel.vector3Updated += OnLocationUpdated;
            lookAtPanel.vector3Updated += OnLookAtUpdated;
            upPanel.vector3Updated += OnUpUpdated;
        }

        private OrthographicCamera camera;

        private void UpdateFromValue() {
            namePanel.Value = camera.Name;
            nearPanel.Value = camera.Near;
            farPanel.Value = camera.Far;
            locationPanel.Value = camera.Location;
            lookAtPanel.Value = camera.LookAt;
            upPanel.Value = camera.Up;
        }
    }
}
