using Everis.HandsOnWpf.Modulos._01_Introducao;
using Everis.HandsOnWpf.Modulos._02_EstruturaBasica;
using Everis.HandsOnWpf.Modulos._03_Layouts;
using Everis.HandsOnWpf.Modulos._04_Formularios;
using Everis.HandsOnWpf.Modulos._05_Eventos;
using Everis.HandsOnWpf.Modulos._06_Formatacao;
using Everis.HandsOnWpf.Modulos._07_Binding;
using Everis.HandsOnWpf.Modulos._08_EstruturasRepeticao;
using Everis.HandsOnWpf.Modulos._09_Templates;
using Everis.HandsOnWpf.Modulos._10_MVVM.View;
using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.View;
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

namespace Everis.HandsOnWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ExemploDataGridClick(object sender, EventArgs e)
        {
            new ExemploDataGrid().Show();
        }

        public void ExemploListViewClick(object sender, EventArgs e)
        {
            new ExemploList().Show();
        }

        public void ExemploItemsControlClick(object sender, EventArgs e)
        {
            new ExemploItemsControl().Show();
        }

        public void ExemploDataTemplateClick(object sender, EventArgs e)
        {
            new ExemploDataTemplate().Show();
        }

        public void ExemploControlTemplateClick(object sender, EventArgs e)
        {
            new ExemploControlTemplate().Show();
        }

        public void ExemploGridClick(object sender, EventArgs e)
        {
            new ExemploGridPanel().Show();
        }

        public void IntroducaoPaginasClick(object sender, EventArgs e)
        {
            new IntroducaoPaginas().Show();
        }

        public void ExemploStackPanelClick(object sender, EventArgs e)
        {
            new ExemploStackPanel().Show();
        }

        public void ExemploWrapPanelClick(object sender, EventArgs e)
        {
            new ExemploWrapPanel().Show();
        }

        public void ExemploDockPanelClick(object sender, EventArgs e)
        {
            new ExemploDockPanel().Show();
        }

        public void ExemploJuncaoClick(object sender, EventArgs e)
        {
            new ExemploJuncao().Show();
        }

        public void IntroducaoJanelaDialogoClick(object sender, EventArgs e)
        {
            new ExemploDialog().ShowDialog();
        }

        public void ExemploFormularioClick(object sender, EventArgs e)
        {
            new ExemploFormulario().Show();
        }

        public void ExemploEventosClick(object sender, EventArgs e)
        {
            new ExemploEventos().Show();
        }

        public void EstruturaBasicaClick(object sender, EventArgs e)
        {
            new Window1().Show();
        }


        public void ExemploCanvasClick(object sender, EventArgs e)
        {
            new ExemploCanvasPanel().Show();
        }

        public void ExemploFormatacaoClick(object sender, EventArgs e)
        {
            new ExemploFormatacao().Show();
        }

        public void ExemploBindingClick(object sender, EventArgs e)
        {
            new ExemploBinding().Show();
        }

        public void ExemploMVVMClick(object sender, EventArgs e)
        {
            new ExemploMVVMView().Show();
        }

        public void ExemploInjecaoDependenciaClick(object sende, EventArgs e)
        {
            new ExemploDIView().Show();
        }
    }
}
