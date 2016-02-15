using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ManagedModeller {
    public abstract class Camera {

        private const float ANGLE_SCALE = 2;

        private static Vector3 X_AXIS = new Vector3(1, 0, 0);
        private static Vector3 Y_AXIS = new Vector3(0, 1, 0);
        private static Vector3 Z_AXIS = new Vector3(0, 0, 1);

        public enum CameraType {
            XOrtho,
            YOrtho,
            ZOrtho
        }

        protected int width;
        protected int height;
        protected CameraType cameraType;
        protected PolygonMode polygonMode = PolygonMode.Fill;
        protected Vector3 axis = new Vector3();
        protected Vector3 offset = new Vector3();
        protected float rotation = 0;
        protected float zoom = 1;

        public int getWidth() { return width; }
        public void setWidth(int width) { this.width = width; }

        public int getHeight() { return height; }
        public void setHeight(int height) { this.height = height; }

        public PolygonMode getPolygonMode() { return PolygonMode.Fill; }
        public void setPolygonMode(PolygonMode polygonMode) { this.polygonMode = polygonMode; }

        public Vector3 getOffset() { return new Vector3(offset); }
        public void setOffset(Vector3 offset) {
            this.offset.X = offset.X;
            this.offset.Y = offset.Y;
            this.offset.Z = offset.Z;
        }

        public float getRotation() { return rotation; }
        public void setRotation(float rotation) { this.rotation = rotation; }

        public float getZoom() { return zoom; }
        public void setZoom(float zoom) { this.zoom = zoom; }

        public void ShiftOffset(Vector2 offset) {
            switch (cameraType) {
                case CameraType.XOrtho:
                    this.offset.Z -= offset.X;
                    this.offset.Y -= offset.Y;
                    break;
                case CameraType.YOrtho:
                    this.offset.X += offset.X;
                    this.offset.Z += offset.Y;
                    break;
                case CameraType.ZOrtho:
                    this.offset.X += offset.X;
                    this.offset.Y -= offset.Y;
                    break;
            }
        }

        public abstract void SetProjectionMatrix();

        public void SetModelViewMatrix() {
            GL.PolygonMode(MaterialFace.Front, polygonMode);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            switch (cameraType) {
                case CameraType.XOrtho:
                    GL.Rotate(-90, Y_AXIS);
                    break;
                case CameraType.YOrtho:
                    GL.Rotate(90, X_AXIS);
                    break;
                case CameraType.ZOrtho:
                    break;
            }
            GL.Translate(offset);
            GL.Scale(zoom, zoom, zoom);
            GL.Rotate(rotation / ANGLE_SCALE, axis);
        }

    }
}
