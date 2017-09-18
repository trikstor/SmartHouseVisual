using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHouseVisual
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private string sometext;
        private ButtonLightingCond cmd;

        private void Slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            sometext = (int)tempSlider.Value + " C";
            txt.Text = sometext;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            cmd.ChangeCond((Button)button1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            cmd.ChangeCond((Button)button2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            cmd.ChangeCond((Button)button3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            cmd.ChangeCond((Button)button4);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Button> buttonList = new List<Button>();

            buttonList.Add((Button)button1);
            buttonList.Add((Button)button2);
            buttonList.Add((Button)button3);
            buttonList.Add((Button)button4);

            cmd = new ButtonLightingCond(buttonList);

            cmd.ChangeCond((Button)button1);
            cmd.ChangeCond((Button)button2);
            cmd.ChangeCond((Button)button3);
            cmd.ChangeCond((Button)button4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class condPair
    {
        private bool _cond { get; set; }
        private Button _button { get; set; }

        public condPair(bool cond, Button button)
        {
            this._cond = cond;
            this._button = button;
        }

        public bool cond { get { return _cond; } set { _cond = value; } }
        public Button button { get { return _button; } }
    }

    public abstract class Condition : Window
    {
        protected List<condPair> _objCond = new List<condPair>();

        protected void ChangeColor(int ind)
        {
            Style buttonStyleOff = new Style();
            Style buttonStyleOn = new Style();

            buttonStyleOff.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Red) });
            buttonStyleOn.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Green) });

            if (_objCond[ind].cond)
                _objCond[ind].button.Style = buttonStyleOn;
            else
                _objCond[ind].button.Style = buttonStyleOff;
        }

        public int Search(Button but)
        {
            int ind = 0;
            foreach (condPair obj in _objCond)
            {
                if (obj.button == but)
                    break;
                ind++;
            }
            return ind;
        }

        public void ChangeCond(Button currBut)
        {
            int ind = Search(currBut);

            if (_objCond[ind].cond)
                _objCond[ind].cond = false;
            else
                _objCond[ind].cond = true;

            ChangeColor(ind);
            ChangeCondMet();
        }

        public abstract bool ChangeCondMet();
    }

    public class ButtonLightingCond : Condition
    {
        public ButtonLightingCond(List<Button> bObj, bool cond = false)
        {
            foreach (Button but in bObj)
            {
                condPair currPair = new condPair(cond, but);
                _objCond.Add(currPair);
            }
        }

        public override bool ChangeCondMet()
        {
            return true;
        }
    }
}
