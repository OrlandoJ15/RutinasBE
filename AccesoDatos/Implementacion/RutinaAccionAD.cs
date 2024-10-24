using AccesoDatos.DBContext;
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class RutinaAccionAD : IRutinaAccionAD
    {

        private readonly IConfiguration _configuration;

        public RutinaAccionAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<RutinaAccion> recRutinaAccionPA()
       {
            List<RutinaAccion> lObjRespuesta = new List<RutinaAccion>();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recRutinaAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        RutinaAccion lobjDatosRutinaAccion = new RutinaAccion();
                        lobjDatosRutinaAccion.IdRutina = Convert.ToInt32(lReader["idRutina"]);
                        lobjDatosRutinaAccion.IdAccion = Convert.ToInt32(lReader["idAccion"]);
                        lobjDatosRutinaAccion.SetsAccion = Convert.ToInt32(lReader["setsAccion"]);
                        lobjDatosRutinaAccion.RepsAccion = Convert.ToInt32(lReader["repsAccion"]);
                        lobjDatosRutinaAccion.PesoAccion = Convert.ToInt32(lReader["pesoAccion"]);
                        lobjDatosRutinaAccion.IdRutinaAccion = Convert.ToInt32(lReader["idRutinaAccion"]);
                        lObjRespuesta.Add(lobjDatosRutinaAccion);
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

        public RutinaAccion recRutinaAccionPAXId(int pIdRutinaAccion)
        {
            RutinaAccion lObjRespuesta = new RutinaAccion();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recRutinaAccionXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutinaAccion", pIdRutinaAccion));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        
                        lObjRespuesta.IdRutina = Convert.ToInt32(lReader["idRutina"]);
                        lObjRespuesta.IdAccion = Convert.ToInt32(lReader["idAccion"]);
                        lObjRespuesta.SetsAccion = Convert.ToInt32(lReader["setsAccion"]);
                        lObjRespuesta.RepsAccion = Convert.ToInt32(lReader["repsAccion"]);
                        lObjRespuesta.PesoAccion = Convert.ToInt32(lReader["pesoAccion"]);
                        lObjRespuesta.IdRutinaAccion = Convert.ToInt32(lReader["idRutinaAccion"]);

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

        public bool insRutinaAccionPA(RutinaAccion pRutinaAccionPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insRutinaAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutina", pRutinaAccionPA.IdRutina));
                    lCmd.Parameters.Add(new SqlParameter("@idAccion", pRutinaAccionPA.IdAccion));
                    lCmd.Parameters.Add(new SqlParameter("@setsAccion", pRutinaAccionPA.SetsAccion));
                    lCmd.Parameters.Add(new SqlParameter("@repsAccion", pRutinaAccionPA.RepsAccion));
                    lCmd.Parameters.Add(new SqlParameter("@pesoAccion", pRutinaAccionPA.PesoAccion));
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

        public bool modRutinaAccionPA(RutinaAccion pRutinaAccionPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modRutinaAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutina", pRutinaAccionPA.IdRutina));
                    lCmd.Parameters.Add(new SqlParameter("@idAccion", pRutinaAccionPA.IdAccion));
                    lCmd.Parameters.Add(new SqlParameter("@setsAccion", pRutinaAccionPA.SetsAccion));
                    lCmd.Parameters.Add(new SqlParameter("@repsAccion", pRutinaAccionPA.RepsAccion));
                    lCmd.Parameters.Add(new SqlParameter("@pesoAccion", pRutinaAccionPA.PesoAccion));
                    lCmd.Parameters.Add(new SqlParameter("@idRutinaAccion", pRutinaAccionPA.IdRutinaAccion));
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

        public bool delRutinaAccionPA(RutinaAccion pRutinaAccionPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delRutinaAccionPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutinaAccion", pRutinaAccionPA.IdRutinaAccion));
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
