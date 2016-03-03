using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller.Model {
    public class OrthographicCamera : Camera {

        #region Static
        public static OrthographicCamera CreateXOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.location = new Vector3(100, 0, 0);
            camera.lookAt = new Vector3(0, 0, 0);
            camera.up = new Vector3(0, 1, 0);
            camera.right = new Vector3(0, 0, -1);
            camera.Name = "X Orthographic";
            return camera;
        }

        public static OrthographicCamera CreateYOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.location = new Vector3(0, 100, 0);
            camera.lookAt = new Vector3(0, 0, 0);
            camera.up = new Vector3(0, 0, -1);
            camera.right = new Vector3(1, 0, 0);
            camera.Name = "Y Orthographic";
            return camera;
        }

        public static OrthographicCamera CreateZOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.location = new Vector3(0, 0, 100);
            camera.lookAt = new Vector3(0, 0, 0);
            camera.up = new Vector3(0, 1, 0);
            camera.right = new Vector3(1, 0, 0);
            camera.Name = "Z Orthographic";
            return camera;
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

        #region Rendering
        public override void SetProjectionMatrix() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-width / 2, width / 2, -height / 2, height / 2, near, far);
        }

        public override void SetModelViewMatrix() {
            base.SetModelViewMatrix();
            GL.Scale(zoom, zoom, zoom);
        }
        #endregion

        #region Event Response
        public override void Shift(Vector2 offset, bool isShiftPressed) {
            Vector3 threeDOffset = right * offset.X + up * offset.Y;
            location -= threeDOffset;
            lookAt -= threeDOffset;
            NotifyCameraUpdated();
        }

        public override void Rotate(float rotation) {}

        public override void Wheel(float distance, bool isControlPressed) {
            float modifier = isControlPressed ? 0.1f : 1.0f;
            float zoom = (float) Math.Exp(distance / 750.0 * modifier);
            Zoom *= zoom;
        }

        #endregion
    }
}
