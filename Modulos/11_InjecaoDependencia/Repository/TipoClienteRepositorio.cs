using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Repository
{
    public class TipoClienteRepositorio : ITipoClienteRepositorio
    {
        public List<TipoCliente> ListarTiposClientes()
        {
            return new List<TipoCliente>()
            {
                new TipoCliente(){ID=1,Nome="Comum"},
                new TipoCliente(){ID=2, Nome="Premium"}
            };
        }
    }
}
