using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Transformation {
        private Vector3d translation = new Vector3d();
        private Vector3d scale = new Vector3d(1, 1, 1);

        public void setScale(Vector3d v) {
            scale.X = v.X;
            scale.Y = v.Y;
            scale.Z = v.Z;
        }
        public void setScale(double x, double y, double z) {
            scale.X = x;
            scale.Y = y;
            scale.Z = z;
        }
        public void setScaleX(double x) { scale.X = x; }
        public void setScaleY(double y) { scale.Y = y; }
        public void setScaleZ(double z) { scale.Z = z; }

        public double getScaleX() { return scale.X; }
        public double getScaleY() { return scale.Y; }
        public double getScaleZ() { return scale.Z; }

        public void setTranslation(Vector3d v) {
            translation.X = v.X;
            translation.Y = v.Y;
            translation.Z = v.Z;
        }
        public void setTranslation(double x, double y, double z) {
            translation.X = x;
            translation.Y = y;
            translation.Z = z;
        }
        public void setTranslationX(double x) { translation.X = x; }
        public void setTranslationY(double y) { translation.Y = y; }
        public void setTranslationZ(double z) { translation.Z = z; }

        public double getTranslationX() { return translation.X; }
        public double getTranslationY() { return translation.Y; }
        public double getTranslationZ() { return translation.Z; }

        public void applyMatrix() {
            GL.Translate(translation);
            GL.Scale(scale);
        }
    }
}
