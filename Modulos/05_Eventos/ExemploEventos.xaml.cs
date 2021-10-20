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

namespace Everis.HandsOnWpf.Modulos._05_Eventos
{
    /// <summary>
    /// Interaction logic for ExemploEventos.xaml
    /// </summary>
    public partial class ExemploEventos : Window
    {
        public ExemploEventos()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                MessageBox.Show("Enter pressionado. Conteúdo\n:"+nomeCliente.Text, "aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if(e.Key == Key.Escape)
            {
                nomeCliente.Text = String.Empty;
            }
        }

        private void nomeCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtNomeCliente.Text = nomeCliente.Text;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtEstadoCivil.Text = (cmbEstadoCivil.SelectedItem as ComboBoxItem).Content.ToString();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txtDataNascimento.Text = dpDataNascimento.SelectedDate?.ToString();
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            txtRenda.Text = Math.Round(slRendaFamiliar.Value).ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar dados
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            //Encerrar processos 
            MessageBox.Show("Janela fechada com sucesso");
        }
    }
}
