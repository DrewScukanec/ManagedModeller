using System;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class TransformationPanel : UserControl {

        public delegate void TransformationUpdated(Transformation transformation);

        private Transformation transformation;
        public event TransformationUpdated transformationUpdated;

        public TransformationPanel() {
            InitializeComponent();
            translatePanel.vector3Updated += TranslationUpdated;
            scalePanel.vector3Updated += ScaleUpdated;
        }

        public void SetTransformation(Transformation transformation) {
            this.transformation = new Transformation(transformation);
            translatePanel.SetVector(transformation.GetTranslation());
            scalePanel.SetVector(transformation.GetScale());
        }

        private void TranslationUpdated(double x, double y, double z) {
            transformation.SetTranslation(x, y, z);
            NotifyListeners();
        }

        private void ScaleUpdated(double x, double y, double z) {
            transformation.SetScale(x, y, z);
            NotifyListeners();
        }

        private void NotifyListeners() {
            if (transformationUpdated != null) {
                transformationUpdated.Invoke(transformation);
            }
        }
    }
}
