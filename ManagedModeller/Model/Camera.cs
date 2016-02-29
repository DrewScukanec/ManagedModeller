using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller.Model {
    public abstract class Camera : SceneElement {

        #region Static
        private const float ANGLE_SCALE = 2;
        #endregion

        #region Event Handling
        public delegate void CameraUpdated(Camera camera);
        public event CameraUpdated cameraUpdated;

        protected void NotifyCameraUpdated() {
            if (cameraUpdated != null) {
                cameraUpdated.Invoke(this);
            }
        }
        #endregion

        #region TwoD Properties
        protected int width;
        public int Width {
            get { return width; }
            set {
                width = value;
                NotifyCameraUpdated();
            }
        }

        protected int height;
        public int Height {
            get { return height; }
            set {
                height = value;
                NotifyCameraUpdated();
            }
        }
        #endregion

        #region Rendering Properties
        protected PolygonMode polygonMode = PolygonMode.Fill;
        public PolygonMode PolygonMode {
            get { return polygonMode; }
            set {
                polygonMode = value;
                NotifyCameraUpdated();
            }
        }

        protected float near = 0.1f;
        public float Near {
            get { return near; }
            set {
                near = value;
                NotifyCameraUpdated();
            }
        }

        protected float far = 1000;
        public float Far {
            get { return far; }
            set {
                far = value;
                NotifyCameraUpdated();
            }
        }
        #endregion

        #region ThreeD Properties
        protected Vector3 location = new Vector3();
        public Vector3 Location {
            get { return new Vector3(location); }
            set {
                location.X = value.X;
                location.Y = value.Y;
                location.Z = value.Z;
                UpdateBasis();
            }
        }

        protected Vector3 lookAt = new Vector3();
        public Vector3 LookAt {
            get { return new Vector3(lookAt); }
            set {
                lookAt = new Vector3(value);
                UpdateBasis();
            }
        }

        protected Vector3 up = new Vector3(0, 1, 0);
        public Vector3 Up {
            get { return new Vector3(up); }
            set {
                up = new Vector3(value);
                up.Normalize();
                UpdateBasis();
            }
        }

        protected Vector3 eyeDirection = new Vector3();
        public Vector3 EyeDirection { get { return new Vector3(eyeDirection); } }

        protected Vector3 right = new Vector3();
        public Vector3 Right { get { return new Vector3(right); } }

        protected void UpdateBasis() {
            eyeDirection = lookAt - location;
            eyeDirection.Normalize();
            right = Vector3.Cross(eyeDirection, up);
            right.Normalize();
            up = Vector3.Cross(right, eyeDirection);
            up.Normalize();
            NotifyCameraUpdated();
        }
        #endregion

        protected float zoom = 1;
        public float Zoom {
            get { return zoom; }
            set {
                zoom = value;
                NotifyCameraUpdated();
            }
        }

        public abstract void Shift(Vector2 offset, bool isShiftPressed);

        public abstract void Rotate(float rotation);

        #region Rendering
        public abstract void SetProjectionMatrix();

        public void SetModelViewMatrix() {
            GL.PolygonMode(MaterialFace.Front, polygonMode);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 viewMatrix = Matrix4.LookAt(location, lookAt, up);
            GL.LoadMatrix(ref viewMatrix);
            GL.Scale(zoom, zoom, zoom);
        }
        #endregion
    }
}
