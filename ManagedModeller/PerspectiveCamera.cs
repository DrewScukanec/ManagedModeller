using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class PerspectiveCamera : Camera {
        protected float fovY = MathHelper.Pi / 3;

        public float GetFovY() { return fovY; }
        public void SetFovY(float fovY) { this.fovY = fovY; }

        public float GetAspectRatio() { return ((float) width) / height; }

        public PerspectiveCamera() {
            SetLocation(new Vector3(100, 100, 100));
            SetLookAt(new Vector3(0, 0, 0));
            SetUp(new Vector3(0, 1, 0));
        }

        public override void SetProjectionMatrix() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(fovY, GetAspectRatio(), near, far);
            GL.LoadMatrix(ref perspective);
        }

        public override void Shift(Vector2 offset, bool isShiftPressed) {
            Vector3 threeDOffset = right * offset.X + up * offset.Y;
            if (isShiftPressed) {
                lookAt -= threeDOffset;
            } else {
                location -= threeDOffset;
            }
        }
    }
}
