using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Triangle : Primitive {

        #region P1
        private Vector3d p1 = new Vector3d(1, 0, 0);
        public Vector3d P1 {
            get { return new Vector3d(p1); }
            set { SetP1(value.X, value.Y, value.Z); }
        }
        public void GetP1(out Vector3d result) { result = new Vector3d(p1); }
        public void SetP1(double x, double y, double z) {
            p1.X = x;
            p1.Y = y;
            p1.Z = z;
            NotifyListeners();
        }
        #endregion

        #region P2
        private Vector3d p2 = new Vector3d(0, 1, 0);
        public Vector3d P2 {
            get { return new Vector3d(p2); }
            set { SetP2(value.X, value.Y, value.Z); }
        }
        public void GetP2(out Vector3d result) { result = new Vector3d(p2); }
        public void SetP2(double x, double y, double z) {
            p2.X = x;
            p2.Y = y;
            p2.Z = z;
            NotifyListeners();
        }
        #endregion

        #region P3
        private Vector3d p3 = new Vector3d(0, 0, 1);
        public Vector3d P3 {
            get { return new Vector3d(p3); }
            set { SetP3(value.X, value.Y, value.Z); }
        }
        public void GetP3(out Vector3d result) { result = new Vector3d(p3); }
        public void SetP3(double x, double y, double z) {
            p3.X = x;
            p3.Y = y;
            p3.Z = z;
            NotifyListeners();
        }
        #endregion

        #region Rendering
        public override void RenderInternal() {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(p1);
            GL.Vertex3(p2);
            GL.Vertex3(p3);
            GL.End();
        }
        #endregion
    }
}
