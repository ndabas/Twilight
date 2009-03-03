using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Twilight
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadWindows();
        }

        private void LoadWindows()
        {
            appsTreeView.Nodes.Clear();
            List<WindowInfo> windows = Windows.GetWindows();
            foreach (WindowInfo info in windows)
            {
                TreeNode[] nodes = appsTreeView.Nodes.Find(info.ClassName, false);
                TreeNode windowNode;
                if (nodes.Length == 1)
                {
                    windowNode = nodes[0].Nodes.Add(info.Caption);
                }
                else
                {
                    TreeNode node = appsTreeView.Nodes.Add(info.ClassName, info.ClassName);
                    windowNode = node.Nodes.Add(info.Caption);
                    node.Expand();
                }
                windowNode.Tag = info.Handle;
            }
        }

        private void appsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode classNode in appsTreeView.Nodes)
            {
                foreach (TreeNode windowNode in classNode.Nodes)
                {
                    if (windowNode.Checked)
                    {
                        Windows.CloseWindow((IntPtr)windowNode.Tag);
                    }
                }
            }

            // Application.Exit();
        }

        private void checkAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (TreeNode classNode in appsTreeView.Nodes)
            {
                classNode.Checked = true;
            }
        }

        private void uncheckAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (TreeNode classNode in appsTreeView.Nodes)
            {
                classNode.Checked = false;
            }
        }

        private void refreshLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadWindows();
        }
    }
}