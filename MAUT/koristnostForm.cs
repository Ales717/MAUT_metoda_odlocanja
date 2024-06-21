using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MAUT
{
    public partial class koristnostForm : Form
    {
        private List<TreeNode> nodesWithNoChildren;
        private List<string> alternative;

        private List<NodeData> nodeDataList = new List<NodeData>();

        public koristnostForm(List<TreeNode> nodesWithNoChildren, List<string> alternative)
        {
            InitializeComponent();
            this.nodesWithNoChildren = nodesWithNoChildren;
            this.alternative = alternative;

            GenerateForNodes();
        }

        private void GenerateForNodes()
        {
            int yOffset = 10;
            foreach (TreeNode node in nodesWithNoChildren)
            {
                Panel panel = new Panel();
                panel.Location = new Point(10, yOffset);
                panel.Size = new Size(260, 150);
                Controls.Add(panel);

                Label label = new Label();
                label.Text = node.Text;
                label.AutoSize = true;
                label.Location = new Point(10, 5);
                panel.Controls.Add(label);

                ComboBox functionComboBox = new ComboBox();
                functionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                functionComboBox.Items.AddRange(new object[] { "Linearna", "Logaritemska", "Eksponentna" });
                functionComboBox.Location = new Point(10, label.Bottom + 10);
                functionComboBox.Size = new Size(90, 21);
                panel.Controls.Add(functionComboBox);

                Label minLabel = new Label();
                minLabel.Text = "Min:";
                minLabel.AutoSize = true;
                minLabel.Location = new Point(10, functionComboBox.Bottom + 10);
                panel.Controls.Add(minLabel);

                TextBox minTextBox = new TextBox();
                minTextBox.Location = new Point(minLabel.Right + 5, functionComboBox.Bottom + 10);
                minTextBox.Size = new Size(70, 20);
                panel.Controls.Add(minTextBox);

                Label maxLabel = new Label();
                maxLabel.Text = "Max:";
                maxLabel.AutoSize = true;
                maxLabel.Location = new Point(minTextBox.Right + 10, functionComboBox.Bottom + 10);
                panel.Controls.Add(maxLabel);

                TextBox maxTextBox = new TextBox();
                maxTextBox.Location = new Point(maxLabel.Right + 5, functionComboBox.Bottom + 10);
                maxTextBox.Size = new Size(70, 20);
                panel.Controls.Add(maxTextBox);


                Button addButton = new Button();
                addButton.Text = "Shrani";
                addButton.Location = new Point(maxTextBox.Left, maxTextBox.Bottom + 10);
                addButton.Click += (sender, e) =>
                {
                    string[] parts = node.Text.Split('-');
                    double number = 1.0;
                    if (parts.Length == 2)
                    {
                        if (double.TryParse(parts[1], out double value))
                        {
                            Console.WriteLine(value);
                            number = value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid numeric value");
                        }
                    }
                    NodeData nodeData = new NodeData
                    {
                        NodeName = node.Text,
                        SelectedFunction = functionComboBox.SelectedItem.ToString(),
                        MinValue = minTextBox.Text,
                        MaxValue = maxTextBox.Text,
                        Number = number
                    };
                    nodeDataList.Add(nodeData);

                    string listItemText = $"{nodeData.NodeName} (Min: {nodeData.MinValue}, Max: {nodeData.MaxValue}, Function: {nodeData.SelectedFunction}, Utež: {nodeData.Number})";
                    listBox1.Items.Add(listItemText);

                    MessageBox.Show("Data added to the list.");
                };
                panel.Controls.Add(addButton);

                yOffset += panel.Height + 20;
            }

            Button arrayButton = new Button();
            arrayButton.Text = "Pojdi na izbiro";
            arrayButton.Width = 240;
            arrayButton.Location = new Point(10, yOffset);
            arrayButton.Click += ArrayButton_Click;
            Controls.Add(arrayButton);
        }
        private void ArrayButton_Click(object sender, EventArgs e)
        {
            izbiraForm newForm = new izbiraForm(nodeDataList, alternative);
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("No item is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedItem = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(selectedItem);

            NodeData nodeToRemove = nodeDataList.FirstOrDefault(node =>
                $"{node.NodeName} (Min: {node.MinValue}, Max: {node.MaxValue}, Function: {node.SelectedFunction})" == selectedItem);
            if (nodeToRemove != null)
            {
                nodeDataList.Remove(nodeToRemove);
                MessageBox.Show("Item removed from the list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to remove item from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
