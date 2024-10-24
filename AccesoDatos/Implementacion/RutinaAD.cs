using AccesoDatos.DBContext;
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class RutinaAD : IRutinaAD
    {
                private readonly IConfiguration _configuration;

        public RutinaAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Rutina> recRutinaPA()
       {
            List<Rutina> lObjRespuesta = new List<Rutina>();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recRutinaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Rutina lobjDatosRutina = new Rutina();
                        lobjDatosRutina.IdRutina = Convert.ToInt32(lReader["idRutina"]);
                        lobjDatosRutina.IdCliente = Convert.ToInt32(lReader["idCliente"]);
                        lobjDatosRutina.NombreCliente = lReader["nombreCliente"].ToString();
                        lobjDatosRutina.NombreRutina = lReader["nombreRutina"].ToString();
                        lobjDatosRutina.FechaInicio = Convert.ToDateTime(lReader["fechaInicio"]);
                        lobjDatosRutina.FechaFin = Convert.ToDateTime(lReader["fechaFin"]);
                        lobjDatosRutina.Creado = Convert.ToDateTime(lReader["creado"]);
                        lObjRespuesta.Add(lobjDatosRutina);
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

        public Rutina recRutinaPAXId(int pIdRutina)
        {
            Rutina lObjRespuesta = new Rutina();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recRutinaXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutina", pIdRutina));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {

                        lObjRespuesta.IdRutina = Convert.ToInt32(lReader["idRutina"]);
                        lObjRespuesta.IdCliente = Convert.ToInt32(lReader["idCliente"]);
                        lObjRespuesta.NombreCliente = lReader["nombreCliente"].ToString();
                        lObjRespuesta.NombreRutina = lReader["nombreRutina"].ToString();
                        lObjRespuesta.FechaInicio = Convert.ToDateTime(lReader["fechaInicio"]);
                        lObjRespuesta.FechaFin = Convert.ToDateTime(lReader["fechaFin"]);
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

        public bool insRutinaPA(Rutina pRutinaPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insRutinaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutina", pRutinaPA.IdRutina));
                    lCmd.Parameters.Add(new SqlParameter("@idCliente", pRutinaPA.IdCliente));
                    lCmd.Parameters.Add(new SqlParameter("@nombreRutina", pRutinaPA.NombreRutina));
                    lCmd.Parameters.Add(new SqlParameter("@fechaInicio", pRutinaPA.FechaInicio));
                    lCmd.Parameters.Add(new SqlParameter("@fechaFin", pRutinaPA.FechaFin));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pRutinaPA.Creado));
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

        public bool modRutinaPA(Rutina pRutinaPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modRutinaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutina", pRutinaPA.IdRutina));
                    lCmd.Parameters.Add(new SqlParameter("@idCliente", pRutinaPA.IdCliente));
                    lCmd.Parameters.Add(new SqlParameter("@nombreRutina", pRutinaPA.NombreRutina));
                    lCmd.Parameters.Add(new SqlParameter("@fechaInicio", pRutinaPA.FechaInicio));
                    lCmd.Parameters.Add(new SqlParameter("@fechaFin", pRutinaPA.FechaFin));
                    lCmd.Parameters.Add(new SqlParameter("@creado", pRutinaPA.Creado));
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

        public bool delRutinaPA(Rutina pRutinaPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delRutinaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idRutina", pRutinaPA.IdRutina));
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
