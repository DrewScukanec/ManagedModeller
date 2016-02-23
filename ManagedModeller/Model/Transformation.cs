using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Transformation {

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

        public Transformation() {}
        public Transformation(Transformation clone) {
            translation = new Vector3d(clone.translation);
            scale = new Vector3d(clone.scale);
        }

        private Vector3d translation = new Vector3d();
        public Vector3d Translation {
            get {
                return new Vector3d(translation);
            }

            set {
                translation.X = value.X;
                translation.Y = value.Y;
                translation.Z = value.Z;
            }
        }

        public void GetTranslation(out Vector3d result) { result = new Vector3d(translation); }
        public void SetTranslation(double x, double y, double z) {
            translation.X = x;
            translation.Y = y;
            translation.Z = z;
        }

        private Vector3d scale = new Vector3d(1, 1, 1);
        public Vector3d Scale {
            get {
                return new Vector3d(scale);
            }

            set {
                scale.X = value.X;
                scale.Y = value.Y;
                scale.Z = value.Z;
            }
        }

        public void GetScale(out Vector3d result) { result = new Vector3d(scale); }
        public void SetScale(double x, double y, double z) {
            scale.X = x;
            scale.Y = y;
            scale.Z = z;
        }

        private Quaterniond rotation = new Quaterniond();
        public Quaterniond Rotation {
            get {
                return new Quaterniond(rotation.X, rotation.Y, rotation.Z, rotation.W);
            }

            set {
                rotation.X = value.X;
                rotation.Y = value.Y;
                rotation.Z = value.Z;
                rotation.W = value.W;
            }
        }

        public void GetRotation(out Quaterniond result) { result = new Quaterniond(rotation.X, rotation.Y, rotation.Z, rotation.W); }
        public void SetRotation(double x, double y, double z, double w) {
            rotation.X = x;
            rotation.Y = y;
            rotation.Z = z;
            rotation.W = w;
        }

        public void ApplyMatrix() {
            GL.Translate(translation);
            GL.Scale(scale);
        }
    }
}
