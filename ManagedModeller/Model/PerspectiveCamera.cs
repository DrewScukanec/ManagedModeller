using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace ManagedModeller.Model {
    public class PerspectiveCamera : Camera {

        public PerspectiveCamera() {
            Location = new Vector3(100, 100, 100);
            LookAt = new Vector3(0, 0, 0);
            Up = new Vector3(0, 1, 0);
            Name = "Perspective Camera";
        }

        #region FOV
        protected float fovY = MathHelper.Pi / 3;
        public float FovY {
            get { return fovY; }
            set {
                fovY = value;
                NotifyCameraUpdated();
            }
        }
        #endregion

        #region Aspect Ratio
        public float AspectRatio {
            get { return ((float)width) / height; }
        }
        #endregion

        #region Rendering
        public override void SetProjectionMatrix() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(fovY, AspectRatio, near, far);
            GL.LoadMatrix(ref perspective);
        }
        #endregion

        #region Event Response
        public override void Shift(Vector2 offset, bool isShiftPressed) {
            Vector3 threeDOffset = right * offset.X + up * offset.Y;
            if (isShiftPressed) {
                lookAt -= threeDOffset;
            } else {
                location -= threeDOffset;
            }
            UpdateBasis();
        }

        public override void Rotate(float rotation) {
            Vector3 upPrime = up * ((float) Math.Cos(rotation)) + right * ((float) Math.Sin(rotation));
            Up = upPrime;
        }
        #endregion
    }
}
