using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Triangle : Primitive {
        private Vector3d p1 = new Vector3d(1, 0, 0);
        private Vector3d p2 = new Vector3d(0, 1, 0);
        private Vector3d p3 = new Vector3d(0, 0, 1);

        public void GetP1(out Vector3d result) { result = new Vector3d(p1); }
        public Vector3d GetP1() { return new Vector3d(p1); }

        public void GetP2(out Vector3d result) { result = new Vector3d(p2); }
        public Vector3d GetP2() { return new Vector3d(p2); }

        public void GetP3(out Vector3d result) { result = new Vector3d(p3); }
        public Vector3d GetP3() { return new Vector3d(p3); }

        public void SetP1(Vector3d v) {
            p1.X = v.X;
            p1.Y = v.Y;
            p1.Z = v.Z;
        }
        public void SetP1(double x, double y, double z) {
            p1.X = x;
            p1.Y = y;
            p1.Z = z;
        }

        public void SetP2(Vector3d v) {
            p2.X = v.X;
            p2.Y = v.Y;
            p2.Z = v.Z;
        }
        public void SetP2(double x, double y, double z) {
            p2.X = x;
            p2.Y = y;
            p2.Z = z;
        }

        public void SetP3(Vector3d v) {
            p3.X = v.X;
            p3.Y = v.Y;
            p3.Z = v.Z;
        }
        public void SetP3(double x, double y, double z) {
            p3.X = x;
            p3.Y = y;
            p3.Z = z;
        }

        public override void RenderInternal() {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(p1);
            GL.Vertex3(p2);
            GL.Vertex3(p3);
            GL.End();
        }
    }
}
