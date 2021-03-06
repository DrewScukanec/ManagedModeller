﻿using ManagedModeller.Controls;
using ManagedModeller.Model;
using System;
using System.Collections.Generic;
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

            PopulateSceneTree();
        }

        private void PopulateSceneTree() {
            sceneTree.Nodes.Add(new SceneElementNode(scene.XOrthographicCamera));
            sceneTree.Nodes.Add(new SceneElementNode(scene.YOrthographicCamera));
            sceneTree.Nodes.Add(new SceneElementNode(scene.ZOrthographicCamera));
            sceneTree.Nodes.Add(new SceneElementNode(scene.PerspectiveCamera));

            for (int ctr = 0; ctr < scene.GetPrimitiveCount(); ctr++) {
                sceneTree.Nodes.Add(new SceneElementNode(scene.GetPrimitive(ctr)));
            }
        }

        private void onSceneTreeSelection(object sender, TreeViewEventArgs e) {
            TreeNode node = e.Node;
            if (node != null) {
                SceneElementNode sceneElementNode = (SceneElementNode)node;
                SceneElement sceneElement = sceneElementNode.SceneElement;
                SceneElementPanel panel = null;
                Control control = null;
                if (sceneElement is OrthographicCamera) {
                    OrthographicCameraPanel defPanel = new OrthographicCameraPanel();
                    control = defPanel;
                    panel = defPanel;
                } else if (sceneElement is PerspectiveCamera) {
                    PerspectiveCameraPanel defPanel = new PerspectiveCameraPanel();
                    control = defPanel;
                    panel = defPanel;
                } else if (sceneElement is Sphere) {
                    SpherePanel defPanel = new SpherePanel();
                    control = defPanel;
                    panel = defPanel;
                } else if (sceneElement is Cylinder) {
                    CylinderPanel defPanel = new CylinderPanel();
                    control = defPanel;
                    panel = defPanel;
                }

                propertyPage.Controls.Clear();
                propertyPage.Controls.Add(control);
                control.Dock = DockStyle.Top;

                panel.SetSceneElement(sceneElement);
            }
        }
    }

    class SceneElementNode : TreeNode {

        private SceneElement sceneElement;
        public SceneElement SceneElement { get { return sceneElement; } }

        public SceneElementNode(SceneElement sceneElement) : base(sceneElement.Name) {
            this.sceneElement = sceneElement;
        }
    }
}
