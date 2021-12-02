using System;
using System.Collections.Generic;
using Entities;
using DataAccess;

namespace BussinesLogic
{
    public static class BLLCliente
    {
        public static bool InsertarCliente(VOCliente cliente)
        {
            try
            {
                return DALCliente.InsertarCliente(cliente);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool ActualizarCliente(VOCliente cliente)
        {
            try
            {
                return DALCliente.ActualizarCliente(cliente);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool EliminarCliente(string idCliente)
        {
            try
            {
                return DALCliente.EliminarCliente(int.Parse(idCliente));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static VOCliente ConsultarClientePorId(string idCliente)
        {
            VOCliente cliente;
            try
            {
                cliente = DALCliente.ConsultarClientePorId(int.Parse(idCliente));
                if (cliente.Equals(null))
                    throw new ArgumentException("El id buscado no existe en la base de datos");
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return cliente;
        }

        public static List<VOCliente> ConsultarClientes()
        {
            List<VOCliente> clientes;
            try
            {
                clientes = DALCliente.ConsultarClientes();
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return clientes;
        }

    }
}
