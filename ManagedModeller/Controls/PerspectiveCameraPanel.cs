using ManagedModeller.Model;
using OpenTK;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class PerspectiveCameraPanel : UserControl {
        private void OnNameUpdated(string value) {
            if (camera != null) {
                camera.Name = value;
            }
        }

        private void OnNearUpdated(float value) {
            if (camera != null) {
                camera.Near = value;
            }
        }

        private void OnFarUpdated(float value) {
            if (camera != null) {
                camera.Far = value;
            }
        }

        private void OnFovyUpdated(float value) {
            if (camera != null) {
                camera.FovY = value;
            }
        }

        private void OnLocationUpdated(Vector3 value) {
            if (camera != null) {
                camera.Location = value;
            }
        }

        private void OnLookAtUpdated(Vector3 value) {
            if (camera != null) {
                camera.LookAt = value;
            }
        }

        private void OnUpUpdated(Vector3 value) {
            if (camera != null) {
                camera.Up = value;
            }
        }

        public PerspectiveCameraPanel() {
            InitializeComponent();
            namePanel.valueUpdated += OnNameUpdated;
            nearPanel.valueUpdated += OnNearUpdated;
            farPanel.valueUpdated += OnFarUpdated;
            fovyPanel.valueUpdated += OnFovyUpdated;
            locationPanel.vector3Updated += OnLocationUpdated;
            lookAtPanel.vector3Updated += OnLookAtUpdated;
            upPanel.vector3Updated += OnUpUpdated;
        }

        private PerspectiveCamera camera;

        public void SetCamera(PerspectiveCamera camera) {
            this.camera = camera;
            camera.cameraUpdated += OnCameraUpdated;
            UpdateUIFromCamera();
        }

        private void UpdateUIFromCamera() {
            namePanel.Value = camera.Name;
            nearPanel.Value = camera.Near;
            fovyPanel.Value = camera.FovY;
            farPanel.Value = camera.Far;
            locationPanel.Value = camera.Location;
            lookAtPanel.Value = camera.LookAt;
            upPanel.Value = camera.Up;
        }

        private void OnCameraUpdated(Camera camera) {
            UpdateUIFromCamera();
        }
    }
}
