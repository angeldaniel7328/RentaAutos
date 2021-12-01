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
                parametros.Add(new Parametro("@Plazo", SqlDbType.Int, renta.Plazo));
                parametros.Add(new Parametro("@CuotaTotal", SqlDbType.Decimal, renta.CuotaTotal));
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
            VORenta renta = null;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                Dictionary<string, object> datos = ManejadorConsultas.EjecutarLectura("SP_ConsultarRentaPorId", parametros);
                if (datos.Count > 0)
                {
                    renta = new VORenta()
                    {
                        IdRenta = (int)datos["IdRenta"],
                        FechaHora = (DateTime?)datos["FechaHora"],
                        Completada = (bool?)datos["Completada"],
                        Plazo = (int?)datos["Plazo"],
                        CuotaTotal = double.Parse(datos["CuotaTotal"].ToString()),
                        IdAutomovil = (int?)datos["IdAutomovil"],
                        IdCliente = (int?)datos["IdCliente"]
                    };
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return renta;
        }

        public static List<VORenta> ConsultarRentas()
        {
            List<VORenta> rentas = new List<VORenta>();
            try
            {
                DataTable datos = ManejadorConsultas.EjecutarConLlenado("SP_ConsultarRentas");
                foreach (DataRow registro in datos.Rows)
                    rentas.Add(new VORenta(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return rentas;
        }

        public static List<VORentaExtendida> ConsultarRentasExtendidas()
        {
            List<VORentaExtendida> rentas = new List<VORentaExtendida>();
            try
            {
                DataTable datos = ManejadorConsultas.EjecutarConLlenado("SP_ConsultarRentasExtendidas");
                foreach (DataRow registro in datos.Rows)
                    rentas.Add(new VORentaExtendida(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return rentas;
        }

        public static VORenta ConsultarRentaExtendidaPorId(int idRenta)
        {
            VORentaExtendida renta = null;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                Dictionary<string, object> datos = ManejadorConsultas.EjecutarLectura("SP_ConsultarRentaPorId", parametros);
                if (datos.Count > 0)
                {
                    renta = new VORentaExtendida()
                    {
                        IdRenta = (int)datos["IdRenta"],
                        FechaHora = (DateTime?)datos["FechaHora"],
                        Completada = (bool?)datos["Completada"],
                        Plazo = (int?)datos["Plazo"],
                        CuotaTotal = double.Parse(datos["CuotaTotal"].ToString()),
                        ModeloAutomovil = (string)datos["ModeloAutomovil"],
                        UrlFotoAutomovil = (string)datos["UrlFotoAutomovil"],
                        NombreCliente = (string)datos["NombreCliente"],
                        UrlFotoCliente = (string)datos["UrlFotoCliente"],
                        IdAutomovil = (int?)datos["IdAutomovil"],
                        IdCliente = (int?)datos["IdCliente"]
                    };
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return renta;
        }

    }
}
