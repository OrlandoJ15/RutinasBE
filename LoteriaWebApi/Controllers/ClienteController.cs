using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace RutinasWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IClienteLN gObjClienteLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public ClienteController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("RutinasBD");
            gObjClienteLN = new ClienteLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Cliente>> recCliente_PA()
        {
            List<Cliente> lObjRespuesta = new List<Cliente>();

            try
            {
                lObjRespuesta = gObjClienteLN.recClientePA();

                // Convierte la lista de Cliente a una lista de UserDto excluyendo el campo 'Clave'
                var ListaCliente = lObjRespuesta.Select(u => new Cliente
                {
                    IdCliente = u.IdCliente,
                    IdUsuario = u.IdUsuario,
                    NombreCliente = u.NombreCliente,
                    NombreUsuario = u.NombreUsuario,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Creado = u.Creado,
                    FechaNacimiento = u.FechaNacimiento,
                    Sexo = u.Sexo,
                    Disciplina = u.Disciplina,
                    Antecedente = u.Antecedente,
                    Descripcion = u.Descripcion,
                    Altura = u.Altura,
                    Peso = u.Peso,

    }).ToList();

                return Ok(ListaCliente); // Retorna un HTTP 200 con la lista de Clientes.
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




        [Route("[action]/{pIdCliente}")]
        [HttpGet]
        public Cliente recClienteXId_PA(int pIdCliente)
        {
            Cliente lObjRespuesta = new Cliente();

            try
            {
                lObjRespuesta = gObjClienteLN.recClientePAXId(pIdCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insClientePA([FromBody] Cliente pCliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjClienteLN.insClientePA(pCliente);
                    return Ok(pCliente);
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
        public IActionResult modClientePA([FromBody] Cliente pCliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjClienteLN.modClientePA(pCliente);
                    return Ok(pCliente);
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

        [Route("[action]/{pIdCliente}")]
        [HttpDelete]
        public IActionResult delClientePA(int pIdCliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lCliente = gObjClienteLN.recClientePAXId(pIdCliente);
                    if (lCliente != null)
                    {
                        gObjClienteLN.delClientePA(lCliente);
                        return Ok(lCliente);
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
