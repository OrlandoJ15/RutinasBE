using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace RutinasWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IUsuarioLN gObjUsuarioLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public UsuarioController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("RutinasBD");
            gObjUsuarioLN = new UsuarioLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Usuario>> recUsuario_PA()
        {
            List<Usuario> lObjRespuesta = new List<Usuario>();

            try
            {
                lObjRespuesta = gObjUsuarioLN.recUsuarioPA();

                // Convierte la lista de Usuario a una lista de UserDto excluyendo el campo 'Clave'
                var ListaUsuario = lObjRespuesta.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Creado = u.Creado,
                    Clave = u.Clave, 

                }).ToList();

                return Ok(ListaUsuario); // Retorna un HTTP 200 con la lista de Usuarios.
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




        [Route("[action]/{pIdUsuario}")]
        [HttpGet]
        public Usuario recUsuarioXId_PA(int pIdUsuario)
        {
            Usuario lObjRespuesta = new Usuario();

            try
            {
                lObjRespuesta = gObjUsuarioLN.recUsuarioPAXId(pIdUsuario);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insUsuarioPA([FromBody] Usuario pUsuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjUsuarioLN.insUsuarioPA(pUsuario);
                    return Ok(pUsuario);
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
        public IActionResult modUsuarioPA([FromBody] Usuario pUsuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjUsuarioLN.modUsuarioPA(pUsuario);
                    return Ok(pUsuario);
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

        [Route("[action]/{pIdUsuario}")]
        [HttpDelete]
        public IActionResult delUsuarioPA(int pIdUsuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lUsuario = gObjUsuarioLN.recUsuarioPAXId(pIdUsuario);
                    if (lUsuario != null)
                    {
                        gObjUsuarioLN.delUsuarioPA(lUsuario);
                        return Ok(lUsuario);
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
