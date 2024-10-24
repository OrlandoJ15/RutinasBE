using AccesoDatos.DBContext;
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class ParametroAD : IParametroAD
    {
       
        private readonly IConfiguration _configuration;

        public ParametroAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Parametro> recParametroPA()
       {
            List<Parametro> lObjRespuesta = new List<Parametro>();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recParametroPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Parametro lobjDatosParametro = new Parametro();
                        lobjDatosParametro.IdParametro = Convert.ToInt32(lReader["idParametro"]);
                        lobjDatosParametro.Color1 = lReader["color1"].ToString();
                        lobjDatosParametro.Color2 = lReader["color2"].ToString();
                        lobjDatosParametro.ConsecutivoRutina = Convert.ToInt32(lReader["consecutivoRutina"]);
                        lobjDatosParametro.TipoImpresion = Convert.ToInt32(lReader["tipoImpresion"]);
                        lObjRespuesta.Add(lobjDatosParametro);
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

        public Parametro recParametroPAXId(int pIdParametro)
        {
            Parametro lObjRespuesta = new Parametro();
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recParametroXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idParametro", pIdParametro));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
               
                        lObjRespuesta.IdParametro = Convert.ToInt32(lReader["idParametro"]);
                        lObjRespuesta.Color1 = lReader["color1"].ToString();
                        lObjRespuesta.Color2 = lReader["color2"].ToString();
                        lObjRespuesta.ConsecutivoRutina = Convert.ToInt32(lReader["consecutivoRutina"]);
                        lObjRespuesta.TipoImpresion = Convert.ToInt32(lReader["tipoImpresion"]);

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

        public bool modParametroPA(Parametro pParametroPA)
        {
            bool lObjRespuesta = false;
            try
            {
                using (RutinasContext lobjCnn = new RutinasContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modParametroPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@idParametro", pParametroPA.IdParametro));
                    lCmd.Parameters.Add(new SqlParameter("@color1", pParametroPA.Color1));
                    lCmd.Parameters.Add(new SqlParameter("@color2", pParametroPA.Color2));
                    lCmd.Parameters.Add(new SqlParameter("@consecutivoRutina", pParametroPA.ConsecutivoRutina));
                    lCmd.Parameters.Add(new SqlParameter("@tipoImpresion", pParametroPA.TipoImpresion));
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
