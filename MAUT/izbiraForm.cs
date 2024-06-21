using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAUT
{
    public partial class izbiraForm : Form
    {
        private Dictionary<string, string[,]> nodeArrays;
        private List<string> alternative;
        private List<NodeData> NodeDataList;

        public izbiraForm(List<NodeData> nodeDataList, List<string> alternative)
        {
            InitializeComponent();
            this.alternative = alternative;
            NodeDataList = nodeDataList;
            GenerateLabelsAndListViews();
            
        }
        private double CalculateSum(GroupBox groupBox)
        {
            double sum = 0.0;
            foreach (Control control in groupBox.Controls)
            {
                if (control is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    string selectedItem = comboBox.SelectedItem.ToString();
                    double selectedValue;

                    if (selectedItem.Contains('-'))
                    {
                        if (double.TryParse(selectedItem.Split('-')[1].Trim(), out selectedValue))
                        {
                            sum += selectedValue;
                        }
                    }
                    else
                    {
                        if (double.TryParse(selectedItem, out selectedValue))
                        {
                            sum += selectedValue;
                        }
                    }
                }
            }
            return Math.Round(sum, 2);
        }

        private void GenerateLabelsAndListViews()
        {
            int yOffset = 10;
            foreach (string alternativeName in alternative)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = alternativeName;
                groupBox.Location = new Point(10, yOffset);
                groupBox.AutoSize = true;
                Controls.Add(groupBox);

                int innerYOffset = 40;
                List<Label> resultLabels = new List<Label>();

                foreach (NodeData nodeData in NodeDataList)
                {
                    Label nodeLabel = new Label();
                    nodeLabel.Text = $"{nodeData.NodeName}:";
                    nodeLabel.AutoSize = true;
                    nodeLabel.Location = new Point(10, innerYOffset);
                    groupBox.Controls.Add(nodeLabel);

                    TextBox nodeValueTextBox = new TextBox();
                    
                    nodeValueTextBox.Text = "0";
                    nodeValueTextBox.Location = new Point(nodeLabel.Right + 5, innerYOffset);
                    nodeValueTextBox.Size = new Size(50, 20);
                    groupBox.Controls.Add(nodeValueTextBox);

                    Label resultLabel = new Label();
                    resultLabel.Text = $"Result: ";
                    resultLabel.AutoSize = true;
                    resultLabel.Location = new Point(nodeValueTextBox.Right + 10, innerYOffset);
                    groupBox.Controls.Add(resultLabel);
                    resultLabels.Add(resultLabel);

                    Button calculateButton = new Button();
                    calculateButton.Text = "Izračunaj";
                    calculateButton.Location = new Point(resultLabel.Right + 20, innerYOffset);
                    calculateButton.Click += (sender, e) =>
                    {
                        string izbira = nodeData.SelectedFunction.ToString();

                        double minValue = double.Parse(nodeData.MinValue);
                        double maxValue = double.Parse(nodeData.MaxValue);
                        double inputValue = double.Parse(nodeValueTextBox.Text);
                        
                        double result = 0.0;

                        if (izbira == "Linearna")
                        {
                            result = CalculateLinearUtility(minValue, maxValue, inputValue) * nodeData.Number;
                        }
                        else if (izbira == "Logaritemska")
                        {
                            result = CalculateLogarithmicUtility(minValue, maxValue, inputValue) * nodeData.Number;
                        }
                        else if (izbira == "Eksponentna")
                        {
                            result = CalculateExponentialUtility(minValue, maxValue, inputValue) * nodeData.Number;
                        }

                        resultLabel.Text = $"Result: {result:F2}";
                    };
                    groupBox.Controls.Add(calculateButton);

                    innerYOffset += 30;
                }

                double sum = 0.0;

                Label sumLabel = new Label();
                sumLabel.Text = "Končana ocena alternative: ";
                sumLabel.AutoSize = true;
                sumLabel.Location = new Point(10, innerYOffset);
                groupBox.Controls.Add(sumLabel);

                Label sumValueLabel = new Label();
                sumValueLabel.Text = "0";
                sumValueLabel.AutoSize = true;
                sumValueLabel.Location = new Point(sumLabel.Right + 5, innerYOffset);
                groupBox.Controls.Add(sumValueLabel);

                Button calculateSumButton = new Button();
                calculateSumButton.Text = "Seštej";
                calculateSumButton.Location = new Point(sumValueLabel.Right + 20, innerYOffset - 2);
                calculateSumButton.Click += (sender, e) =>
                {
                    double sum = 0.0;

                    foreach (Label resultLabel in resultLabels)
                    {
                        double resultValue;
                        if (double.TryParse(resultLabel.Text.Replace("Result: ", ""), out resultValue))
                        {
                            sum += resultValue;
                        }
                    }

                    sumValueLabel.Text = sum.ToString("F2");
                };
                groupBox.Controls.Add(calculateSumButton);

                double initialSum = CalculateSum(groupBox);
                sumValueLabel.Text = initialSum.ToString("F2");

                yOffset += groupBox.Height + 20;
            }
            Button showMaxSumButton = new Button();
            showMaxSumButton.Text = "Pokazi najboljšo alternativo";
            showMaxSumButton.Location = new Point(10, yOffset);
            showMaxSumButton.Click += (sender, e) =>
            {
                string alternativeWithMaxSum = GetAlternativeWithMaxSum();
                MessageBox.Show($"Najboljša alternativa: {alternativeWithMaxSum}");
            };
            Controls.Add(showMaxSumButton);

        }

        private double CalculateLinearUtility(double minValue, double maxValue, double inputValue)
        {
            if (inputValue < minValue)
            {
                return 0.0;
            }
            else if (inputValue > maxValue)
            {
                return 1.0;
            }
            else
            {
                double range = maxValue - minValue;
                double normalizedValue = (inputValue - minValue) / range;
                return normalizedValue;
            }
        }
        private double CalculateLogarithmicUtility(double minValue, double maxValue, double inputValue)
        {
            if (inputValue < minValue)
            {
                return 0.0;
            }
            else if (inputValue > maxValue)
            {
                return 1.0;
            }
            else
            {
                double range = maxValue - minValue;
                double normalizedValue = (inputValue - minValue) / range;
                double utility = Math.Log(normalizedValue + 1, 2);
                return utility;
            }
        }
        private double CalculateExponentialUtility(double minValue, double maxValue, double inputValue)
        {
            if (inputValue < minValue)
            {
                return 0.0;
            }
            else if (inputValue > maxValue)
            {
                return 1.0;
            }
            else
            {
                double range = maxValue - minValue;
                double normalizedValue = (inputValue - minValue) / range;
                double utility = Math.Pow(2, normalizedValue) - 1;
                return utility;
            }
        }

        private string GetAlternativeWithMaxSum()
        {
            string alternativeWithMaxSum = "";
            double maxSum = 0.0;

            foreach (GroupBox groupBox in Controls.OfType<GroupBox>())
            {
                double sum = 0.0;
                foreach (Label resultLabel in groupBox.Controls.OfType<Label>())
                {
                    if (resultLabel.Text.StartsWith("Result: "))
                    {
                        double resultValue;
                        if (double.TryParse(resultLabel.Text.Replace("Result: ", ""), out resultValue))
                        {
                            sum += resultValue;
                        }
                    }
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    alternativeWithMaxSum = groupBox.Text;
                }
            }

            return alternativeWithMaxSum;
        }

    }
}
