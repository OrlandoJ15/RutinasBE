using AccesoDatos.DBContext;
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class UsuarioAD : IUsuarioAD
    {

        private readonly IConfiguration _configuration;

        public UsuarioAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Usuario> recUsuarioPA()
       {
            List<Usuario> lObjRespuesta = new List<Usuario>();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recUsuarioPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Usuario lobjDatosUsuario = new Usuario();
                        lobjDatosUsuario.IdUsuario = Convert.ToInt32(lReader["idUsuario"]);
                        lobjDatosUsuario.Nombre = lReader["nombre"].ToString();
                        lobjDatosUsuario.Email = lReader["email"].ToString();
                        lobjDatosUsuario.Telefono = lReader["telefono"].ToString();
                        lobjDatosUsuario.Creado = Convert.ToDateTime(lReader["creado"]);
                        lobjDatosUsuario.Clave = lReader["clave"].ToString();
                        lobjDatosUsuario.Rol = Convert.ToInt32(lReader["rol"]);
                        lObjRespuesta.Add(lobjDatosUsuario);
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

        public Usuario recUsuarioPAXId(int pIdUsuario)
        {
            Usuario lObjRespuesta = new Usuario();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recUsuarioXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idUsuario", pIdUsuario));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        
                        lObjRespuesta.IdUsuario = Convert.ToInt32(lReader["idUsuario"]);
                        lObjRespuesta.Nombre = lReader["nombre"].ToString();
                        lObjRespuesta.Email = lReader["email"].ToString();
                        lObjRespuesta.Telefono = lReader["telefono"].ToString();
                        lObjRespuesta.Creado = Convert.ToDateTime(lReader["creado"]);
                        lObjRespuesta.Clave = lReader["clave"].ToString();
                        lObjRespuesta.Rol = Convert.ToInt32(lReader["rol"]);

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

        public bool insUsuarioPA(Usuario pUsuarioPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insUsuarioPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idUsuario", pUsuarioPA.IdUsuario));
                    lCmd.Parameters.Add(new SqlParameter("@nombre", pUsuarioPA.Nombre));
                    lCmd.Parameters.Add(new SqlParameter("@email", pUsuarioPA.Email));
                    lCmd.Parameters.Add(new SqlParameter("@telefono", pUsuarioPA.Telefono));
                    lCmd.Parameters.Add(new SqlParameter("@clave", pUsuarioPA.Clave));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pUsuarioPA.Creado));
                    lCmd.Parameters.Add(new SqlParameter("@rol", pUsuarioPA.Rol));
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

        public bool modUsuarioPA(Usuario pUsuarioPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modUsuarioPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idUsuario", pUsuarioPA.IdUsuario));
                    lCmd.Parameters.Add(new SqlParameter("@nombre", pUsuarioPA.Nombre));
                    lCmd.Parameters.Add(new SqlParameter("@email", pUsuarioPA.Email));
                    lCmd.Parameters.Add(new SqlParameter("@telefono", pUsuarioPA.Telefono));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pUsuarioPA.Creado));
                    lCmd.Parameters.Add(new SqlParameter("@clave", pUsuarioPA.Clave));
                    lCmd.Parameters.Add(new SqlParameter("@rol", pUsuarioPA.Rol));
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

        public bool delUsuarioPA(Usuario pUsuarioPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delUsuarioPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idUsuario", pUsuarioPA.IdUsuario));
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
