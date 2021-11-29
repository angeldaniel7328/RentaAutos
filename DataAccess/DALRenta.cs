using System;
using System.Collections.Generic;
using System.Data;
using Entities;

namespace DataAccess
{
    public static class DALRenta
    {
        public static bool InsertarRenta(VORenta renta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@FechaHora", SqlDbType.DateTime, renta.FechaHora));
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, renta.Estado));
                parametros.Add(new Parametro("@IdAutomovil", SqlDbType.Int, renta.IdAutomovil));
                parametros.Add(new Parametro("@IdCliente", SqlDbType.Int, renta.IdCliente));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_InsertarRenta", parametros);
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static VORenta ConsultarRentaPorId(int idRenta)
        {
            VORenta renta;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                Dictionary<string, object> datos = ManejadorConsultas.EjecutarLectura("SP_ConsultarRentaPorId", parametros);
                renta = new VORenta()
                {
                    IdRenta = (int)datos["IdRenta"],
                    FechaHora = (DateTime?)datos["FechaHora"],
                    Estado = (string)datos["Estado"],
                    IdAutomovil = (int?)datos["IdAutomovil"],
                    IdCliente = (int?)datos["IdCliente"]
                };
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return renta;
        }

        public static List<VORenta> ConsultarRentasPorEstado(string estado)
        {
            List<VORenta> rentas = new List<VORenta>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, estado));
                DataTable datos = ManejadorConsultas.EjecutarConLlenado("SP_ConsultarRentasPorEstado", parametros);
                foreach (DataRow registro in datos.Rows)
                    rentas.Add(new VORenta()
                    {
                        IdRenta = (int)registro["IDRenta"],
                        FechaHora = (DateTime?)registro["FechaHora"],
                        Estado = (string)registro["Estado"],
                        IdAutomovil = (int?)registro["IdAutomovil"],
                        IdCliente = (int?)registro["IdCliente"]
                    });
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return rentas;
        }

    }
}
