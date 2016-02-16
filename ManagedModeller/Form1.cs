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
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) {
            openGLPanel1.SetScene(scene);
            openGLPanel2.SetScene(scene);
            openGLPanel3.SetScene(scene);
            openGLPanel4.SetScene(scene);
        }
    }
}
