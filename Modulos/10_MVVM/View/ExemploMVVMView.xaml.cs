using Everis.HandsOnWpf.Modulos._10_MVVM.ViewModel;
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
using System.Windows.Shapes;

namespace Everis.HandsOnWpf.Modulos._10_MVVM.View
{
    /// <summary>
    /// Interaction logic for ExemploMVVMView.xaml
    /// </summary>
    public partial class ExemploMVVMView : Window
    {

        public ExemploMVVMViewModel ViewModel
        {
            get
            {
                return DataContext as ExemploMVVMViewModel;
            }
        }
        public ExemploMVVMView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.CarregarDados();
        }
    }
}
