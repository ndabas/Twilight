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
            // Get a list of all windows and load the treeview with it.

            appsTreeView.Nodes.Clear();
            List<WindowInfo> windows = Windows.GetWindows();
            foreach (WindowInfo info in windows)
            {
                // Group windows of the same class.

                TreeNode[] nodes = appsTreeView.Nodes.Find(info.ModuleFileName, false);
                TreeNode classNode;
                if (nodes.Length == 1)
                {
                    classNode = nodes[0];
                }
                else
                {
                    classNode = appsTreeView.Nodes.Add(info.ModuleFileName, info.Description);
                }

                classNode.Nodes.Add(info.Handle.ToString(), info.Caption).Tag = info.Handle;
                classNode.Expand();
            }

            // Start the refresh timer
            refreshTimer.Enabled = true;
        }

        private void RefreshWindows()
        {
            // Non-destructively refresh the treeview. We can't simply clear it and reload it
            // because then we'd lose the state of the checkboxes. Plus doing that causes a flicker.

            // First, get a list of all windows and make sure that all of them exist in the treeview.

            List<WindowInfo> windows = Windows.GetWindows();
            foreach (WindowInfo info in windows)
            {
                TreeNode[] nodes = appsTreeView.Nodes.Find(info.ModuleFileName, false);
                TreeNode classNode = null;
                if (nodes.Length == 1)
                {
                    if (nodes[0].Nodes.Find(info.Handle.ToString(), false).Length == 0)
                    {
                        classNode = nodes[0];
                    }
                }
                else
                {
                    classNode = appsTreeView.Nodes.Add(info.ModuleFileName, info.Description);
                }

                if (classNode != null)
                {
                    classNode.Nodes.Add(info.Handle.ToString(), info.Caption).Tag = info.Handle;
                    classNode.Expand();
                }
            }

            // Next, make sure that all windows in the treeview still exist.
            // No foreach'ing here because we're deleting items from the collection we're
            // iterating over.

            for (int i = appsTreeView.Nodes.Count - 1; i >= 0; i--)
            {
                TreeNode classNode = appsTreeView.Nodes[i];
                for (int j = classNode.Nodes.Count - 1; j >= 0; j--)
                {
                    TreeNode windowNode = classNode.Nodes[j];
                    if (!Windows.WindowExists((IntPtr)windowNode.Tag))
                    {
                        classNode.Nodes.RemoveAt(j);
                    }
                }

                // Remove the class name node too if there are no more windows of this class.
                if (classNode.Nodes.Count == 0)
                {
                    appsTreeView.Nodes.RemoveAt(i);
                }
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
        }

        private void CheckAll(bool check)
        {
            foreach (TreeNode classNode in appsTreeView.Nodes)
            {
                classNode.Checked = check;
            }
        }

        private void checkAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAll(true);
        }

        private void uncheckAllLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAll(false);
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            // Disable the timer once we get a tick event to prevent re-entrancy. We'll enable it
            // once we're done.
            
            refreshTimer.Enabled = false;
            RefreshWindows();
            refreshTimer.Enabled = true;
        }
    }
}