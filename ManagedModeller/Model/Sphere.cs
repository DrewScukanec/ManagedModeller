using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Sphere : Primitive {

        #region Static
        private static Vector3 TOP = new Vector3(0, 1, 0);
        private static Vector3 BOTTOM = new Vector3(0, -1, 0);

        private static Vector3 RIGHT = new Vector3(1, 0, 0);
        private static Vector3 LEFT = new Vector3(-1, 0, 0);

        private static Vector3 FRONT = new Vector3(0, 0, 1);
        private static Vector3 BACK = new Vector3(0, 0, -1);
        #endregion

        #region Center
        private Vector3d center = new Vector3d();
        public Vector3d Center {
            get { return new Vector3d(center); }
            set { SetCenter(value.X, value.Y, value.Z); }
        }
        public void GetCenter(out Vector3d result) { result = new Vector3d(center); }
        public void SetCenter(double x, double y, double z) {
            center.X = x;
            center.Y = y;
            center.Z = z;
            NotifyListeners();
        }
        #endregion

        #region Radius
        private double radius = 1.0;
        public double Radius {
            get { return radius; }
            set {
                radius = value;
                NotifyListeners();
            }
        }
        #endregion

        #region MaxDepth
        private int maxDepth = 4;
        public int MaxDepth {
            get { return maxDepth; }
            set {
                maxDepth = value;
                NotifyListeners();
            }
        }
        #endregion

        #region Rendering
        public override void RenderInternal() {
            GL.Begin(PrimitiveType.Triangles);

            Recurse(RIGHT, BACK, TOP, 1);
            Recurse(BACK, LEFT, TOP, 1);
            Recurse(LEFT, FRONT, TOP, 1);
            Recurse(FRONT, RIGHT, TOP, 1);

            Recurse(RIGHT, FRONT, BOTTOM, 1);
            Recurse(FRONT, LEFT, BOTTOM, 1);
            Recurse(LEFT, BACK, BOTTOM, 1);
            Recurse(BACK, RIGHT, BOTTOM, 1);

            GL.End();
        }

        private void Recurse(Vector3 a, Vector3 b, Vector3 c, int depth) {
            if (depth == maxDepth) {
                GL.Vertex3(a);
                GL.Vertex3(b);
                GL.Vertex3(c);
                return;
            }

            Vector3 midAtoB = a + b;
            midAtoB.Normalize();
            Vector3 midBtoC = b + c;
            midBtoC.Normalize();
            Vector3 midCtoA = c + a;
            midCtoA.Normalize();

            Recurse(midCtoA, a, midAtoB, depth + 1);
            Recurse(midAtoB, b, midBtoC, depth + 1);
            Recurse(midBtoC, c, midCtoA, depth + 1);
            Recurse(midAtoB, midBtoC, midCtoA, depth + 1);
        }
        #endregion
    }
}
