using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class Sphere : Primitive {
        private static Vector3 top = new Vector3(0, 1, 0);
        private static Vector3 bottom = new Vector3(0, -1, 0);

        private static Vector3 right = new Vector3(1, 0, 0);
        private static Vector3 left = new Vector3(-1, 0, 0);

        private static Vector3 front = new Vector3(0, 0, 1);
        private static Vector3 back = new Vector3(0, 0, -1);

        private Vector3d center = new Vector3d();
        private double radius = 1.0;
        private int maxDepth = 3;

        public void setCenter(double x, double y, double z) { center.X = x; center.Y = y; center.Z = z; }
        public void setRadius(double radius) { this.radius = radius; }
        public void setMaxDepth(int maxDepth) { this.maxDepth = maxDepth; }

        public double getRadius() { return radius; }
        public double getX() { return center.X; }
        public double getY() { return center.Y; }
        public double getZ() { return center.Z; }

        public override void renderInternal() {
            GL.Begin(PrimitiveType.Triangles);

            recurse(right, back, top, 1);
            recurse(back, left, top, 1);
            recurse(left, front, top, 1);
            recurse(front, right, top, 1);

            recurse(right, front, bottom, 1);
            recurse(front, left, bottom, 1);
            recurse(left, back, bottom, 1);
            recurse(back, right, bottom, 1);

            GL.End();
        }

        private void recurse(Vector3 a, Vector3 b, Vector3 c, int depth) {
            if (depth == maxDepth) {
                GL.Vertex3(a);
                GL.Vertex3(b);
                GL.Vertex3(c);
                return;
            }

            Vector3 mid = a + b + c;
            mid.Normalize();

            recurse(a, b, mid, depth + 1);
            recurse(b, c, mid, depth + 1);
            recurse(c, a, mid, depth + 1);
        }
    }
}
