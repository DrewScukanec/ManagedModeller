using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller.Model {
    public class Sphere : Primitive {

        #region Static
        private static Vector3d TOP = new Vector3d(0, 1, 0);
        private static Vector3d BOTTOM = new Vector3d(0, -1, 0);

        private static Vector3d RIGHT = new Vector3d(1, 0, 0);
        private static Vector3d LEFT = new Vector3d(-1, 0, 0);

        private static Vector3d FRONT = new Vector3d(0, 0, 1);
        private static Vector3d BACK = new Vector3d(0, 0, -1);
        #endregion

        #region MaxDepth
        private int maxDepth = 5;
        public int MaxDepth {
            get { return maxDepth; }
            set {
                maxDepth = value;
                NotifyPrimitiveUpdated();
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

        private void Recurse(Vector3d a, Vector3d b, Vector3d c, int depth) {
            if (depth == maxDepth) {
                Matrix4d ti = transformation.GetTransposeInverse();
                Vector3d normal;

                Vector3d.TransformNormal(ref a, ref ti, out normal);
                GL.Normal3(normal);
                GL.Vertex3(a);

                Vector3d.TransformNormal(ref b, ref ti, out normal);
                GL.Normal3(normal);
                GL.Vertex3(b);

                Vector3d.TransformNormal(ref c, ref ti, out normal);
                GL.Normal3(normal);
                GL.Vertex3(c);
                return;
            }

            Vector3d midAtoB = a + b;
            midAtoB.Normalize();
            Vector3d midBtoC = b + c;
            midBtoC.Normalize();
            Vector3d midCtoA = c + a;
            midCtoA.Normalize();

            Recurse(midCtoA, a, midAtoB, depth + 1);
            Recurse(midAtoB, b, midBtoC, depth + 1);
            Recurse(midBtoC, c, midCtoA, depth + 1);
            Recurse(midAtoB, midBtoC, midCtoA, depth + 1);
        }
        #endregion
    }
}
