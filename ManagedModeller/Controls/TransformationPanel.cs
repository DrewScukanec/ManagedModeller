using ManagedModeller.Model;
using OpenTK;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class TransformationPanel : UserControl {

        public delegate void TransformationUpdated(Transformation transformation);
        public event TransformationUpdated transformationUpdated;

        private Transformation transformation;

        public TransformationPanel() {
            InitializeComponent();
            scalePanel.vector3dUpdated += OnTranslationUpdated;
            translatePanel.vector3dUpdated += OnScaleUpdated;
        }

        public void SetTransformation(Transformation transformation) {
            this.transformation = new Transformation(transformation);
            scalePanel.Value = transformation.Translation;
            translatePanel.Value = transformation.Scale;
        }

        private void OnTranslationUpdated(Vector3d newValue) {
            transformation.Translation = newValue;
            NotifyTransformationUpdated();
        }

        private void OnScaleUpdated(Vector3d newValue) {
            transformation.Scale = newValue;
            NotifyTransformationUpdated();
        }

        private void NotifyTransformationUpdated() {
            if (transformationUpdated != null) {
                transformationUpdated.Invoke(transformation);
            }
        }
    }
}
