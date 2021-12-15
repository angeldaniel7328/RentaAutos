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
                return (rows != 0);
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
                renta = new VORenta(datos);
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

        public static VORentaExtendida ConsultarRentaExtendidaPorId(int idRenta)
        {
            VORentaExtendida renta;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                Dictionary<string, object> datos = ManejadorConsultas.EjecutarLectura("SP_ConsultarRentaExtendidaPorId", parametros);
                renta = new VORentaExtendida(datos);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return renta;
        }

        public static bool DevolverAutomovil(int idRenta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdRenta", SqlDbType.Int, idRenta));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_DevolverAutomovil", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo devolver el automovil en la base de datos");
            }
        }

    }
}
