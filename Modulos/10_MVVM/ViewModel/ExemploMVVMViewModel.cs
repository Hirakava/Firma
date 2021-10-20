using Everis.HandsOnWpf.Modulos._10_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Everis.HandsOnWpf.Modulos._10_MVVM.ViewModel
{
    public class ExemploMVVMViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Cliente> _clientes;
        private ObservableCollection<TipoCliente> _tiposCliente;
        private Cliente _clienteSelecionado;

        public ExemploMVVMViewModel()
        {
            
        }

        public void CarregarDados()
        {
            List<Cliente> clientes = new List<Cliente>();
            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente()
                {
                    ID = i.ToString(),
                    Nome = "CLiente " + i.ToString(),
                    CPF = "336.972.158-" + i.ToString().PadLeft(2, '0'),
                    Telefone = "(11) 99905-14" + i.ToString().PadLeft(2, '0'),
                    TipoClienteID = "1"
                };
                clientes.Add(cliente);
            }
            Clientes = new ObservableCollection<Cliente>(clientes);
            TiposCliente = new ObservableCollection<TipoCliente>()
            {
                new TipoCliente(){ID="1",Nome="Comum"},
                new TipoCliente(){ID="2", Nome="Premium"}
            };
        }

        public ObservableCollection<Cliente> Clientes { get => _clientes; set { _clientes = value; NotifyChange(nameof(Clientes)); } }

        public Cliente ClienteSelecionado { get => _clienteSelecionado; set { _clienteSelecionado = value; NotifyChange(nameof(ClienteSelecionado)); } }

        public ObservableCollection<TipoCliente> TiposCliente { get => _tiposCliente; set { _tiposCliente = value; NotifyChange(nameof(TiposCliente)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChange(String propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
