using ManagedModeller.Model;
using OpenTK;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class OrthographicCameraPanel : UserControl, SceneElementPanel {

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

        public void SetSceneElement(SceneElement sceneElement) {
            if (sceneElement is OrthographicCamera) {
                SetCamera((OrthographicCamera)sceneElement);
            }
        }

        public void SetCamera(OrthographicCamera camera) {
            this.camera = camera;
            this.camera.cameraUpdated += OnCameraUpdated;
            UpdateUIFromCamera();
        }

        private void UpdateUIFromCamera() {
            namePanel.Value = camera.Name;
            nearPanel.Value = camera.Near;
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
