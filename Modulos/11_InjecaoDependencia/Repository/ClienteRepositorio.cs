using Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.HandsOnWpf.Modulos._11_InjecaoDependencia.Repository
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public List<Cliente> ListarClientes()
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
            return clientes;
        }
    }
}
