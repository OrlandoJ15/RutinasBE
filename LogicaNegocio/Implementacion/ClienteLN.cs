using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class ClienteLN : IClienteLN
    {
        
        private readonly IClienteAD gObjCliente_PA_AD;

        public ClienteLN(IConfiguration _configuration)
        {
            gObjCliente_PA_AD = new ClienteAD(_configuration);
        }
        public List<Cliente> recClientePA()
        {
            List<Cliente> lObjRespuesta = new List<Cliente>();

            try
            {
                lObjRespuesta = gObjCliente_PA_AD.recClientePA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public Cliente recClientePAXId(int pIdCliente)
        {
            Cliente lObjRespuesta = new Cliente();

            try
            {
                lObjRespuesta = gObjCliente_PA_AD.recClientePAXId(pIdCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insClientePA(Cliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjCliente_PA_AD.insClientePA(pCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modClientePA(Cliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjCliente_PA_AD.modClientePA(pCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delClientePA(Cliente pCliente)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjCliente_PA_AD.delClientePA(pCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public List<Cliente> recUClientePA()
        {
            throw new NotImplementedException();
        }
    }
}
