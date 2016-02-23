﻿using OpenTK;
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
            translatePanel.Value = transformation.GetTranslation();
            scalePanel.Value = transformation.GetScale();
        }

        private void TranslationUpdated(Vector3d newValue) {
            transformation.SetTranslation(newValue);
            NotifyListeners();
        }

        private void ScaleUpdated(Vector3d newValue) {
            transformation.SetScale(newValue);
            NotifyListeners();
        }

        private void NotifyListeners() {
            if (transformationUpdated != null) {
                transformationUpdated.Invoke(transformation);
            }
        }
    }
}
