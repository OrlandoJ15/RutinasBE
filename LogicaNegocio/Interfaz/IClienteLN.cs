

using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IClienteLN
    {
        List<Cliente> recUClientePA();
        Cliente recClientePAXId(int pIdCliente);
        bool insClientePA(Cliente pCliente);
        bool modClientePA(Cliente pCliente);
        bool delClientePA(Cliente pCliente);
        List<Cliente> recClientePA();
    }
}
