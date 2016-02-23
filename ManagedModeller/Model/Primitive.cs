using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Threading;

namespace ManagedModeller {
    public abstract class Primitive {

        private static long nextId = 1;

        public delegate void PrimitiveUpdated(Primitive primitive);

        public event PrimitiveUpdated primitiveUpdated;

        protected Primitive() {
            id = Interlocked.Increment(ref nextId);
        }

        protected void NotifyListeners() {
            if (primitiveUpdated != null) {
                primitiveUpdated.Invoke(this);
            }
        }

        private long id;
        public long GetId() { return id; }

        private string name;
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        protected Transformation transformation = new Transformation();
        protected Vector3 color = new Vector3(1, 0, 0);

        public Transformation GetTransformation() { return new Transformation(transformation); }
        public Vector3 GetColor() { return new Vector3(color); }

        public void SetTransformation(Transformation transformation) {
            this.transformation = new Transformation(transformation);
            NotifyListeners();
        }
        public void SetColor(Color color) {
            this.color = new Vector3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
            NotifyListeners();
        }
        public void SetColor(float r, float g, float b) {
            this.color = new Vector3(r, g, b);
            NotifyListeners();
        }

        public abstract void RenderInternal();

        public void Render() {
            GL.PushMatrix();
            transformation.ApplyMatrix();

            GL.Color3(color);
            RenderInternal();

            GL.PopMatrix();
        }
    }
}
