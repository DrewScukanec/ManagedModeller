using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Triangle : Primitive {
        private Vector3d p1 = new Vector3d(1, 0, 0);
        private Vector3d p2 = new Vector3d(0, 1, 0);
        private Vector3d p3 = new Vector3d(0, 0, 1);

        public double getP1X() { return p1.X; }
        public double getP1Y() { return p1.Y; }
        public double getP1Z() { return p1.Z; }

        public double getP2X() { return p2.X; }
        public double getP2Y() { return p2.Y; }
        public double getP2Z() { return p2.Z; }

        public double getP3X() { return p3.X; }
        public double getP3Y() { return p3.Y; }
        public double getP3Z() { return p3.Z; }

        public void setP1(Vector3d v) {
            p1.X = v.X;
            p1.Y = v.Y;
            p1.Z = v.Z;
        }
        public void setP1(double x, double y, double z) {
            p1.X = x;
            p1.Y = y;
            p1.Z = z;
        }
        public void setP1X(double x) { p1.X = x; }
        public void setP1Z(double y) { p1.Y = y; }
        public void setP1Y(double z) { p1.Z = z; }

        public void setP2(Vector3d v) {
            p2.X = v.X;
            p2.Y = v.Y;
            p2.Z = v.Z;
        }
        public void setP2(double x, double y, double z) {
            p2.X = x;
            p2.Y = y;
            p2.Z = z;
        }
        public void setP2X(double x) { p2.X = x; }
        public void setP2Z(double y) { p2.Y = y; }
        public void setP2Y(double z) { p2.Z = z; }

        public void setP3(Vector3d v) {
            p3.X = v.X;
            p3.Y = v.Y;
            p3.Z = v.Z;
        }
        public void setP3(double x, double y, double z) {
            p3.X = x;
            p3.Y = y;
            p3.Z = z;
        }
        public void setP3X(double x) { p3.X = x; }
        public void setP3Z(double y) { p3.Y = y; }
        public void setP3Y(double z) { p3.Z = z; }

        public override void renderInternal() {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(p1);
            GL.Vertex3(p2);
            GL.Vertex3(p3);
            GL.End();
        }
    }
}
