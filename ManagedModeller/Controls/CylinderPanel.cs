using ManagedModeller.Model;
using OpenTK;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class CylinderPanel : UserControl, SceneElementPanel {

        private void OnNameUpdated(string name) {
            if (cylinder != null) {
                cylinder.Name = name;
            }
        }

        private void OnColorUpdated(Vector3 color) {
            if (cylinder != null) {
                cylinder.Color = color;
            }
        }

        private void OnTransformationUpdated(Transformation transformation) {
            if (cylinder != null) {
                cylinder.Transformation = transformation;
            }
        }

        private void OnDivisionsUpdated(int divisions) {
            if (cylinder != null) {
                cylinder.Divisions = divisions;
            }
        }

        public CylinderPanel() {
            InitializeComponent();
            namePanel.valueUpdated += OnNameUpdated;
            colorPanel.vector3Updated += OnColorUpdated;
            transformationPanel.transformationUpdated += OnTransformationUpdated;
            divisionPanel.valueUpdated += OnDivisionsUpdated;
        }

        private Cylinder cylinder;

        public void SetSceneElement(SceneElement sceneElement) {
            if (sceneElement is Cylinder) {
                SetCylinder((Cylinder)sceneElement);
            }
        }

        public void SetCylinder(Cylinder cylinder) {
            this.cylinder = cylinder;
            this.cylinder.primitiveUpdated += OnCylinderUpdated;
            UpdateUIFromSphere();
        }

        private void UpdateUIFromSphere() {
            namePanel.Value = cylinder.Name;
            colorPanel.Value = cylinder.Color;
            transformationPanel.Value = cylinder.Transformation;
            divisionPanel.Value = cylinder.Divisions;
        }

        private void OnCylinderUpdated(Primitive primitive) {
            UpdateUIFromSphere();
        }
    }
}
