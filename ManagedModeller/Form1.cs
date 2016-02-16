using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ManagedModeller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Scene scene = new Scene();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (scene.IsDirty) {

            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) {
            openGLPanel1.setScene(scene);
            openGLPanel2.setScene(scene);
            openGLPanel3.setScene(scene);
            openGLPanel4.setScene(scene);
        }
    }
}
