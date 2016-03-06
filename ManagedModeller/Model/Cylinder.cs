using OpenTK.Graphics.OpenGL;
using System;

namespace ManagedModeller.Model {
    public class Cylinder : Primitive {

        #region Divisions
        private int divisions = 10;
        public int Divisions {
            get { return divisions; }
            set {
                divisions = value;
                NotifyPrimitiveUpdated();
            }
        }
        #endregion

        #region Rendering
        public override void RenderInternal() {
            DrawTop();
            DrawBottom();
            DrawSide();
        }

        private void DrawTop() {
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Normal3(0f, 1f, 0f);
            GL.Vertex3(0, 1, 0);
            for (int ctr = 0; ctr <= divisions * 4; ctr++) {
                float radians = (float) Math.PI * 2 / (divisions * 4) * ctr;
                float x = (float) Math.Cos(radians);
                float z = (float) -Math.Sin(radians);
                GL.Normal3(0f, 1f, 0f);
                GL.Vertex3(x, 1, z);
            }

            GL.End();
        }

        private void DrawBottom() {
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Normal3(0f, -1f, 0f);
            GL.Vertex3(0, -1, 0);
            for (int ctr = divisions * 4; ctr >= 0; ctr--) {
                float radians = (float)Math.PI * 2 / (divisions * 4) * ctr;
                float x = (float)Math.Cos(radians);
                float z = (float)-Math.Sin(radians);
                GL.Normal3(0f, -1f, 0f);
                GL.Vertex3(x, -1, z);
            }

            GL.End();
        }

        private void DrawSide() {
            GL.Begin(PrimitiveType.TriangleStrip);

            for (int ctr = 0; ctr <= divisions * 4; ctr++) {
                float radians = (float)Math.PI * 2 / (divisions * 4) * ctr;
                float x = (float)Math.Cos(radians);
                float z = (float)-Math.Sin(radians);
                GL.Normal3(x, 0, z);
                GL.Vertex3(x, 1, z);
                GL.Normal3(x, 0, z);
                GL.Vertex3(x, -1, z);
            }

            GL.End();
        }
        #endregion

    }
}
