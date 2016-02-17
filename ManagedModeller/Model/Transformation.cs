using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Transformation {

        public static Transformation Translate(double x, double y, double z) {
            Transformation result = new Transformation();
            result.SetTranslation(x, y, z);
            return result;
        }

        public static Transformation Scale(double x, double y, double z) {
            Transformation result = new Transformation();
            result.SetScale(x, y, z);
            return result;
        }

        private Vector3d translation = new Vector3d();
        private Vector3d scale = new Vector3d(1, 1, 1);

        public Transformation() {}
        public Transformation(Transformation clone) {
            translation = new Vector3d(clone.translation);
            scale = new Vector3d(clone.scale);
        }

        public void GetTranslation(out Vector3d result) { result = new Vector3d(translation); }
        public Vector3d GetTranslation() { return new Vector3d(translation); }

        public void GetScale(out Vector3d result) { result = new Vector3d(scale); }
        public Vector3d GetScale() { return new Vector3d(scale); }

        public void SetScale(Vector3d v) {
            scale.X = v.X;
            scale.Y = v.Y;
            scale.Z = v.Z;
        }
        public void SetScale(double x, double y, double z) {
            scale.X = x;
            scale.Y = y;
            scale.Z = z;
        }

        public void SetTranslation(Vector3d v) {
            translation.X = v.X;
            translation.Y = v.Y;
            translation.Z = v.Z;
        }
        public void SetTranslation(double x, double y, double z) {
            translation.X = x;
            translation.Y = y;
            translation.Z = z;
        }

        public void ApplyMatrix() {
            GL.Translate(translation);
            GL.Scale(scale);
        }
    }
}
