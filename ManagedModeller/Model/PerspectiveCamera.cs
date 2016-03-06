using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace ManagedModeller.Model {
    public class PerspectiveCamera : Camera {

        public PerspectiveCamera() {
            location = new Vector3(100, 100, 0);
            lookAt = new Vector3(0, 0, 0);
            eyeDirection = new Vector3(-1, -1, 0);
            eyeDirection.Normalize();
            up = new Vector3(-1, 1, 0);
            up.Normalize();
            right = new Vector3(0, 0, -1);
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

        public float AspectRatio { get { return ((float) width) / height; } }
        public float FovX { get { return (float) (2 * Math.Atan(Math.Tan(FovY / 2) * AspectRatio)); } }

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
            if (isShiftPressed) {
                float rotationAroundRight = offset.Y / Height * FovY;
                float rotationAroundUp = offset.X / Width * FovX;
                Right = right * ((float)Math.Cos(rotationAroundUp)) + eyeDirection * ((float)Math.Sin(rotationAroundUp));
                Up = up * ((float) Math.Cos(rotationAroundRight)) + eyeDirection * ((float) Math.Sin(rotationAroundRight));
            } else {
                Vector3 threeDOffset = right * offset.X + up * offset.Y;
                location -= threeDOffset;
                lookAt -= threeDOffset;
                NotifyCameraUpdated();
            }
        }

        public override void Rotate(float rotation) {
            rotation /= 10;
            Up = up * ((float) Math.Cos(rotation)) + right * ((float) Math.Sin(rotation));
        }

        public override void Wheel(float distance, bool isControlPressed) {
            float modifier = isControlPressed ? 0.05f : 0.5f;
            Vector3 threeDOffset = distance * modifier * eyeDirection;
            location += threeDOffset;
            lookAt += threeDOffset;
            NotifyCameraUpdated();
        }
        #endregion
    }
}
