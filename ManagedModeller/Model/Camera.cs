using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ManagedModeller {
    public abstract class Camera {

        public delegate void CameraUpdated(Camera camera);

        private const float ANGLE_SCALE = 2;

        private static Vector3 X_AXIS = new Vector3(1, 0, 0);
        private static Vector3 Y_AXIS = new Vector3(0, 1, 0);
        private static Vector3 Z_AXIS = new Vector3(0, 0, 1);

        private event CameraUpdated cameraUpdated;
        protected int width;
        protected int height;
        protected PolygonMode polygonMode = PolygonMode.Fill;
        protected Vector3 location = new Vector3();
        protected Vector3 lookAt = new Vector3();
        protected Vector3 eyeDirection = new Vector3();
        protected Vector3 up = new Vector3(0, 1, 0);
        protected Vector3 right = new Vector3();
        protected float rotation = 0;
        protected float zoom = 1;
        protected float near = 0.1f;
        protected float far = 1000;

        public void AddCameraUpdated(CameraUpdated callback) {
            cameraUpdated += callback;
        }

        public void RemoveCameraUpdated(CameraUpdated callback) {
            cameraUpdated -= callback;
        }

        public int GetWidth() { return width; }
        public void SetWidth(int width) {
            this.width = width;
            NotifyListeners();
        }

        public int GetHeight() { return height; }
        public void SetHeight(int height) {
            this.height = height;
            NotifyListeners();
        }

        public PolygonMode GetPolygonMode() { return polygonMode; }
        public void SetPolygonMode(PolygonMode polygonMode) {
            this.polygonMode = polygonMode;
            NotifyListeners();
        }

        public Vector3 GetLocation() { return new Vector3(location); }
        public void SetLocation(Vector3 location) {
            this.location.X = location.X;
            this.location.Y = location.Y;
            this.location.Z = location.Z;
            UpdateBasis();
        }

        public void SetLookAt(Vector3 lookAt) {
            this.lookAt = new Vector3(lookAt);
            UpdateBasis();
        }

        public void SetUp(Vector3 up) {
            this.up = new Vector3(up);
            this.up.Normalize();
            UpdateBasis();
        }

        protected void UpdateBasis() {
            eyeDirection = lookAt - location;
            eyeDirection.Normalize();
            this.right = Vector3.Cross(eyeDirection, up);
            NotifyListeners();
        }

        public float GetRotation() { return rotation; }
        public void SetRotation(float rotation) {
            this.rotation = rotation;
            NotifyListeners();
        }

        public float GetZoom() { return zoom; }
        public void SetZoom(float zoom) {
            this.zoom = zoom;
            NotifyListeners();
        }

        public float GetNear() { return near; }
        public void SetNear(float near) {
            this.near = near;
            NotifyListeners();
        }

        public float GetFar() { return far; }
        public void SetFar(float far) {
            this.far = far;
            NotifyListeners();
        }

        protected void NotifyListeners() {
            if (cameraUpdated != null) {
                cameraUpdated.Invoke(this);
            }
        }

        public abstract void Shift(Vector2 offset, bool isShiftPressed);

        public abstract void SetProjectionMatrix();

        public void SetModelViewMatrix() {
            GL.PolygonMode(MaterialFace.Front, polygonMode);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 viewMatrix = Matrix4.LookAt(location, lookAt, up);
            GL.LoadMatrix(ref viewMatrix);
            GL.Scale(zoom, zoom, zoom);
            GL.Rotate(rotation / ANGLE_SCALE, eyeDirection);
        }

    }
}
