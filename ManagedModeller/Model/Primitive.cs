using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Threading;

namespace ManagedModeller {
    public abstract class Primitive {

        private static long nextId = 1;

        #region Event handling
        public delegate void PrimitiveUpdated(Primitive primitive);
        public event PrimitiveUpdated primitiveUpdated;

        protected void NotifyListeners() {
            if (primitiveUpdated != null) {
                primitiveUpdated.Invoke(this);
            }
        }

        private void TransformationUpdated(Transformation transformation) {
            NotifyListeners();
        }
        #endregion

        protected Primitive() {
            id = Interlocked.Increment(ref nextId);
            transformation.transformationUpdated += TransformationUpdated;
        }

        #region ID
        private long id;
        public long Id { get { return id; } }
        #endregion

        #region Name
        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                NotifyListeners();
            }
        }
        #endregion

        #region Transformation
        protected Transformation transformation = new Transformation();
        public Transformation Transformation {
            get { return new Transformation(transformation); }
            set {
                transformation = new Transformation(value);
                NotifyListeners();
            }
        }
        #endregion

        #region Color
        protected Vector3 color = new Vector3(1, 0, 0);
        public Vector3 Color {
            get { return new Vector3(color); }
            set {
                SetColor(value.X, value.Y, value.Z);
            }
        }
        public void SetColor(Color color) {
            SetColor(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }
        public void SetColor(float r, float g, float b) {
            this.color = new Vector3(r, g, b);
            NotifyListeners();
        }
        #endregion Color

        #region Rendering
        public abstract void RenderInternal();

        public void Render() {
            GL.PushMatrix();
            transformation.ApplyMatrix();

            GL.Color3(color);
            RenderInternal();

            GL.PopMatrix();
        }
        #endregion
    }
}
