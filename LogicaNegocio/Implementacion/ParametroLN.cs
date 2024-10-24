using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class ParametroLN : IParametroLN
    {
        
        private readonly IParametroAD gObjParametro_PA_AD;

        public ParametroLN(IConfiguration _configuration)
        {
            gObjParametro_PA_AD = new ParametroAD(_configuration);
        }
        public List<Parametro> recParametroPA()
        {
            List<Parametro> lObjRespuesta = new List<Parametro>();

            try
            {
                lObjRespuesta = gObjParametro_PA_AD.recParametroPA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public Parametro recParametroPAXId(int pIdParametro)
        {
            Parametro lObjRespuesta = new Parametro();

            try
            {
                lObjRespuesta = gObjParametro_PA_AD.recParametroPAXId(pIdParametro);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool modParametroPA(Parametro pParametro)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjParametro_PA_AD.modParametroPA(pParametro);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
