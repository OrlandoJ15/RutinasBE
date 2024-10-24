using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace RutinasWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccionController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IAccionLN gObjAccionLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public AccionController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("RutinasBD");
            gObjAccionLN = new AccionLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Accion>> recAccion_PA()
        {
            List<Accion> lObjRespuesta = new List<Accion>();

            try
            {
                lObjRespuesta = gObjAccionLN.recAccionPA();

                // Convierte la lista de Accion a una lista de UserDto excluyendo el campo 'Clave'
                var ListaAccion = lObjRespuesta.Select(u => new Accion
                {
                    IdAccion = u.IdAccion,
                    NombreAccion = u.NombreAccion,
                    GrupoMusculo = u.GrupoMusculo,
                    Descripcion = u.Descripcion,
                    Creado = u.Creado,

    }).ToList();

                return Ok(ListaAccion); // Retorna un HTTP 200 con la lista de Accions.
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




        [Route("[action]/{pIdAccion}")]
        [HttpGet]
        public Accion recAccionXId_PA(int pIdAccion)
        {
            Accion lObjRespuesta = new Accion();

            try
            {
                lObjRespuesta = gObjAccionLN.recAccionPAXId(pIdAccion);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insAccionPA([FromBody] Accion pAccion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjAccionLN.insAccionPA(pAccion);
                    return Ok(pAccion);
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
        public IActionResult modAccionPA([FromBody] Accion pAccion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjAccionLN.modAccionPA(pAccion);
                    return Ok(pAccion);
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

        [Route("[action]/{pIdAccion}")]
        [HttpDelete]
        public IActionResult delAccionPA(int pIdAccion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lAccion = gObjAccionLN.recAccionPAXId(pIdAccion);
                    if (lAccion != null)
                    {
                        gObjAccionLN.delAccionPA(lAccion);
                        return Ok(lAccion);
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
