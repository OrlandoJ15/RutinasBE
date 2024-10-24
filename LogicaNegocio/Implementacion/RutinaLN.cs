using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class RutinaLN : IRutinaLN
    {
        
        private readonly IRutinaAD gObjRutina_PA_AD;

        public RutinaLN(IConfiguration _configuration)
        {
            gObjRutina_PA_AD = new RutinaAD(_configuration);
        }
        public List<Rutina> recRutinaPA()
        {
            List<Rutina> lObjRespuesta = new List<Rutina>();

            try
            {
                lObjRespuesta = gObjRutina_PA_AD.recRutinaPA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public Rutina recRutinaPAXId(int pIdRutina)
        {
            Rutina lObjRespuesta = new Rutina();

            try
            {
                lObjRespuesta = gObjRutina_PA_AD.recRutinaPAXId(pIdRutina);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insRutinaPA(Rutina pRutina)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjRutina_PA_AD.insRutinaPA(pRutina);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modRutinaPA(Rutina pRutina)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjRutina_PA_AD.modRutinaPA(pRutina);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delRutinaPA(Rutina pRutina)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjRutina_PA_AD.delRutinaPA(pRutina);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
