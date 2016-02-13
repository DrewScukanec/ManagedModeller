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
        public long getId() { return id; }

        private string name;
        public string getName() { return name; }
        public void setName(string name) { this.name = name; }

        protected Transformation transformation = new Transformation();
        protected Vector3 color = new Vector3(1, 0, 0);

        public Transformation getTransformation() { return transformation; }
        public Vector3 getColor() { return color; }

        public void setColor(Color color) {
            this.color = new Vector3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }

        public abstract void renderInternal();

        public void render() {
            GL.PushMatrix();
            transformation.applyMatrix();

            GL.Color3(color);
            renderInternal();

            GL.PopMatrix();
        }
    }
}
