using ScottPlot;
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
    public partial class LineGraphForm : Form
    {
        public LineGraphForm(string[] dataX, double[] dataY)
        {
            InitializeComponent();
            double[] xPositions = Enumerable.Range(1, dataX.Length).Select(x => (double)x).ToArray();
            formsPlot1.Plot.AddScatter(xPositions, dataY);
            formsPlot1.Plot.XTicks(xPositions, dataX);
            formsPlot1.Plot.XAxis.TickLabelStyle(rotation: 45);

            formsPlot1.Refresh();
        }
    }
}
