using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.ViewModel;
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

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.View
{
    /// <summary>
    /// Interaction logic for ExemploDIView.xaml
    /// </summary>
    public partial class ExemploDIView : Window
    {
        public ExemploDIViewModel ViewModel
        {
            get
            {
                return DataContext as ExemploDIViewModel;
            }
        }

        public ExemploDIView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.CarregarDados();
        }
    }
}
