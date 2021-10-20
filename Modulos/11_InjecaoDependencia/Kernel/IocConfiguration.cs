using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Repository;
using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Services;
using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.ViewModel;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Kernel
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IClienteRepositorio>().To<ClienteRepositorio>().InSingletonScope();

            Bind<ITipoClienteRepositorio>().To<TipoClienteRepositorio>().InSingletonScope();

            Bind<INotificationService>().To<NotificationService>().InSingletonScope();

            Bind<ExemploDIViewModel>().ToSelf().InTransientScope();
        }
    }
}
