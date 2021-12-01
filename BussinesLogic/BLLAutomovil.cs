using System;
using System.Collections.Generic;
using Entities;
using DataAccess;

namespace BussinesLogic
{
    public static class BLLAutomovil
    {
        public static bool InsertarAutomovil(VOAutomovil automovil)
        { 
            try
            {
                return DALAutomovil.InsertarAutomovil(automovil);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool ActualizarAutomovil(VOAutomovil automovil)
        {
            try
            {
                return DALAutomovil.ActualizarAutomovil(automovil);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool EliminarAutomovil(string idAutomovil)
        {
            try
            {
                return DALAutomovil.EliminarAutomovil(int.Parse(idAutomovil));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static VOAutomovil ConsultarAutomovilPorId(string idAutomovil)
        {
            VOAutomovil automovil;
            try
            {
                automovil = DALAutomovil.ConsultarAutomovilPorId(int.Parse(idAutomovil));
                if (automovil.Equals(null))
                    throw new ArgumentException("El id buscado no existe en la base de datos");
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return automovil;
        }

        public static List<VOAutomovil> ConsultarAutomoviles(bool? disponibilidad)
        {
            List<VOAutomovil> automoviles;
            try
            {
                automoviles = DALAutomovil.ConsultarAutomoviles(disponibilidad);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return automoviles;
        }
    }
}
