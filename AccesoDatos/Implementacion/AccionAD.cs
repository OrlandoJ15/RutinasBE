using AccesoDatos.DBContext;
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class AccionAD : IAccionAD
    {

        private readonly IConfiguration _configuration;

        public AccionAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<Accion> recAccionPA()
       {
            List<Accion> lObjRespuesta = new List<Accion>();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Accion lobjDatosAccion = new Accion();
                        lobjDatosAccion.IdAccion = Convert.ToInt32(lReader["idAccion"]);
                        lobjDatosAccion.NombreAccion = lReader["nombreAccion"].ToString();
                        lobjDatosAccion.GrupoMusculo = lReader["grupoMusculo"].ToString();
                        lobjDatosAccion.Descripcion = lReader["descripcion"].ToString();
                        lobjDatosAccion.Creado = Convert.ToDateTime(lReader["creado"]);
                        lObjRespuesta.Add(lobjDatosAccion);
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

        public Accion recAccionPAXId(int pIdAccion)
        {
            Accion lObjRespuesta = new Accion();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recAccionXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idAccion", pIdAccion));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {

                        lObjRespuesta.IdAccion = Convert.ToInt32(lReader["idAccion"]);
                        lObjRespuesta.NombreAccion = lReader["nombreAccion"].ToString();
                        lObjRespuesta.GrupoMusculo = lReader["grupoMusculo"].ToString();
                        lObjRespuesta.Descripcion = lReader["descripcion"].ToString();
                        lObjRespuesta.Creado = Convert.ToDateTime(lReader["creado"]);

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

        public bool insAccionPA(Accion pAccionPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@nombreAccion", pAccionPA.NombreAccion));
                    lCmd.Parameters.Add(new SqlParameter("@grupoMusculo", pAccionPA.GrupoMusculo));
                    lCmd.Parameters.Add(new SqlParameter("@descripcion", pAccionPA.Descripcion));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pAccionPA.Creado));
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

        public bool modAccionPA(Accion pAccionPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idAccion", pAccionPA.IdAccion));
                    lCmd.Parameters.Add(new SqlParameter("@nombreAccion", pAccionPA.NombreAccion));
                    lCmd.Parameters.Add(new SqlParameter("@grupoMusculo", pAccionPA.GrupoMusculo));
                    lCmd.Parameters.Add(new SqlParameter("@descripcion", pAccionPA.Descripcion));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pAccionPA.Creado));
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

        public bool delRutinaPA(Accion pAccionPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idAccion", pAccionPA.IdAccion));
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

        public bool delAccionPA(Accion pRAccionPA)
        {
            throw new NotImplementedException();
        }
    }
}
