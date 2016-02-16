using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace ManagedModeller {
    public class Scene {

        public delegate void SceneCallback(Scene scene);

        private OrthographicCamera xCamera = OrthographicCamera.CreateXOrthographic();
        private OrthographicCamera yCamera = OrthographicCamera.CreateYOrthographic();
        private OrthographicCamera zCamera = OrthographicCamera.CreateZOrthographic();
        private PerspectiveCamera perspectiveCamera = new PerspectiveCamera();
        private List<Primitive> primitives = new List<Primitive>();
        private event SceneCallback SceneUpdated;

        public Scene() {
            //Sphere();
            Triangles();
        }

        private void Sphere() {
            Sphere s = new Sphere();
            s.SetColor(0, 1.0f, 1.0f);
            primitives.Add(s);
        }

        private void Triangles() {
            Triangle t1 = new Triangle();
            t1.GetTransformation().SetTranslation(100, 0, 0);
            t1.SetColor(Color.Yellow);
            t1.SetP1(0, 0, 0);
            t1.SetP2(100, 0, 0);
            t1.SetP3(0, 100, 0);
            AddPrimitive(t1);

            Triangle t2 = new Triangle();
            t2.GetTransformation().SetTranslation(100, 0, 0);
            t2.SetColor(Color.Red);
            t2.SetP1(0, 0, 0);
            t2.SetP2(0, 0, 100);
            t2.SetP3(100, 0, 0);
            AddPrimitive(t2);

            Triangle t3 = new Triangle();
            t3.GetTransformation().SetTranslation(100, 0, 0);
            t3.SetColor(Color.Green);
            t3.SetP1(0, 0, 0);
            t3.SetP2(0, 100, 0);
            t3.SetP3(0, 0, 100);
            AddPrimitive(t3);
        }

        public void AddSceneUpdated(SceneCallback callback) {
            SceneUpdated += callback;
        }

        public void RemoveSceneUpdated(SceneCallback callback) {
            SceneUpdated -= callback;
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

        public OrthographicCamera GetXOrthographicCamera() {
            return xCamera;
        }

        public OrthographicCamera GetYOrthographicCamera() {
            return yCamera;
        }

        public OrthographicCamera GetZOrthographicCamera() {
            return zCamera;
        }

        public PerspectiveCamera GetPerspectiveCamera() {
            return perspectiveCamera;
        }

        public void AddPrimitive(Primitive primitive) {
            primitives.Add(primitive);
        }

        public void Render() {
            foreach (Primitive primitive in primitives) {
                primitive.Render();
            }
        }
    }
}
