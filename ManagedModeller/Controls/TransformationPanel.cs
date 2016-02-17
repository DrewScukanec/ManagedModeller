using System;
using System.Windows.Forms;

namespace ManagedModeller.Controls {
    public partial class TransformationPanel : UserControl {

        public delegate void TransformationUpdated(Transformation transformation);

        private Transformation transformation;
        private event TransformationUpdated transformationUpdated;

        public TransformationPanel() {
            InitializeComponent();
            translatePanel.AddVector3Updated(new Vector3Panel.Vector3Updated(TranslationUpdated));
            scalePanel.AddVector3Updated(new Vector3Panel.Vector3Updated(ScaleUpdated));
        }

        public void AddTransformationUpdated(TransformationUpdated callback) {
            transformationUpdated += callback;
        }

        public void RemoveTransformationUpdated(TransformationUpdated callback) {
            transformationUpdated -= callback;
        }

        public void SetTransformation(Transformation transformation) {
            this.transformation = new Transformation(transformation);
        }

        private void translateLabel_DoubleClick(object sender, EventArgs e) {
            if (translatePanel.Visible) {
                translatePanel.Hide();
            } else {
                translatePanel.Show();
            }
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
