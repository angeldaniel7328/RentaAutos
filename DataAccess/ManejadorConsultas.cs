using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public struct Parametro
    {
        public string Nombre { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }

        public Parametro(string nombre, SqlDbType tipo, object valor)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Valor = valor;
        }
    }

    public static class ManejadorConsultas
    {
        public static int EjecutarSinConsulta(string procedimiento, List<Parametro> parametros)
        {
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = new SqlConnection(conexion.CadenaConexion);
            int rows;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(procedimiento, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                parametros.ForEach((parametro) => cmd.Parameters.Add(parametro.Nombre, parametro.Tipo).Value = parametro.Valor);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo realizar la operación en la base de datos");
            }
            finally
            {
                sqlConnection.Close();
            }
            return rows;
        }

        public static Dictionary<string, object> EjecutarLectura(string procedimiento, List<Parametro> parametros)
        {
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = new SqlConnection(conexion.CadenaConexion);
            SqlDataReader datos;
            Dictionary<string, object> registro = new Dictionary<string, object>();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(procedimiento, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                parametros.ForEach((parametro) => cmd.Parameters.Add(parametro.Nombre, parametro.Tipo).Value = parametro.Valor);
                datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    for (int i = 0; i < datos.FieldCount; i++) registro.Add(datos.GetName(i), datos.GetValue(i));
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            finally
            {
                sqlConnection.Close();
            }
            return registro;
        }

        public static DataTable EjecutarConLlenado(string procedimiento, List<Parametro> parametros)
        {
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = new SqlConnection(conexion.CadenaConexion);
            DataSet set = new DataSet();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(procedimiento, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                parametros.ForEach((parametro) => cmd.Parameters.Add(parametro.Nombre, parametro.Tipo).Value = parametro.Valor);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(set, "Resultados");
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            finally
            {
                sqlConnection.Close();
            }
            return set.Tables["Resultados"];
        }

        public static DataTable EjecutarConLlenado(string procedimiento)
        {
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = new SqlConnection(conexion.CadenaConexion);
            DataSet set = new DataSet();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(procedimiento, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(set, "Resultados");
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            finally
            {
                sqlConnection.Close();
            }
            return set.Tables["Resultados"];
        }
    }
}