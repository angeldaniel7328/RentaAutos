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
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
        }

        public static bool ActualizarAutomovil(VOAutomovil automovil)
        {
            try
            {
                return DALAutomovil.ActualizarAutomovil(automovil);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
        }

        public static bool EliminarAutomovil(string idAutomovil)
        {
            try
            {
                return DALAutomovil.EliminarAutomovil(int.Parse(idAutomovil));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
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
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
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
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
            return automoviles;
        }
    }
}
