using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using Newtonsoft.Json;

namespace MAUT
{
    public partial class Form1 : Form
    {
        List<TreeNode> nodesWithNoChildren = new List<TreeNode>();
        List<string> alternative = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(textBox1.Text);
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("No node is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TreeNode node = treeView1.SelectedNode;

                node.Nodes.Add(textBox2.Text);
                treeView1.ExpandAll();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("No node is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (treeView1.SelectedNode.Parent == null)
            {
                MessageBox.Show("Cannot delete the root node.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            treeView1.SelectedNode.Parent.Nodes.Remove(treeView1.SelectedNode);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0)
            {
                MessageBox.Show("No nodes to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (alternative.Count() == 0)
            {
                MessageBox.Show("Izberite vsaj eno alternativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (CheckChildrenSumForAllNodes(treeView1.Nodes))
            {
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Nodes.Count == 0)
                    {
                        nodesWithNoChildren.Add(node);

                    }
                    else
                    {
                        CheckChildrenForNoChildren(node.Nodes, nodesWithNoChildren);
                    }
                }
                koristnostForm form = new koristnostForm(nodesWithNoChildren, alternative);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vrednosti utezi niso prave");
            }


        }
        private bool CheckChildrenSum(TreeNode node)
        {
            double sum = 0;

            foreach (TreeNode childNode in node.Nodes)
            {
                string childText = childNode.Text;

                int dashIndex = childText.IndexOf('-');
                if (dashIndex != -1)
                {
                    string numericalValue = childText.Substring(dashIndex + 1);

                    if (double.TryParse(numericalValue, out double value))
                    {
                        sum += value;
                    }
                }
            }

            if (Math.Abs(sum - 1) < 0.0001)
            {
                return true;
            }

            return false;
        }

        private double CalculateSumOfNodesWithNoChildren(TreeNodeCollection nodes)
        {
            double sum = 0;

            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    string nodeText = node.Text;
                    int dashIndex = nodeText.IndexOf('-');

                    if (dashIndex != -1)
                    {
                        string numericalValue = nodeText.Substring(dashIndex + 1);

                        if (double.TryParse(numericalValue, out double value))
                        {
                            sum += value;
                        }
                    }
                }
                else
                {
                    sum += CalculateSumOfNodesWithNoChildren(node.Nodes);
                }
            }

            return sum;
        }

        private bool CheckChildrenSumForAllNodes(TreeNodeCollection nodes)
        {
            double sum = CalculateSumOfNodesWithNoChildren(nodes);
            return Math.Abs(sum - 1) < 0.0001;
        }

        private void CheckChildrenForNoChildren(TreeNodeCollection nodes, List<TreeNode> nodesWithNoChildren)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    nodesWithNoChildren.Add(node);
                }
                else
                {
                    CheckChildrenForNoChildren(node.Nodes, nodesWithNoChildren);
                }
            }
        }

        private void dodajAlternativaButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox3.Text);
            alternative.Add(textBox3.Text);

        }

        private void izbrisiAlternativaButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("No item is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            alternative.Remove(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);

            if (listBox1.Items.Count == 1)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("No node is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                double number;
                if (!double.TryParse(textBox4.Text, out number) || number < 0 || number > 1)
                {
                    MessageBox.Show("Please enter a valid number between 0 and 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                treeView1.SelectedNode.Text += ("-" + textBox4.Text);
            }
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                string nodeText = selectedNode.Text;

                int dashIndex = nodeText.IndexOf('-');

                if (dashIndex != -1)
                {
                    selectedNode.Text = nodeText.Substring(0, dashIndex);
                }
            }
        }
    }
}