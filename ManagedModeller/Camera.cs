using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ManagedModeller {
    public abstract class Camera {

        private const float ANGLE_SCALE = 2;

        private static Vector3 X_AXIS = new Vector3(1, 0, 0);
        private static Vector3 Y_AXIS = new Vector3(0, 1, 0);
        private static Vector3 Z_AXIS = new Vector3(0, 0, 1);

        protected int width;
        protected int height;
        protected PolygonMode polygonMode = PolygonMode.Fill;
        protected Vector3 location = new Vector3();
        protected Vector3 eyeDirection = new Vector3();
        protected Vector3 up = new Vector3();
        protected Vector3 right = new Vector3();
        protected float rotation = 0;
        protected float zoom = 1;

        public int GetWidth() { return width; }
        public void SetWidth(int width) { this.width = width; }

        public int GetHeight() { return height; }
        public void SetHeight(int height) { this.height = height; }

        public PolygonMode GetPolygonMode() { return PolygonMode.Fill; }
        public void SetPolygonMode(PolygonMode polygonMode) { this.polygonMode = polygonMode; }

        public Vector3 GetLocation() { return new Vector3(location); }
        public void SetLocation(Vector3 location) {
            this.location.X = location.X;
            this.location.Y = location.Y;
            this.location.Z = location.Z;
        }

        public void SetBasis(Vector3 eyeDirection, Vector3 up) {
            this.eyeDirection = new Vector3(eyeDirection);
            this.up = new Vector3(up);
            this.right = Vector3.Cross(eyeDirection, up);

            this.up.Normalize();
            this.right.Normalize();
            this.eyeDirection.Normalize();
        }

        public float GetRotation() { return rotation; }
        public void SetRotation(float rotation) { this.rotation = rotation; }

        public float GetZoom() { return zoom; }
        public void SetZoom(float zoom) { this.zoom = zoom; }

        public void Shift(Vector2 offset) {
            Vector3 threeDOffset = right * offset.X + up * offset.Y;
            location -= threeDOffset;
        }

        public abstract void SetProjectionMatrix();

        public void SetModelViewMatrix() {
            GL.PolygonMode(MaterialFace.Front, polygonMode);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 viewMatrix = Matrix4.LookAt(location, location + eyeDirection, up);
            GL.LoadMatrix(ref viewMatrix);
            //GL.Translate(location);
            GL.Scale(zoom, zoom, zoom);
            GL.Rotate(rotation / ANGLE_SCALE, eyeDirection);
        }

    }
}
