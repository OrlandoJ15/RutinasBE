using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class RutinaAccionLN : IRutinaAccionLN
    {
        
        private readonly IRutinaAccionAD gObjRutinaAccion_PA_AD;

        public RutinaAccionLN(IConfiguration _configuration)
        {
            gObjRutinaAccion_PA_AD = new RutinaAccionAD(_configuration);
        }
        public List<RutinaAccion> recRutinaAccionPA()
        {
            List<RutinaAccion> lObjRespuesta = new List<RutinaAccion>();

            try
            {
                lObjRespuesta = gObjRutinaAccion_PA_AD.recRutinaAccionPA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public RutinaAccion recRutinaAccionPAXId(int pIdRutinaAccion)
        {
            RutinaAccion lObjRespuesta = new RutinaAccion();

            try
            {
                lObjRespuesta = gObjRutinaAccion_PA_AD.recRutinaAccionPAXId(pIdRutinaAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insRutinaAccionPA(RutinaAccion pRutinaAccion)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjRutinaAccion_PA_AD.insRutinaAccionPA(pRutinaAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modRutinaAccionPA(RutinaAccion pRutinaAccion)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjRutinaAccion_PA_AD.modRutinaAccionPA(pRutinaAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delRutinaAccionPA(RutinaAccion pRutinaAccion)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjRutinaAccion_PA_AD.delRutinaAccionPA(pRutinaAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
