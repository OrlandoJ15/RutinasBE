using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IClienteAD
    {
        
        List<Cliente> recClientePA();
        Cliente recClientePAXId(int pIdCliente);
        bool insClientePA(Cliente pClientePA);
        bool modClientePA(Cliente pClientePA);
        bool delClientePA(Cliente pClientePA);
        
    }
}
