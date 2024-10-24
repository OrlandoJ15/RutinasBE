using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class AccionLN : IAccionLN
    {

        private readonly IAccionAD gObjAccion_PA_AD;

        public AccionLN(IConfiguration _configuration)
        {
            gObjAccion_PA_AD = new AccionAD(_configuration);
        }
        public List<Accion> recAccionPA()
        {
            List<Accion> lObjRespuesta = new List<Accion>();

            try
            {
                lObjRespuesta = gObjAccion_PA_AD.recAccionPA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public Accion recAccionPAXId(int pIdAccion)
        {
            Accion lObjRespuesta = new Accion();

            try
            {
                lObjRespuesta = gObjAccion_PA_AD.recAccionPAXId(pIdAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool modAccionPA(Accion pAccion)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjAccion_PA_AD.modAccionPA(pAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool insAccionPA(Accion pAccion)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjAccion_PA_AD.insAccionPA(pAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delAccionPA(Accion pAccion)
        {
            throw new NotImplementedException();
        }
    }
}
