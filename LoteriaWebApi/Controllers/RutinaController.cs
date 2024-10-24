using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace RutinasWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IRutinaLN gObjRutinaLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public RutinaController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("RutinasBD");
            gObjRutinaLN = new RutinaLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Rutina>> recRutina_PA()
        {
            List<Rutina> lObjRespuesta = new List<Rutina>();

            try
            {
                lObjRespuesta = gObjRutinaLN.recRutinaPA();

                // Convierte la lista de Rutina a una lista de UserDto excluyendo el campo 'Clave'
                var ListaRutina = lObjRespuesta.Select(u => new Rutina
                {
                    IdRutina = u.IdRutina,
                    IdCliente = u.IdCliente,
                    NombreCliente = u.NombreCliente,
                    NombreRutina = u.NombreRutina,
                    FechaInicio = u.FechaInicio,
                    FechaFin = u.FechaFin,
                    Creado = u.Creado,

    }).ToList();

                return Ok(ListaRutina); // Retorna un HTTP 200 con la lista de Rutinas.
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




        [Route("[action]/{pIdRutina}")]
        [HttpGet]
        public Rutina recRutinaXId_PA(int pIdRutina)
        {
            Rutina lObjRespuesta = new Rutina();

            try
            {
                lObjRespuesta = gObjRutinaLN.recRutinaPAXId(pIdRutina);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insRutinaPA([FromBody] Rutina pRutina)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjRutinaLN.insRutinaPA(pRutina);
                    return Ok(pRutina);
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
        public IActionResult modRutinaPA([FromBody] Rutina pRutina)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjRutinaLN.modRutinaPA(pRutina);
                    return Ok(pRutina);
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

        [Route("[action]/{pIdRutina}")]
        [HttpDelete]
        public IActionResult delRutinaPA(int pIdRutina)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lRutina = gObjRutinaLN.recRutinaPAXId(pIdRutina);
                    if (lRutina != null)
                    {
                        gObjRutinaLN.delRutinaPA(lRutina);
                        return Ok(lRutina);
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
