using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NCalc;

namespace Multitaschenrechner
{
    public partial class UserControl2 : UserControl
    {
        private CoordinateSystem _coordinateSystem = new CoordinateSystem(20, 5);
        private GraphList _graphList = new GraphList();

        

        private Graph graph1;
        private Graph graph2;
        private Graph test_graph;

        private NormalCalc calc = new NormalCalc();

        private Label lblOutput = new Label();
        private int _rounds = 1;

        private Label dynamicLabel;
        private Button dynamicButton;
        private Rectangle dynamicRect;

        private int _scale = 20;
        private int _scaleStep = 5;






        public UserControl2()
        {
            InitializeComponent();

            //test_graph = new Graph("0*x");
            //this._graphList.Add(test_graph);

            this.lblOutput = lbl1;



        }

        private void KoordinatenCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this._coordinateSystem.DrawCoordinateSystem(CanvasCoordinateSystem);
            this._graphList.DrawGraphene(CanvasCoordinateSystem, dynamicLabel, this._scale);


        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            this._coordinateSystem.ZoomIn(CanvasCoordinateSystem);
            this._scale += this._scaleStep;

            this._graphList.DrawGraphene(CanvasCoordinateSystem, dynamicLabel, this._scale);

        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            this._coordinateSystem.ZoomOut(CanvasCoordinateSystem);
            int newScale = this._scale - this._scaleStep;
            if (newScale >= 1) 
            {
                this._scale = newScale;
            }

            this._graphList.DrawGraphene(CanvasCoordinateSystem, dynamicLabel, this._scale);

        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            this._rounds++;

            if (this._graphList.GetList().Count == 10)
            {
                BtnEnter.IsEnabled = true;
                return;
            }

            this._graphList.Add(new Graph(Convert.ToString( lblOutput.Content)));

            string lbl_name = $"lbl{this._rounds}";
            string btn_name = $"btn{this._rounds}";
            string rect_name = $"rect{this._rounds}";

            this.dynamicLabel = (Label)this.FindName(lbl_name);
            this.dynamicButton = (Button)this.FindName(btn_name);
            this.dynamicRect = (Rectangle)this.FindName(rect_name);

            dynamicLabel.Visibility = Visibility.Visible;
            dynamicButton.Visibility = Visibility.Visible;
            this.dynamicRect.Visibility = Visibility.Visible;
            

            this._graphList.DrawGraphene(CanvasCoordinateSystem, dynamicLabel, this._scale);

        }

        private void ButtonGraph_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;

            string output_label = button.Name.Replace("btn", "");

            string lbl_name = $"lbl{output_label}";

            dynamicLabel = (Label)this.FindName(lbl_name);

            this.lblOutput = dynamicLabel;

        }

       

















        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("0", lblOutput);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("1", lblOutput);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("2", lblOutput);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("3", lblOutput);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("4", lblOutput);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("5", lblOutput);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("6", lblOutput);
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("7", lblOutput);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("8", lblOutput);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("9", lblOutput);
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(" + ", lblOutput);
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(" - ", lblOutput);
        }

        private void BtnMal_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(" * ", lblOutput);
        }

        private void BtnDivision_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(" / ", lblOutput);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            calc.RemoveString(lblOutput);
        }

        private void BtnX_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("x", lblOutput);
        }
        private void BtnBracketOpen_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("(", lblOutput);
        }

        private void BtnBracketClose_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(")", lblOutput);
        }

        private void BtnNegativ_Click(object sender, RoutedEventArgs e)
        {
            calc.Negate(lblOutput);
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            calc.Clear(lblOutput);
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(".", lblOutput);
        }
        private void BtnPowerTwo_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("^2 ", lblOutput);
        }

        private void BtnRoot2_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("2√(", lblOutput);
        }
    }
}
