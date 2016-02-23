using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace ManagedModeller {
    public class Scene {

        #region Event handling
        public delegate void SceneCallback(Scene scene);
        public event SceneCallback sceneUpdated;

        private void NotifyListeners() {
            if (sceneUpdated != null) {
                sceneUpdated.Invoke(this);
            }
        }

        private void PrimitiveUpdated(Primitive primitive) {
            NotifyListeners();
        }
        #endregion

        public Scene() {
            Sphere();
            //Triangles();
        }

        #region Initial Setup
        private void Sphere() {
            Sphere s = new Sphere();
            s.Transformation = Transformation.ScaleBy(50, 50, 50);
            s.SetColor(0, 1.0f, 1.0f);
            AddPrimitive(s);
        }

        private void Triangles() {
            Triangle t1 = new Triangle();
            t1.Transformation = Transformation.TranslateBy(100, 0, 0);
            t1.SetColor(Color.Yellow);
            t1.SetP1(0, 0, 0);
            t1.SetP2(100, 0, 0);
            t1.SetP3(0, 100, 0);
            AddPrimitive(t1);

            Triangle t2 = new Triangle();
            t2.Transformation = Transformation.TranslateBy(100, 0, 0);
            t2.SetColor(Color.Red);
            t2.SetP1(0, 0, 0);
            t2.SetP2(0, 0, 100);
            t2.SetP3(100, 0, 0);
            AddPrimitive(t2);

            Triangle t3 = new Triangle();
            t3.Transformation = Transformation.TranslateBy(100, 0, 0);
            t3.SetColor(Color.Green);
            t3.SetP1(0, 0, 0);
            t3.SetP2(0, 100, 0);
            t3.SetP3(0, 0, 100);
            AddPrimitive(t3);
        }
        #endregion

        #region Cameras
        private OrthographicCamera xCamera = OrthographicCamera.CreateXOrthographic();
        public OrthographicCamera XOrthographicCamera { get { return xCamera; } }

        private OrthographicCamera yCamera = OrthographicCamera.CreateYOrthographic();
        public OrthographicCamera YOrthographicCamera { get { return yCamera; } }

        private OrthographicCamera zCamera = OrthographicCamera.CreateZOrthographic();
        public OrthographicCamera ZOrthographicCamera { get { return zCamera; } }

        private PerspectiveCamera perspectiveCamera = new PerspectiveCamera();
        public PerspectiveCamera PerspectiveCamera { get { return perspectiveCamera; } }
        #endregion

        #region Primitive List
        private List<Primitive> primitives = new List<Primitive>();
        public void AddPrimitive(Primitive primitive) {
            primitives.Add(primitive);
            primitive.primitiveUpdated += PrimitiveUpdated;
            NotifyListeners();
        }

        public int GetPrimitiveCount() {
            return primitives.Count;
        }

        public Primitive GetPrimitive(int index) {
            return primitives[index];
        }
        #endregion

        #region Rendering
        public void Render() {
            foreach (Primitive primitive in primitives) {
                primitive.Render();
            }
        }

        public void RenderAxes() {
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
        #endregion
    }
}
