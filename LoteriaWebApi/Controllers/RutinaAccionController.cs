using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace RutinasWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RutinaAccionController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IRutinaAccionLN gObjRutinaAccionLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public RutinaAccionController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("RutinasBD");
            gObjRutinaAccionLN = new RutinaAccionLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<RutinaAccion>> recRutinaAccion_PA()
        {
            List<RutinaAccion> lObjRespuesta = new List<RutinaAccion>();

            try
            {
                lObjRespuesta = gObjRutinaAccionLN.recRutinaAccionPA();

                // Convierte la lista de RutinaAccion a una lista de UserDto excluyendo el campo 'Clave'
                var ListaRutinaAccion = lObjRespuesta.Select(u => new RutinaAccion
                {
                    IdRutina = u.IdRutina,
                    IdAccion = u.IdAccion,
                    SetsAccion = u.SetsAccion,
                    RepsAccion = u.RepsAccion,
                    PesoAccion = u.PesoAccion,
                    IdRutinaAccion = u.IdRutinaAccion,

    }).ToList();

                return Ok(ListaRutinaAccion); // Retorna un HTTP 200 con la lista de RutinaAccions.
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




        [Route("[action]/{pIdRutinaAccion}")]
        [HttpGet]
        public RutinaAccion recRutinaAccionXId_PA(int pIdRutinaAccion)
        {
            RutinaAccion lObjRespuesta = new RutinaAccion();

            try
            {
                lObjRespuesta = gObjRutinaAccionLN.recRutinaAccionPAXId(pIdRutinaAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insRutinaAccionPA([FromBody] RutinaAccion pRutinaAccion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjRutinaAccionLN.insRutinaAccionPA(pRutinaAccion);
                    return Ok(pRutinaAccion);
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

        [Route("[action]")]
        [HttpPut]
        public IActionResult modRutinaAccionPA([FromBody] RutinaAccion pRutinaAccion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjRutinaAccionLN.modRutinaAccionPA(pRutinaAccion);
                    return Ok(pRutinaAccion);
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

        [Route("[action]/{pIdRutinaAccion}")]
        [HttpDelete]
        public IActionResult delRutinaAccionPA(int pIdRutinaAccion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lRutinaAccion = gObjRutinaAccionLN.recRutinaAccionPAXId(pIdRutinaAccion);
                    if (lRutinaAccion != null)
                    {
                        gObjRutinaAccionLN.delRutinaAccionPA(lRutinaAccion);
                        return Ok(lRutinaAccion);
                    }
                    else
                    {
                        return BadRequest();
                    }
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
