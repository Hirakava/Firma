using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Kernel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Everis.HandsOnWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IocKernel.Initialize(new IocConfiguration());
        }
    }
}
