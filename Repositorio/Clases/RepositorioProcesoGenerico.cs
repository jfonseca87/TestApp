using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Repositorio.Interfaces;
using Utilidades.Recursos;

namespace Repositorio.Clases
{
    public class RepositorioProcesoGenerico : IRepositorioProcesoGenerico
    {
        public string ConsultarRegistro(string campos, string valoresFiltro, string conexion)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[conexion].ConnectionString))
            {
                string respuesta = string.Empty;
                SqlCommand cmd = new SqlCommand(BasesDatos.ConsultarGenerico, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Campos", SqlDbType.VarChar).Value = campos;
                cmd.Parameters.Add("@Parametros", SqlDbType.VarChar).Value = valoresFiltro;

                using (SqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        respuesta = dtr.GetString(0);
                    }
                }

                return respuesta;
            }
        }

        public void EliminarRegistro(string valores, string conexion)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[conexion].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(BasesDatos.EliminaGenerico, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Parametros", SqlDbType.VarChar).Value = valores;
                cmd.ExecuteNonQuery();
            }
        }

        public void GuardarRegistro(string campos, string valores, bool esNuevo, string conexion)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[conexion].ConnectionString))
            {
                if (esNuevo)
                {
                    SqlCommand cmd = new SqlCommand(BasesDatos.GuardarGenerico, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Parametros", SqlDbType.VarChar).Value = valores;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(BasesDatos.ActualizaGenerico, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Campos", SqlDbType.VarChar).Value = campos;
                    cmd.Parameters.Add("@Parametros", SqlDbType.VarChar).Value = valores;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
