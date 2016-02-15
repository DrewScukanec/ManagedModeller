using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManagedModeller {
    public class OrthographicCamera : Camera {

        public override void SetProjectionMatrix() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-width / 2, width / 2, -height / 2, height / 2, -100 * zoom, 100 * zoom);
        }

    }
}
