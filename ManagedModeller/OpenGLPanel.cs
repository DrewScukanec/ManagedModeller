using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ManagedModeller {

    public partial class OpenGLPanel : UserControl {

        private static Vector3 X_AXIS = new Vector3(1, 0, 0);
        private static Vector3 Y_AXIS = new Vector3(0, 1, 0);
        private static Vector3 Z_AXIS = new Vector3(0, 0, 1);
        private const float ANGLE_SCALE = 2;

        public enum CameraType {
            XOrtho,
            YOrtho,
            ZOrtho
        }

        private bool loaded = false;
        private CameraType cameraType;
        private PolygonMode polygonMode = PolygonMode.Fill;
        private Vector3 axis = new Vector3();
        private Vector3 offset = new Vector3();
        private float rotation = 0;
        private float zoom = 1;

        private Scene scene;

        public OpenGLPanel() {
            InitializeComponent();
            glControl.MouseWheel += glControlOnMouseWheel;
        }

        public void setScene(Scene scene) { this.scene = scene; }

        [Category("OpenGL"), Description("Specifies the camera type of the control")]
        public CameraType Camera {
            get {
                return cameraType;
            }

            set {
                cameraType = value;
                switch (cameraType) {
                    case CameraType.XOrtho:
                        axis = X_AXIS;
                        break;
                    case CameraType.YOrtho:
                        axis = Y_AXIS;
                        break;
                    case CameraType.ZOrtho:
                        axis = Z_AXIS;
                        break;
                }
                glControl.Invalidate();
            }
        }

        private void SetupViewport() {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        private void SetProjectionMatrix() {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-w / 2, w / 2, -h / 2, h / 2, -100 * zoom, 100 * zoom);
        }

        private void SetModelViewMatrix() {
            GL.PolygonMode(MaterialFace.Front, polygonMode);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            switch (cameraType) {
                case CameraType.XOrtho:
                    GL.Rotate(-90, Y_AXIS);
                    break;
                case CameraType.YOrtho:
                    GL.Rotate(90, X_AXIS);
                    break;
                case CameraType.ZOrtho:
                    break;
            }
            GL.Translate(offset);
            GL.Scale(zoom, zoom, zoom);
            GL.Rotate(rotation / ANGLE_SCALE, axis);
        }

        private void DrawScene() {
            scene.render();
        }

        private void DrawDefaultScene() {
            GL.PushMatrix();
            GL.Translate(100, 0, 0);
            //GL.Rotate(60, new Vector3(1, 1, 1));

            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(100, 0, 0);
            GL.Vertex3(0, 100, 0);
            GL.End();
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 100);
            GL.Vertex3(100, 0, 0);
            GL.End();
            GL.Color3(Color.Green);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 100, 0);
            GL.Vertex3(0, 0, 100);
            GL.End();

            GL.PopMatrix();
        }

        private void DrawAxes() {
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex4(0, 0, 0, 1);
            GL.Vertex4(1, 0, 0, 0);
            //GL.Vertex4(0, 0, 0, 1);
            //GL.Vertex4(-1, 0, 0, 0);
            GL.Vertex4(0, 0, 0, 1);
            GL.Vertex4(0, 1, 0, 0);
            //GL.Vertex4(0, 0, 0, 1);
            //GL.Vertex4(0, -1, 0, 0);
            GL.Vertex4(0, 0, 0, 1);
            GL.Vertex4(0, 0, 1, 0);
            //GL.Vertex4(0, 0, 0, 1);
            //GL.Vertex4(0, 0, -1, 0);
            GL.End();
        }

        private void glControlLoad(object sender, EventArgs e) {
            if (DesignMode)
                return;

            loaded = true;
            glControl.MakeCurrent();
            GL.ClearColor(Color.Black);
            SetupViewport();
        }

        private void glControlPaint(object sender, PaintEventArgs e) {
            if (!loaded)
                return;

            glControl.MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SetProjectionMatrix();
            SetModelViewMatrix();
            DrawScene();
            DrawAxes();

            glControl.SwapBuffers();
        }

        private bool leftMousePressed = false;
        private float lastX = 0;
        private float lastY = 0;

        private bool rightMousePressed = false;
        private float lastPhi = 0;

        private void glControlOnMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                leftMousePressed = true;
                lastX = e.X;
                lastY = e.Y;
            } else if (e.Button == MouseButtons.Right) {
                rightMousePressed = true;
                lastPhi = e.Y;
            }
        }

        private void glControlOnMouseMove(object sender, MouseEventArgs e) {
            if (leftMousePressed) {
                float modifier = (ModifierKeys.HasFlag(Keys.Control) ? 0.1f : 1.0f);
                switch (cameraType) {
                    case CameraType.XOrtho:
                        offset.Z -= (e.X - lastX) * modifier;
                        offset.Y -= (e.Y - lastY) * modifier;
                        break;
                    case CameraType.YOrtho:
                        offset.X += (e.X - lastX) * modifier;
                        offset.Z += (e.Y - lastY) * modifier;
                        break;
                    case CameraType.ZOrtho:
                        offset.X += (e.X - lastX) * modifier;
                        offset.Y -= (e.Y - lastY) * modifier;
                        break;
                }
                lastX = e.X;
                lastY = e.Y;
                glControl.Invalidate();
            } else if (rightMousePressed) {
                rotation -= (e.Y - lastPhi) * (ModifierKeys.HasFlag(Keys.Control) ? 0.1f : 1.0f);
                lastPhi = e.Y;
                glControl.Invalidate();
            }
        }

        private void glControlOnMouseUp(object sender, MouseEventArgs e) {
            if (leftMousePressed) {
                lastX = 0;
                lastY = 0;
                leftMousePressed = false;
            } else if (rightMousePressed) {
                lastPhi = 0;
                rightMousePressed = false;
            }
        }

        private void glControlResize(object sender, EventArgs e) {
            glControl.MakeCurrent();
            SetupViewport();
            glControl.Invalidate();
        }

        private void glControlOnMouseWheel(object sender, MouseEventArgs e) {
            if (!leftMousePressed && !rightMousePressed) {
                zoom *= (float)Math.Exp(e.Delta / 750.0 * (ModifierKeys.HasFlag(Keys.Control) ? 0.1f : 1.0f));
                glControl.Invalidate();
            }
        }

        private void glControlOnMouseDoubleClick(object sender, MouseEventArgs e) {
            polygonMode = polygonMode == PolygonMode.Fill ? PolygonMode.Line : PolygonMode.Fill;
            glControl.Invalidate();
        }
    }

}
