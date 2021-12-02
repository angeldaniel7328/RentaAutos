using System;
using System.Collections.Generic;
using System.Data;
using Entities;

namespace DataAccess
{
    public static class DALCliente
    {
        public static bool InsertarCliente(VOCliente cliente)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, cliente.Nombre));
                parametros.Add(new Parametro("@Telefono", SqlDbType.VarChar, cliente.Telefono));
                parametros.Add(new Parametro("@Direccion", SqlDbType.VarChar, cliente.Direccion));
                parametros.Add(new Parametro("@Correo", SqlDbType.VarChar, cliente.Correo));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, cliente.UrlFoto));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_InsertarCliente", parametros);
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static VOCliente ConsultarClientePorId(int idCliente)
        {
            VOCliente cliente = null;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdCliente", SqlDbType.Int, idCliente));
                Dictionary<string, object> datos = ManejadorConsultas.EjecutarLectura("SP_ConsultarClientePorId", parametros);
                if (datos.Count > 0)
                {
                    cliente = new VOCliente()
                    {
                        IdCliente = (int)datos["IdCliente"],
                        Nombre = (string)datos["Nombre"],
                        Telefono = (string)datos["Telefono"],
                        Direccion = (string)datos["Direccion"],
                        Correo = (string)datos["Correo"],
                        UrlFoto = (string)datos["UrlFoto"]
                    };
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return cliente;
        }

        public static List<VOCliente> ConsultarClientes()
        {
            List<VOCliente> clientes = new List<VOCliente>();
            try
            {
                DataTable datos = ManejadorConsultas.EjecutarConLlenado("SP_ConsultarClientes");
                foreach (DataRow registro in datos.Rows)
                    clientes.Add(new VOCliente(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return clientes;
        }

        public static bool ActualizarCliente(VOCliente cliente)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdCliente", SqlDbType.Int, cliente.IdCliente));
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, cliente.Nombre));
                parametros.Add(new Parametro("@Telefono", SqlDbType.VarChar, cliente.Telefono));
                parametros.Add(new Parametro("@Direccion", SqlDbType.VarChar, cliente.Direccion));
                parametros.Add(new Parametro("@Correo", SqlDbType.VarChar, cliente.Correo));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, cliente.UrlFoto));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_ActualizarCliente", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo actualizar en la base de datos");
            }
        }

        public static bool EliminarCliente(int idCliente)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdCliente", SqlDbType.Int, idCliente));
                int rows = ManejadorConsultas.EjecutarSinConsulta("SP_EliminarCliente", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo eliminar en la base de datos");
            }
        }
    }
}
