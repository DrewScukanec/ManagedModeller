using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller.Model {
    public class Transformation {

        #region Static
        public static Transformation TranslateBy(double x, double y, double z) {
            Transformation result = new Transformation();
            result.SetTranslation(x, y, z);
            return result;
        }

        public static Transformation ScaleBy(double x, double y, double z) {
            Transformation result = new Transformation();
            result.SetScale(x, y, z);
            return result;
        }
        #endregion

        #region Event handling
        public delegate void TransformationUpdated(Transformation transformation);
        public event TransformationUpdated transformationUpdated;

        protected void NotifyListeners() {
            if (transformationUpdated != null) {
                transformationUpdated.Invoke(this);
            }
        }
        #endregion

        public Transformation() {}
        public Transformation(Transformation clone) {
            translation = new Vector3d(clone.translation);
            scale = new Vector3d(clone.scale);
        }

        #region Translation
        private Vector3d translation = new Vector3d();
        public Vector3d Translation {
            get { return new Vector3d(translation); }
            set { SetTranslation(value.X, value.Y, value.Z); }
        }
        public void GetTranslation(out Vector3d result) { result = new Vector3d(translation); }
        public void SetTranslation(double x, double y, double z) {
            translation.X = x;
            translation.Y = y;
            translation.Z = z;
            transposeInverseDirty = true;
            NotifyListeners();
        }
        #endregion

        #region Scale
        private Vector3d scale = new Vector3d(1, 1, 1);
        public Vector3d Scale {
            get { return new Vector3d(scale); }
            set { SetScale(value.X, value.Y, value.Z); }
        }
        public void GetScale(out Vector3d result) { result = new Vector3d(scale); }
        public void SetScale(double x, double y, double z) {
            scale.X = x;
            scale.Y = y;
            scale.Z = z;
            transposeInverseDirty = true;
            NotifyListeners();
        }
        #endregion

        #region Rotation
        private Quaterniond rotation = new Quaterniond();
        public Quaterniond Rotation {
            get { return new Quaterniond(rotation.X, rotation.Y, rotation.Z, rotation.W); }
            set { SetRotation(value.X, value.Y, value.Z, value.W); }
        }
        public void GetRotation(out Quaterniond result) { result = new Quaterniond(rotation.X, rotation.Y, rotation.Z, rotation.W); }
        public void SetRotation(double x, double y, double z, double w) {
            rotation.X = x;
            rotation.Y = y;
            rotation.Z = z;
            rotation.W = w;
            transposeInverseDirty = true;
            NotifyListeners();
        }
        #endregion

        #region Rendering
        public void ApplyMatrix() {
            GL.Translate(translation);
            // TODO: Apply rotation
            GL.Scale(scale);
        }

        private bool transposeInverseDirty = true;
        private Matrix4d transposeInverse;
        public Matrix4d GetTransposeInverse() {
            UpdateTransposeInverse();
            return transposeInverse;
        }
        private void UpdateTransposeInverse() {
            if (!transposeInverseDirty) {
                return;
            }
            transposeInverseDirty = false;
            transposeInverse = Matrix4d.Scale(scale);
            // TODO: Apply rotation
            transposeInverse = Matrix4d.Mult(Matrix4d.CreateTranslation(translation), transposeInverse);
            transposeInverse.Invert();
            transposeInverse.Transpose();
        }
        #endregion
    }
}
