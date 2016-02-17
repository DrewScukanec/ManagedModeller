using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class OrthographicCamera : Camera {

        public static OrthographicCamera CreateXOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.SetLocation(new Vector3(100, 0, 0));
            camera.SetLookAt(new Vector3(0, 0, 0));
            camera.SetUp(new Vector3(0, 1, 0));
            return camera;
        }

        public static OrthographicCamera CreateYOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.SetLocation(new Vector3(0, 100, 0));
            camera.SetLookAt(new Vector3(0, 0, 0));
            camera.SetUp(new Vector3(0, 0, -1));
            return camera;
        }

        public static OrthographicCamera CreateZOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.SetLocation(new Vector3(0, 0, 100));
            camera.SetLookAt(new Vector3(0, 0, 0));
            camera.SetUp(new Vector3(0, 1, 0));
            return camera;
        }

        public override void SetProjectionMatrix() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-width / 2, width / 2, -height / 2, height / 2, near, far);
        }

        public override void Shift(Vector2 offset, bool isShiftPressed) {
            Vector3 threeDOffset = right * offset.X + up * offset.Y;
            location -= threeDOffset;
            lookAt -= threeDOffset;
            UpdateBasis();
        }
    }
}
