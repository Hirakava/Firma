using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Kernel
{
    public class ViewModelLocator
    {
        public ExemploDIViewModel ExemploDIViewModel
        {
            get
            {
                return IocKernel.Get<ExemploDIViewModel>();
            }
        }
    }
}
