using Everis.HandsOnWpf.Modulos._10_MVVM.ViewModel;
using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Model;
using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Repository;
using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.ViewModel
{
    public class ExemploDIViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Cliente> _clientes;
        private ObservableCollection<TipoCliente> _tiposCliente;
        private Cliente _clienteSelecionado;

        public IClienteRepositorio ClienteRepositorio { get; set; }

        public ITipoClienteRepositorio TipoClienteRepositorio { get; set; }

        public INotificationService NotificationService { get; set; }

        public ExemploDIViewModel(IClienteRepositorio clienteRepositorio, ITipoClienteRepositorio tipoClienteRepositorio, INotificationService notificationService)
        {
            ClienteRepositorio = clienteRepositorio;
            TipoClienteRepositorio = tipoClienteRepositorio;
            NotificationService = notificationService;
        }

        public void CarregarDados()
        {
            Clientes = new ObservableCollection<Cliente>(ClienteRepositorio.ListarClientes());
            TiposCliente = new ObservableCollection<TipoCliente>(TipoClienteRepositorio.ListarTiposClientes());
        }

        public ICommand SalvarCommand
        {
            get
            {
                return new RelayCommand(Salvar);
            }
        }

        public void Salvar(object p)
        {
            NotificationService.ShowInfo("Cliente Salvo com Sucesso", "Sucesso!");
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
