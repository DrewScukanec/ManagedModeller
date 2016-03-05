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
            DrawTop(1);
            DrawTop(-1);
            DrawSide(-1, 1);
        }

        private void DrawTop(float height) {
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex3(0, height, 0);
            for (int ctr = 0; ctr <= divisions * 4; ctr++) {
                float radians = (float) Math.PI * 2 / (divisions * 4) * ctr;
                float x = (float) Math.Cos(radians);
                float z = (float) -Math.Sin(radians);
                GL.Vertex3(x, height, z);
            }
            //GL.Vertex3(0, height, 0);

            GL.End();
        }

        private void DrawSide(float bottom, float top) {
            GL.Begin(PrimitiveType.TriangleStrip);

            for (int ctr = 0; ctr <= divisions * 4; ctr++) {
                float radians = (float)Math.PI * 2 / (divisions * 4) * ctr;
                float x = (float)Math.Cos(radians);
                float z = (float)-Math.Sin(radians);
                GL.Vertex3(x, top, z);
                GL.Vertex3(x, bottom, z);
            }

            GL.End();
        }
        #endregion

    }
}
