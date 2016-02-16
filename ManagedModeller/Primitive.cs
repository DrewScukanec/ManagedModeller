using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Threading;

namespace ManagedModeller {
    public abstract class Primitive {
        private static long nextId = 1;

        protected Primitive() {
            id = Interlocked.Increment(ref nextId);
        }

        private long id;
        public long GetId() { return id; }

        private string name;
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        protected Transformation transformation = new Transformation();
        protected Vector3 color = new Vector3(1, 0, 0);

        public Transformation GetTransformation() { return transformation; }
        public Vector3 GetColor() { return new Vector3(color); }

        public void SetColor(Color color) {
            this.color = new Vector3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
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
