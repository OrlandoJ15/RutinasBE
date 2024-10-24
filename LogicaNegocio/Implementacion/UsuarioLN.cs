using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class UsuarioLN : IUsuarioLN
    {
        
        private readonly IUsuarioAD gObjUsuario_PA_AD;

        public UsuarioLN(IConfiguration _configuration)
        {
            gObjUsuario_PA_AD = new UsuarioAD(_configuration);
        }
        public List<Usuario> recUsuarioPA()
        {
            List<Usuario> lObjRespuesta = new List<Usuario>();

            try
            {
                lObjRespuesta = gObjUsuario_PA_AD.recUsuarioPA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public Usuario recUsuarioPAXId(int pIdUsuario)
        {
            Usuario lObjRespuesta = new Usuario();

            try
            {
                lObjRespuesta = gObjUsuario_PA_AD.recUsuarioPAXId(pIdUsuario);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insUsuarioPA(Usuario pUsuario)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjUsuario_PA_AD.insUsuarioPA(pUsuario);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modUsuarioPA(Usuario pUsuario)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjUsuario_PA_AD.modUsuarioPA(pUsuario);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delUsuarioPA(Usuario pUsuario)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjUsuario_PA_AD.delUsuarioPA(pUsuario);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
