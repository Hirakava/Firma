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

namespace CalculadoraWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private enum Operation
        {
            None,
            Devide,
            Multiply,
            Subtract,
            Add,
            Percent,
            Sqrt,
            OneX,
            Negate
        }
        private Operation LastOper;
        private string _display;
        private string _last_val;
        private string _mem_val;
        private bool _erasediplay;

        //flag to erase or just add to current display flag
        private bool EraseDisplay
        {
            get
            {
                return _erasediplay;

            }
            set
            {
                _erasediplay = value;
            }
        }
        //Get/Set Memory cell value
        private Double Memory
        {
            get
            {
                if (_mem_val == string.Empty)
                    return 0.0;
                else
                    return Convert.ToDouble(_mem_val);
            }
            set
            {
                _mem_val = value.ToString();
            }
        }
        //ultimo valor entrado
        private string LastValue
        {
            get
            {
                if (_last_val == string.Empty)
                    return "0";
                return _last_val;

            }
            set
            {
                _last_val = value;
            }
        }
        //O valor atual exibido
        private string Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
            }
        }

        // tratamento de evento
        private void OnWindowKeyDown(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string s = e.Text;
            char c = (s.ToCharArray())[0];
            e.Handled = true;

            if ((c >= '0' && c <= '9') || c == '.' || c == '\b')  // '\b' é backspace
            {
                ProcessKey(c);
                return;
            }
            switch (c)
            {
                case '+':
                    ProcessOperation("BPlus");
                    break;
                case '-':
                    ProcessOperation("BMinus");
                    break;
                case '*':
                    ProcessOperation("BMultiply");
                    break;
                case '/':
                    ProcessOperation("BDevide");
                    break;
                case '%':
                    ProcessOperation("BPercent");
                    break;
                case '=':
                    ProcessOperation("BEqual");
                    break;
            }

        }
        private void DigitBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();

            char[] ids = s.ToCharArray();
            ProcessKey(ids[0]);

        }
        private void ProcessKey(char c)
        {
            if (EraseDisplay)
            {
                Display = string.Empty;
                EraseDisplay = false;
            }
            AddToDisplay(c);
        }
        private void ProcessOperation(string s)
        {
            Double d = 0.0;
            switch (s)
            {
                case "BPM":
                    LastOper = Operation.Negate;
                    LastValue = Display;
                    CalcResults();
                    LastValue = Display;
                    EraseDisplay = true;
                    LastOper = Operation.None;
                    break;
                case "BDevide":

                    if (EraseDisplay)    //espera por um digito
                    {
                        LastOper = Operation.Devide;
                        break;
                    }
                    CalcResults();
                    LastOper = Operation.Devide;
                    LastValue = Display;
                    EraseDisplay = true;
                    break;
                case "BMultiply":
                    if (EraseDisplay)     //espera por um digito
                    {
                        LastOper = Operation.Multiply;
                        break;
                    }
                    CalcResults();
                    LastOper = Operation.Multiply;
                    LastValue = Display;
                    EraseDisplay = true;
                    break;
                case "BMinus":
                    if (EraseDisplay)      //espera por um digito
                    {
                        LastOper = Operation.Subtract;
                        break;
                    }
                    CalcResults();
                    LastOper = Operation.Subtract;
                    LastValue = Display;
                    EraseDisplay = true;
                    break;
                case "BPlus":
                    if (EraseDisplay)
                    {    //espera por um digito
                        LastOper = Operation.Add;
                        break;
                    }
                    CalcResults();
                    LastOper = Operation.Add;
                    LastValue = Display;
                    EraseDisplay = true;
                    break;
                case "BEqual":
                    if (EraseDisplay)    //espera por um digito...
                        break;
                    CalcResults();
                    EraseDisplay = true;
                    LastOper = Operation.None;
                    LastValue = Display;
                    //val = Display;
                    break;
                case "BSqrt":
                    LastOper = Operation.Sqrt;
                    LastValue = Display;
                    CalcResults();
                    LastValue = Display;
                    EraseDisplay = true;
                    LastOper = Operation.None;
                    break;
                case "BPercent":
                    if (EraseDisplay)    //espera por um digito...
                    {  //espera por um digito...
                        LastOper = Operation.Percent;
                        break;
                    }
                    CalcResults();
                    LastOper = Operation.Percent;
                    LastValue = Display;
                    EraseDisplay = true;
                    //LastOper = Operation.None;
                    break;
                case "BOneOver":
                    LastOper = Operation.OneX;
                    LastValue = Display;
                    CalcResults();
                    LastValue = Display;
                    EraseDisplay = true;
                    LastOper = Operation.None;
                    break;
                case "BC":  //limpa tudo
                    LastOper = Operation.None;
                    Display = LastValue = string.Empty;
                    //Paper.Clear();
                    UpdateDisplay();
                    break;
                case "BCE":  //limpa entrada
                    LastOper = Operation.None;
                    Display = LastValue;
                    UpdateDisplay();
                    break;
                case "BMemClear":
                    Memory = 0.0F;
                    DisplayMemory();
                    break;
                case "BMemSave":
                    Memory = Convert.ToDouble(Display);
                    DisplayMemory();
                    EraseDisplay = true;
                    break;
                case "BMemRecall":
                    Display = /*val =*/ Memory.ToString();
                    UpdateDisplay();
                    EraseDisplay = false;
                    break;
                case "BMemPlus":
                    d = Memory + Convert.ToDouble(Display);
                    Memory = d;
                    DisplayMemory();
                    EraseDisplay = true;
                    break;
            }

        }

        private void OperBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation(((Button)sender).Name.ToString());
        }


        private double Calc(Operation LastOper)
        {
            double d = 0.0;

            try
            {
                switch (LastOper)
                {
                    case Operation.Devide:
                        Paper.AddArguments(LastValue + " / " + Display);
                        d = (Convert.ToDouble(LastValue) / Convert.ToDouble(Display));
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.Add:
                        Paper.AddArguments(LastValue + " + " + Display);
                        d = Convert.ToDouble(LastValue) + Convert.ToDouble(Display);
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.Multiply:
                        Paper.AddArguments(LastValue + " * " + Display);
                        d = Convert.ToDouble(LastValue) * Convert.ToDouble(Display);
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.Percent:
                        Paper.AddArguments(LastValue + " % " + Display);
                        d = (Convert.ToDouble(LastValue) * Convert.ToDouble(Display)) / 100.0F;
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.Subtract:
                        Paper.AddArguments(LastValue + " - " + Display);
                        d = Convert.ToDouble(LastValue) - Convert.ToDouble(Display);
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.Sqrt:
                        Paper.AddArguments("Sqrt( " + LastValue + " )");
                        d = Math.Sqrt(Convert.ToDouble(LastValue));
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.OneX:
                        Paper.AddArguments("1 / " + LastValue);
                        d = 1.0F / Convert.ToDouble(LastValue);
                        CheckResult(d);
                        Paper.AddResult(d.ToString());
                        break;
                    case Operation.Negate:
                        d = Convert.ToDouble(LastValue) * (-1.0F);
                        break;
                }
            }
            catch
            {
                d = 0;
                Window parent = (Window)MyPanel.Parent;
                Paper.AddResult("Error");
                MessageBox.Show(parent, "A operação não pode ser realizada", parent.Title);
            }

            return d;
        }
        private void CheckResult(double d)
        {
            if (Double.IsNegativeInfinity(d) || Double.IsPositiveInfinity(d) || Double.IsNaN(d))
                throw new Exception("Valor Ilegal");
        }

        //private void DisplayMemory()
        //{
        //    if (_mem_val != String.Empty)
        //        BMemBox.Text = "Memoria: " + _mem_val;
        //    else
        //        BMemBox.Text = "Memoria: [vazia]";
        //}
        private void CalcResults()
        {
            double d;
            if (LastOper == Operation.None)
                return;

            d = Calc(LastOper);
            Display = d.ToString();

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (Display == String.Empty)
                txt_display.Text = "0";
            else
                txt_display.Text = Display;
        }
        private void AddToDisplay(char c)
        {
            if (c == '.')
            {
                if (Display.IndexOf('.', 0) >= 0)  //already exists
                    return;
                Display = Display + c;
            }
            else
            {
                if (c >= '0' && c <= '9')
                {
                    Display = Display + c;
                }
                else
                if (c == '\b')  //backspace ?
                {
                    if (Display.Length <= 1)
                        Display = String.Empty;
                    else
                    {
                        int i = Display.Length;
                        Display = Display.Remove(i - 1, 1);  //remove o ultimo caractere
                    }
                }

            }

            UpdateDisplay();
        }

        //void OnMenuAbout(object sender, RoutedEventArgs e)
        //{
        //    Window parent = (Window)MyPanel.Parent;
        //    MessageBox.Show(parent, parent.Title + " -Adaptado por macoratti.net ", parent.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        //}
        //void OnMenuExit(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
        //void OnMenuStandard(object sender, RoutedEventArgs e)
        //{
        //    //((MenuItem)ScientificMenu).IsChecked = false;
        //    ((MenuItem)StandardMenu).IsChecked = true; //for now always Standard
        //}
        //Not implemenetd 
        //void OnMenuScientific(object sender, RoutedEventArgs e)
        //{
        //    //((MenuItem)StandardMenu).IsChecked = false; 
        //}
        //private class PaperTrail
        //{
        //    string args;

        //    public PaperTrail()
        //    {
        //    }
        //    public void AddArguments(string a)
        //    {
        //        args = a;
        //    }
        //    public void AddResult(string r)
        //    {
        //        PaperBox.Text += args + " = " + r + "\n";
        //    }
        //    public void Clear()
        //    {
        //        PaperBox.Text = string.Empty;
        //        args = string.Empty;
        //    }
        //}
    }
}

