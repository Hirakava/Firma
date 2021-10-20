using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Everis.HandsOnWpf.Modulos._08_EstruturasRepeticao
{
    /// <summary>
    /// Interaction logic for ExemploDataGrid.xaml
    /// </summary>
    public partial class ExemploDataGrid : Window, INotifyPropertyChanged
    {
        private ObservableCollection<DadoDataGrid> _dadosDataGrid;

        private DadoDataGrid _dadoDataGrid;
        public ExemploDataGrid()
        {
            InitializeComponent();

            List<DadoDataGrid> dados = new List<DadoDataGrid>();
            for(int i=0;i<=10;i++)
            {
                dados.Add(new DadoDataGrid() { ID = i.ToString(), Nome = "Cliente " + i.ToString(), Telefone = "(11) 9999-" + i.ToString().PadLeft(4, '0') });
            }
            DadosDataGrid = new ObservableCollection<DadoDataGrid>(dados);
        }

        public ObservableCollection<DadoDataGrid> DadosDataGrid { get => _dadosDataGrid; set { _dadosDataGrid = value;NotifyChange(nameof(DadosDataGrid)); } }

        public DadoDataGrid DadoDataGrid { get => _dadoDataGrid; set { _dadoDataGrid = value;NotifyChange(nameof(DadoDataGrid)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChange(String propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
