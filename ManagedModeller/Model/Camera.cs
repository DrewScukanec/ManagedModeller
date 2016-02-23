using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ManagedModeller {
    public abstract class Camera {

        #region Static
        private const float ANGLE_SCALE = 2;
        #endregion

        #region Event Handling
        public delegate void CameraUpdated(Camera camera);
        public event CameraUpdated cameraUpdated;

        protected void NotifyListeners() {
            if (cameraUpdated != null) {
                cameraUpdated.Invoke(this);
            }
        }
        #endregion

        protected int width;
        public int Width {
            get { return width; }
            set {
                width = value;
                NotifyListeners();
            }
        }

        protected int height;
        public int Height {
            get { return height; }
            set {
                height = value;
                NotifyListeners();
            }
        }

        protected PolygonMode polygonMode = PolygonMode.Fill;
        public PolygonMode PolygonMode {
            get { return polygonMode; }
            set {
                polygonMode = value;
                NotifyListeners();
            }
        }

        protected Vector3 location = new Vector3();
        public Vector3 GetLocation() { return new Vector3(location); }
        public void SetLocation(Vector3 location) {
            this.location.X = location.X;
            this.location.Y = location.Y;
            this.location.Z = location.Z;
            UpdateBasis();
        }

        protected Vector3 lookAt = new Vector3();
        public void SetLookAt(Vector3 lookAt) {
            this.lookAt = new Vector3(lookAt);
            UpdateBasis();
        }

        protected Vector3 up = new Vector3(0, 1, 0);
        public void SetUp(Vector3 up) {
            this.up = new Vector3(up);
            this.up.Normalize();
            UpdateBasis();
        }

        protected Vector3 eyeDirection = new Vector3();
        protected Vector3 right = new Vector3();
        protected void UpdateBasis() {
            eyeDirection = lookAt - location;
            eyeDirection.Normalize();
            this.right = Vector3.Cross(eyeDirection, up);
            NotifyListeners();
        }

        protected float rotation = 0;
        public float GetRotation() { return rotation; }
        public void SetRotation(float rotation) {
            this.rotation = rotation;
            NotifyListeners();
        }

        protected float zoom = 1;
        public float Zoom {
            get { return zoom; }
            set {
                zoom = value;
                NotifyListeners();
            }
        }

        protected float near = 0.1f;
        public float Near {
            get { return near; }
            set {
                near = value;
                NotifyListeners();
            }
        }

        protected float far = 1000;
        public float Far {
            get { return far; }
            set {
                far = value;
                NotifyListeners();
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
