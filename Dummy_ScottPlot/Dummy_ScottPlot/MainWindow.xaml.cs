using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScottPlot;

namespace Dummy_ScottPlot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            double[] dataX = new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 };
            double[] dataY = new double[] { 0.1, 0.4, 0.9, 0.16, 0.25 };
            double[] mainSequenceX = new double[] { 0, 1 };
            double[] mainSequenceY = new double[] { 1, 0 };
            WpfPlot1.Plot.XLabel("Instability (I)");
            WpfPlot1.Plot.YLabel("Abstracness (A)");
            WpfPlot1.Plot.Title("Main Sequence");
            WpfPlot1.Plot.SetAxisLimits(0, 1, 0, 1);
            
            WpfPlot1.Plot.AddScatter(dataX, dataY, lineWidth:0);
            WpfPlot1.Plot.AddScatter(mainSequenceX, mainSequenceY, color: Palette.Category10.GetColor(3), lineWidth: 2);
            WpfPlot1.Refresh();
        }
    }
}
