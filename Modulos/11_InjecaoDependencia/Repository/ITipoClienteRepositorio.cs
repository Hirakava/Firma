using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Repository
{
    public interface ITipoClienteRepositorio
    {
        List<TipoCliente> ListarTiposClientes();
    }
}
