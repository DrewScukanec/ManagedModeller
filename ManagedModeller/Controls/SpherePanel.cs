using OpenTK;
using ManagedModeller.Model;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class SpherePanel : UserControl, SceneElementPanel {

        private void OnNameUpdated(string name) {
            if (sphere != null) {
                sphere.Name = name;
            }
        }

        private void OnColorUpdated(Vector3 color) {
            if (sphere != null) {
                sphere.Color = color;
            }
        }

        private void OnTransformationUpdated(Transformation transformation) {
            if (sphere != null) {
                sphere.Transformation = transformation;
            }
        }

        private void OnMaxDepthUpdated(int maxDepth) {
            if (sphere != null) {
                sphere.MaxDepth = maxDepth;
            }
        }

        public SpherePanel() {
            InitializeComponent();
            namePanel.valueUpdated += OnNameUpdated;
            colorPanel.vector3Updated += OnColorUpdated;
            transformationPanel.transformationUpdated += OnTransformationUpdated;
            maxDepthPanel.valueUpdated += OnMaxDepthUpdated;
        }

        private Sphere sphere;

        public void SetSceneElement(SceneElement sceneElement) {
            if (sceneElement is Sphere) {
                SetSphere((Sphere)sceneElement);
            }
        }

        public void SetSphere(Sphere sphere) {
            this.sphere = sphere;
            this.sphere.primitiveUpdated += OnSphereUpdated;
            UpdateUIFromSphere();
        }

        private void UpdateUIFromSphere() {
            namePanel.Value = sphere.Name;
            colorPanel.Value = sphere.Color;
            transformationPanel.Value = sphere.Transformation;
            maxDepthPanel.Value = sphere.MaxDepth;
        }

        private void OnSphereUpdated(Primitive primitive) {
            UpdateUIFromSphere();
        }
    }
}
