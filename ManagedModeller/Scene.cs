using System.Collections.Generic;
using System.Drawing;

namespace ManagedModeller {
    public class Scene {

        private bool dirty = false;
        public bool IsDirty { get { return dirty; } }

        private List<Primitive> primitives = new List<Primitive>();

        public Scene() {
            sphere();
        }

        private void sphere() {
            Sphere s = new Sphere();
            s.setColor(Color.Azure);
            primitives.Add(s);
        }

        private void triangles() {
            Triangle t1 = new Triangle();
            t1.getTransformation().setTranslation(100, 0, 0);
            t1.setColor(Color.Yellow);
            t1.setP1(0, 0, 0);
            t1.setP2(100, 0, 0);
            t1.setP3(0, 100, 0);
            addPrimitive(t1);

            Triangle t2 = new Triangle();
            t2.getTransformation().setTranslation(100, 0, 0);
            t2.setColor(Color.Red);
            t2.setP1(0, 0, 0);
            t2.setP2(0, 0, 100);
            t2.setP3(100, 0, 0);
            addPrimitive(t2);

            Triangle t3 = new Triangle();
            t3.getTransformation().setTranslation(100, 0, 0);
            t3.setColor(Color.Green);
            t3.setP1(0, 0, 0);
            t3.setP2(0, 100, 0);
            t3.setP3(0, 0, 100);
            addPrimitive(t3);
        }

        public void addPrimitive(Primitive primitive) {
            primitives.Add(primitive);
        }

        public void render() {
            foreach (Primitive primitive in primitives) {
                primitive.render();
            }
        }
    }
}
