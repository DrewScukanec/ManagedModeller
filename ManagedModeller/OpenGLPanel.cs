﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ManagedModeller {

    public partial class OpenGLPanel : UserControl {

        private const float ANGLE_SCALE = 2;

        public enum CameraType {
            XOrtho,
            YOrtho,
            ZOrtho
        }

        private bool loaded = false;

        private Scene scene;
        private Camera camera;
        private CameraType cameraType;

        public OpenGLPanel() {
            InitializeComponent();
            glControl.MouseWheel += glControlOnMouseWheel;
        }

        public void setScene(Scene scene) {
            this.scene = scene;
            switch (cameraType) {
                case CameraType.XOrtho: camera = scene.GetXOrthographicCamera(); break;
                case CameraType.YOrtho: camera = scene.GetYOrthographicCamera(); break;
                case CameraType.ZOrtho: camera = scene.GetZOrthographicCamera(); break;
            }
            camera.SetWidth(glControl.Width);
            camera.SetHeight(glControl.Height);
            glControl.Invalidate();
        }

        [Category("OpenGL"), Description("Specifies the camera type of the control")]
        public CameraType Camera {
            get {
                return cameraType;
            }

            set {
                cameraType = value;
                glControl.Invalidate();
            }
        }

        private void SetupViewport() {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
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

            camera.SetProjectionMatrix();
            camera.SetModelViewMatrix();
            scene.Render();
            scene.RenderAxes();

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
                Vector2 shift = new Vector2((e.X - lastX) * modifier, -(e.Y - lastY) * modifier);
                camera.Shift(shift);
                lastX = e.X;
                lastY = e.Y;
                glControl.Invalidate();
            } else if (rightMousePressed) {
                float rotation = (e.Y - lastPhi) * (ModifierKeys.HasFlag(Keys.Control) ? 0.1f : 1.0f);
                camera.SetRotation(camera.GetRotation() + rotation);
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
            if (!loaded || DesignMode)
                return;

            glControl.MakeCurrent();
            camera.SetHeight(glControl.Height);
            camera.SetWidth(glControl.Width);
            SetupViewport();
            glControl.Invalidate();
        }

        private void glControlOnMouseWheel(object sender, MouseEventArgs e) {
            if (!leftMousePressed && !rightMousePressed) {
                float modifier = (ModifierKeys.HasFlag(Keys.Control) ? 0.1f : 1.0f);
                float zoom = (float)Math.Exp(e.Delta / 750.0 * modifier);
                camera.SetZoom(camera.GetZoom()* zoom);
                glControl.Invalidate();
            }
        }

        private void glControlOnMouseDoubleClick(object sender, MouseEventArgs e) {
            camera.SetPolygonMode(camera.GetPolygonMode() == PolygonMode.Fill ? PolygonMode.Line : PolygonMode.Fill);
            glControl.Invalidate();
        }
    }

}
