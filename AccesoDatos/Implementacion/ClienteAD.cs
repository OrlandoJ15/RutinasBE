using AccesoDatos.DBContext;
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class ClienteAD : IClienteAD
    {
          private readonly IConfiguration _configuration;

        public ClienteAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> recClientePA()
       {
            List<Cliente> lObjRespuesta = new List<Cliente>();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Cliente lobjDatosCliente = new Cliente();
                        lobjDatosCliente.IdCliente = Convert.ToInt32(lReader["idCliente"]);
                        lobjDatosCliente.IdUsuario = Convert.ToInt32(lReader["idUsuario"]);
                        lobjDatosCliente.NombreCliente = lReader["nombreCliente"].ToString();
                        lobjDatosCliente.NombreUsuario = lReader["nombreUsuario"].ToString();
                        lobjDatosCliente.Email = lReader["email"].ToString();
                        lobjDatosCliente.Telefono = lReader["telefono"].ToString();
                        lobjDatosCliente.Creado = Convert.ToDateTime(lReader["creado"]);
                        lobjDatosCliente.FechaNacimiento = Convert.ToDateTime(lReader["fechaNacimiento"]);
                        lobjDatosCliente.Sexo = lReader["sexo"].ToString();
                        lobjDatosCliente.Disciplina = lReader["disciplina"].ToString();
                        lobjDatosCliente.Antecedente = lReader["antecedente"].ToString();
                        lobjDatosCliente.Descripcion = lReader["descripcion"].ToString();
                        lobjDatosCliente.Altura = Convert.ToInt32(lReader["altura"]);
                        lobjDatosCliente.Peso = Convert.ToInt32(lReader["peso"]);
                        lObjRespuesta.Add(lobjDatosCliente);
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public Cliente recClientePAXId(int pIdCliente)
        {
            Cliente lObjRespuesta = new Cliente();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recClienteXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idCliente", pIdCliente));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        
                        lObjRespuesta.IdCliente = Convert.ToInt32(lReader["idCliente"]);
                        lObjRespuesta.IdUsuario = Convert.ToInt32(lReader["idUsuario"]);
                        lObjRespuesta.NombreCliente = lReader["nombreCliente"].ToString();
                        lObjRespuesta.NombreUsuario = lReader["nombreUsuario"].ToString();
                        lObjRespuesta.Email = lReader["email"].ToString();
                        lObjRespuesta.Telefono = lReader["telefono"].ToString();
                        lObjRespuesta.Creado = Convert.ToDateTime(lReader["creado"]);
                        lObjRespuesta.FechaNacimiento = Convert.ToDateTime(lReader["fechaNacimiento"]);
                        lObjRespuesta.Sexo = lReader["sexo"].ToString();
                        lObjRespuesta.Disciplina = lReader["disciplina"].ToString();
                        lObjRespuesta.Antecedente = lReader["antecedente"].ToString();
                        lObjRespuesta.Descripcion = lReader["descripcion"].ToString();
                        lObjRespuesta.Altura = Convert.ToInt32(lReader["altura"]);
                        lObjRespuesta.Peso = Convert.ToInt32(lReader["peso"]);

                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool insClientePA(Cliente pClientePA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idUsuario", pClientePA.IdUsuario));
                    lCmd.Parameters.Add(new SqlParameter("@nombreCliente", pClientePA.NombreCliente));
                    lCmd.Parameters.Add(new SqlParameter("@email", pClientePA.Email));
                    lCmd.Parameters.Add(new SqlParameter("@telefono", pClientePA.Telefono));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pClientePA.Creado));
                    lCmd.Parameters.Add(new SqlParameter("@fechanacimiento", pClientePA.FechaNacimiento));
                    lCmd.Parameters.Add(new SqlParameter("@sexo", pClientePA.Sexo));
                    lCmd.Parameters.Add(new SqlParameter("@disciplina", pClientePA.Disciplina));
                    lCmd.Parameters.Add(new SqlParameter("@antecedente", pClientePA.Antecedente));
                    lCmd.Parameters.Add(new SqlParameter("@descripcion", pClientePA.Descripcion));
                    lCmd.Parameters.Add(new SqlParameter("@altura", pClientePA.Altura));
                    lCmd.Parameters.Add(new SqlParameter("@peso", pClientePA.Peso));
                    lCmd.Connection.Open();

                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modClientePA(Cliente pClientePA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idCliente", pClientePA.IdCliente));
                    lCmd.Parameters.Add(new SqlParameter("@idUsuario", pClientePA.IdUsuario));
                    lCmd.Parameters.Add(new SqlParameter("@nombreCliente", pClientePA.NombreCliente));
                    lCmd.Parameters.Add(new SqlParameter("@email", pClientePA.Email));
                    lCmd.Parameters.Add(new SqlParameter("@telefono", pClientePA.Telefono));
                    lCmd.Parameters.Add(new SqlParameter("@fechanacimiento", pClientePA.FechaNacimiento));
                    lCmd.Parameters.Add(new SqlParameter("@sexo", pClientePA.Sexo));
                    lCmd.Parameters.Add(new SqlParameter("@disciplina", pClientePA.Disciplina));
                    lCmd.Parameters.Add(new SqlParameter("@antecedente", pClientePA.Antecedente));
                    lCmd.Parameters.Add(new SqlParameter("@descripcion", pClientePA.Descripcion));
                    lCmd.Parameters.Add(new SqlParameter("@altura", pClientePA.Altura));
                    lCmd.Parameters.Add(new SqlParameter("@peso", pClientePA.Peso));
                    lCmd.Connection.Open();

                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delClientePA(Cliente pClientePA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idCliente", pClientePA.IdCliente));
                    lCmd.Connection.Open();

                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}
