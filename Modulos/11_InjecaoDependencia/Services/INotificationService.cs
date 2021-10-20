using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Services
{
    public interface INotificationService
    {
        void ShowInfo(String message, String title);

        void ShowError(String message, String title);
    }
}
