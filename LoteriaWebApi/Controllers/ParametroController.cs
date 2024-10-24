using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace RutinasWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParametroController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IParametroLN gObjParametroLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public ParametroController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("RutinasBD");
            gObjParametroLN = new ParametroLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Parametro>> recParametro_PA()
        {
            List<Parametro> lObjRespuesta = new List<Parametro>();

            try
            {
                lObjRespuesta = gObjParametroLN.recParametroPA();

                // Convierte la lista de Parametro a una lista de UserDto excluyendo el campo 'Clave'
                var ListaParametro = lObjRespuesta.Select(u => new Parametro
                {
                    IdParametro = u.IdParametro,
                    Color1 = u.Color1,
                    Color2 = u.Color2,
                    ConsecutivoRutina = u.ConsecutivoRutina,
                    TipoImpresion = u.TipoImpresion,


    }).ToList();

                return Ok(ListaParametro); // Retorna un HTTP 200 con la lista de Parametros.
            }
            catch (Exception lEx)
            {
                // Registrar el error, de manera similar al código anterior en .NET Framework
                gObjError.Error("SE HA PRODUCIDO UN ERROR. Detalle: " + lEx.Message +
                                "// " + (lEx.InnerException?.Message ?? "No Inner Exception") +
                                ". Método: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());

                // Retornar un InternalServerError con un código HTTP 500
                return StatusCode(StatusCodes.Status500InternalServerError, lEx.Message);
            }
        }




        [Route("[action]/{pIdParametro}")]
        [HttpGet]
        public Parametro recParametroXId_PA(int pIdParametro)
        {
            Parametro lObjRespuesta = new Parametro();

            try
            {
                lObjRespuesta = gObjParametroLN.recParametroPAXId(pIdParametro);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }


        [Route("[action]")]
        [HttpPut]
        public IActionResult modParametroPA([FromBody] Parametro pParametro)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjParametroLN.modParametroPA(pParametro);
                    return Ok(pParametro);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
        }

    }

}
