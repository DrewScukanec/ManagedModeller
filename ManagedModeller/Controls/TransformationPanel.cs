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
            translatePanel.vector3dUpdated += OnTranslationUpdated;
            scalePanel.vector3dUpdated += OnScaleUpdated;
        }

        public Transformation Value {
            get { return new Transformation(transformation); }
            set {
                transformation = new Transformation(value);
                translatePanel.Value = transformation.Translation;
                scalePanel.Value = transformation.Scale;
            }
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
