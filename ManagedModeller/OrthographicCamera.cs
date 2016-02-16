using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class OrthographicCamera : Camera {

        public static OrthographicCamera CreateXOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.SetLocation(new Vector3(100, 0, 0));
            Vector3 eyeDirection = new Vector3(-100, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            camera.SetBasis(eyeDirection, up);
            return camera;
        }

        public static OrthographicCamera CreateYOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.SetLocation(new Vector3(0, 100, 0));
            Vector3 eyeDirection = new Vector3(0, -100, 0);
            Vector3 up = new Vector3(0, 0, -1);
            camera.SetBasis(eyeDirection, up);
            return camera;
        }

        public static OrthographicCamera CreateZOrthographic() {
            OrthographicCamera camera = new OrthographicCamera();
            camera.SetLocation(new Vector3(0, 0, 100));
            Vector3 eyeDirection = new Vector3(0, 0, -100);
            Vector3 up = new Vector3(0, 1, 0);
            camera.SetBasis(eyeDirection, up);
            return camera;
        }

        public override void SetProjectionMatrix() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-width / 2, width / 2, -height / 2, height / 2, -1000 * zoom, 1000 * zoom);
        }

    }
}
