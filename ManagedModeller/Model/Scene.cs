using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace ManagedModeller.Model {
    public class Scene {

        #region Event handling
        private void OnPrimitiveUpdated(Primitive primitive) {
            NotifyScenePrimitiveUpdated(primitive);
        }

        private void OnNameUpdated(SceneElement sceneElement) {
            NotifySceneElementNameUpdated(sceneElement);
        }

        public delegate void ScenePrimitiveUpdated(Scene scene, Primitive primitive);
        public event ScenePrimitiveUpdated scenePrimitiveUpdated;

        private void NotifyScenePrimitiveUpdated(Primitive primitive) {
            if (scenePrimitiveUpdated != null) {
                scenePrimitiveUpdated.Invoke(this, primitive);
            }
        }

        public delegate void SceneElementNameUpdated(Scene scene, SceneElement sceneElement);
        public event SceneElementNameUpdated sceneElementNameUpdated;

        private void NotifySceneElementNameUpdated(SceneElement sceneElement) {
            if (sceneElementNameUpdated != null) {
                sceneElementNameUpdated.Invoke(this, sceneElement);
            }
        }

        public delegate void PrimitiveAdded(Scene scene, Primitive primitive);
        public event PrimitiveAdded primitiveAdded;

        private void NotifyPrimitiveAdded(Primitive primitive) {
            if (primitiveAdded != null) {
                primitiveAdded.Invoke(this, primitive);
            }
        }
        #endregion

        public Scene() {
            Cylinder();
            //Sphere();
            //Triangles();
        }

        #region Initial Setup
        private void Cylinder() {
            Cylinder c = new Cylinder();
            c.Transformation = Transformation.ScaleBy(50, 50, 50);
            c.SetColor(0, 1.0f, 1.0f);
            c.Name = "Blue Cylinder";
            AddPrimitive(c);
        }

        private void Sphere() {
            Sphere s = new Sphere();
            s.Transformation = Transformation.ScaleBy(50, 50, 50);
            s.SetColor(0, 1.0f, 1.0f);
            s.Name = "Blue Sphere";
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
            primitive.primitiveUpdated += OnPrimitiveUpdated;
            primitive.nameUpdated += OnNameUpdated;
            NotifyPrimitiveAdded(primitive);
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
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex4(0, 0, 0, 1);
            GL.Vertex4(1, 0, 0, 0);
            //GL.Vertex4(0, 0, 0, 1);
            //GL.Vertex4(-1, 0, 0, 0);
            GL.Color3(Color.Green);
            GL.Vertex4(0, 0, 0, 1);
            GL.Vertex4(0, 1, 0, 0);
            //GL.Vertex4(0, 0, 0, 1);
            //GL.Vertex4(0, -1, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex4(0, 0, 0, 1);
            GL.Vertex4(0, 0, 1, 0);
            //GL.Vertex4(0, 0, 0, 1);
            //GL.Vertex4(0, 0, -1, 0);
            GL.End();
        }
        #endregion
    }
}
