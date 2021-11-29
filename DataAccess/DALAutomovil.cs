using System;
using System.Collections.Generic;
using System.Data;
using Entities;

namespace DataAccess
{
    public static class DALAutomovil
    {
        public static bool Insertar(VOAutomovil automovil)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Matricula", SqlDbType.VarChar, automovil.Matricula));
                parametros.Add(new Parametro("@Modelo", SqlDbType.VarChar, automovil.Modelo));
                parametros.Add(new Parametro("@Marca", SqlDbType.VarChar, automovil.Marca));
                parametros.Add(new Parametro("@Año", SqlDbType.Char, automovil.Año));
                parametros.Add(new Parametro("@CuotaDia", SqlDbType.Decimal, automovil.CuotaDia));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, automovil.UrlFoto));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_InsertarAutomovil", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static List<VOAutomovil> Consultar(bool? disponibilidad)
        {
            List<VOAutomovil> automoviles = new List<VOAutomovil>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, disponibilidad));
                DataTable datos = ManejadorConsultas.EjecutarConLlenado("SP_ConsultarAutomoviles", parametros);
                foreach (DataRow registro in datos.Rows)
                    automoviles.Add(new VOAutomovil(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return automoviles;
        }

        public static VOAutomovil ConsultarPorId(int idAutomovil)
        {
            VOAutomovil automovil;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdAutomovil", SqlDbType.Int, idAutomovil));
                Dictionary<string, object> datos = ManejadorConsultas.EjecutarLectura("SP_ConsultarAutomovilPorId", parametros);
                automovil = new VOAutomovil()
                {
                    IdAutomovil = (int)datos["IdAutomovil"],
                    Matricula = (string)datos["Matricula"],
                    Modelo = (string)datos["Modelo"],
                    Marca = (string)datos["Marca"],
                    Año = (string)datos["Año"],
                    CuotaDia = (double?)datos["CuotaDia"],
                    Disponibilidad = (bool?)datos["Disponibilidad"],
                    UrlFoto = (string)datos["UrlFoto"]
                };
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return automovil;
        }

        public static bool Actualizar(VOAutomovil automovil)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdAutomovil", SqlDbType.Int, automovil.IdAutomovil));
                parametros.Add(new Parametro("@Matricula", SqlDbType.VarChar, automovil.Matricula));
                parametros.Add(new Parametro("@Modelo", SqlDbType.VarChar, automovil.Modelo));
                parametros.Add(new Parametro("@Marca", SqlDbType.VarChar, automovil.Marca));
                parametros.Add(new Parametro("@Año", SqlDbType.Char, automovil.Año));
                parametros.Add(new Parametro("@CuotaDia", SqlDbType.Decimal, automovil.CuotaDia));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, automovil.UrlFoto));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_ActualizarAutomovil", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo actualizar en la base de datos");
            }
        }

        public static bool Eliminar(int idAutomovil)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdAutomovil", SqlDbType.Int, idAutomovil));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_EliminarAutomovil", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo eliminar en la base de datos");
            }
        }
    }
}
