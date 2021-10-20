using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CalcWPFNail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {            
            InitializeComponent();
            ValorTotal = 0;
            DataContext = this;
        }

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

        public int ValorTotal { get; set; }

        public string SinalAnterior { get; set; }

        private string strValor;

        public string Valor
        {
            get { return strValor; }
            set
            {
                strValor = value;
                RaisePropertyChanged("Valor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();

            //char[] ids = s.ToCharArray();
            ProcessKey(s);
        }


        private void OperBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation(((Button)sender).Name.ToString());
        }


        public void ProcessKey(string c)
        {
            Valor += c;

            //switch (c)
            //{
            //    case "+":
            //        Valor += c;
            //        break;
            //    case "-":
            //        Valor -= c;
            //        break;
            //    case "*":
            //        //Valor *= c;
            //        break;
            //    case "/":
            //        //Valor /= c;
            //        break;
            //    default:
            //        Valor = c;
            //        break;
            //if (EraseDisplay)
            //{
            //    Display = string.Empty;
            //    EraseDisplay = false;
            //}
            //AddToDisplay(c);
        }


        public void ProcessOperation(string s)
        {
            //Double d = 0.0;
            switch (s)
            {
                case "BPM":
                    //LastOper = Operation.Negate;
                    //LastValue = Display;
                    //CalcResults();
                    //LastValue = Display;
                    //EraseDisplay = true;
                    //LastOper = Operation.None;
                    break;
                case "BDevide":

                    //if (EraseDisplay)    //espera por um digito
                    //{
                    //    LastOper = Operation.Devide;
                    //    break;
                    //}
                    //CalcResults();
                    //LastOper = Operation.Devide;
                    //LastValue = Display;
                    //EraseDisplay = true;
                    SalvarInformacao(int.Parse(Valor));
                    SinalAnterior = "/";
                    Valor = string.Empty;

                    break;
                case "BMultiply":

                    //if (EraseDisplay)     //espera por um digito
                    //{
                    //    LastOper = Operation.Multiply;
                    //    break;
                    //}
                    //CalcResults();
                    //LastOper = Operation.Multiply;
                    //LastValue = Display;
                    //EraseDisplay = true; 
                    SalvarInformacao(int.Parse(Valor));
                    SinalAnterior = "*";
                    Valor = string.Empty;
                    break;
                case "BMinus":
                    //if (EraseDisplay)      //espera por um digito
                    //{
                    //    LastOper = Operation.Subtract;
                    //    break;
                    //}
                    //CalcResults();
                    //LastOper = Operation.Subtract;
                    //LastValue = Display;
                    //EraseDisplay = true;   
                    SalvarInformacao(int.Parse(Valor));
                    SinalAnterior = "-";
                    Valor = string.Empty;
                    break;
                case "BPlus":
                    //if (EraseDisplay)
                    //{    //espera por um digito
                    //    LastOper = Operation.Add;
                    //    break;
                    //}
                    //CalcResults();
                    //LastOper = Operation.Add;
                    //LastValue = Display;
                    // EraseDisplay = true;
                    SalvarInformacao(int.Parse(Valor));
                    SinalAnterior = "+";
                    Valor = string.Empty;
                    break;
                case "BEqual":
                    //if (EraseDisplay)    //espera por um digito...
                    //    break;
                    //CalcResults();
                    //EraseDisplay = true;
                    //LastOper = Operation.None;
                    //LastValue = Display;
                    ////val = Display;
                    SalvarInformacao(int.Parse(Valor));
                    Valor = ValorTotal.ToString();
                    break;
                case "BSqrt":
                    //LastOper = Operation.Sqrt;
                    //LastValue = Display;
                    //CalcResults();
                    //LastValue = Display;
                    //EraseDisplay = true;
                    //LastOper = Operation.None;
                    break;
                case "BPercent":
                    //if (EraseDisplay)    //espera por um digito...
                    //{  //espera por um digito...
                    //    LastOper = Operation.Percent;
                    //    break;
                    //}
                    //CalcResults();
                    //LastOper = Operation.Percent;
                    //LastValue = Display;
                    //EraseDisplay = true;
                    //LastOper = Operation.None;                
                    break;
                case "BOneOver":
                    //LastOper = Operation.OneX;
                    //LastValue = Display;
                    //CalcResults();
                    //LastValue = Display;
                    //EraseDisplay = true;
                    //LastOper = Operation.None;
                    break;
                case "BC":  //limpa tudo
                            //LastOper = Operation.None;
                            //Display = LastValue = string.Empty;
                            //Paper.Clear();
                            //UpdateDisplay();
                    break;
                case "BCE":  //limpa entrada
                             //LastOper = Operation.None;
                             //Valor = string.Empty;
                             SalvarInformacao(int.Parse(Valor));
                             Valor = string.Empty;
                             SinalAnterior = string.Empty;
                             

                    break;
                case "BMemClear":
                    //Memory = 0.0F;
                    //DisplayMemory();
                    break;
                case "BMemSave":
                    //Memory = Convert.ToDouble(Display);
                    //DisplayMemory();
                    //EraseDisplay = true;
                    break;
                case "BMemRecall":
                    //Display = /*val =*/ Memory.ToString();
                    //UpdateDisplay();
                    //EraseDisplay = false;
                    break;
                case "BMemPlus":
                    //d = Memory + Convert.ToDouble(Display);
                    //Memory = d;
                    //DisplayMemory();
                    //EraseDisplay = true;
                    break;
            }

        }

        public void SalvarInformacao(int valor)
        {
            switch (SinalAnterior)
            {
                case "+":
                    ValorTotal += valor;
                    break;
                case "-":
                    ValorTotal -= valor;
                    break;
                case "*":
                    ValorTotal *= valor;
                    break;
                case "/":
                    ValorTotal /= valor;
                    break;               
                default:
                    ValorTotal = valor;
                    break;

            }




        }


    }
}
