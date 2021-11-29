using System;
using System.Collections.Generic;
using System.Data;
using Entities;

namespace DataAccess
{
    public static class DALCliente
    {
        public static bool Insertar(VOCliente cliente)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, cliente.Nombre));
                parametros.Add(new Parametro("@Telefono", SqlDbType.NVarChar, cliente.Telefono));
                parametros.Add(new Parametro("@Direccion", SqlDbType.VarChar, cliente.Direccion));
                parametros.Add(new Parametro("@Correo", SqlDbType.VarChar, cliente.Correo));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, cliente.UrlFoto));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_InsertarCliente", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static List<VOCliente> Consultar()
        {
            List<VOCliente> clientes = new List<VOCliente>();
            try
            {
                DataTable datos = ManejadorConsultas.EjecutarConLlenado("SP_ConsultarClientes", null);
                foreach (DataRow registro in datos.Rows)
                    clientes.Add(new VOCliente(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return clientes;
        }

        public static VOAutomovil ConsultarAutomovilPorId(int idAutomovil)
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

        public static bool ActualizarAutomovil(VOAutomovil automovil)
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

        public static bool EliminarAutomovil(int idAutomovil)
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
