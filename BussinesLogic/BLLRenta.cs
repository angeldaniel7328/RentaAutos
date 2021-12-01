using System;
using System.Collections.Generic;
using Entities;
using DataAccess;

namespace BussinesLogic
{
    public static class BLLRenta
    {
        public static bool InsertarRenta(VORenta renta)
        {
            try
            {
                return DALRenta.InsertarRenta(renta);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
        }

        public static VORenta ConsultarRentaPorId(string idRenta)
        {
            VORenta renta;
            try
            {
                renta = DALRenta.ConsultarRentaPorId(int.Parse(idRenta));
                if (renta.Equals(null))
                    throw new ArgumentException("El id buscado no existe en la base de datos");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
            return renta;
        }

        public static List<VORenta> ConsultarRentas()
        {
            List<VORenta> rentas = new List<VORenta>();
            try
            {
                rentas = DALRenta.ConsultarRentas();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
            return rentas;
        }

        public static List<VORentaExtendida> ConsultarRentasExtendidas()
        {
            List<VORentaExtendida> rentas = new List<VORentaExtendida>();
            try
            {
                rentas = DALRenta.ConsultarRentasExtendidas();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
            return rentas;
        }

        public static VORentaExtendida ConsultarRentaExtendidaPorId(string idRenta)
        {
            VORentaExtendida renta;
            try
            {
                renta = DALRenta.ConsultarRentaExtendidaPorId(int.Parse(idRenta));
                if (renta.Equals(null))
                    throw new ArgumentException("El id buscado no existe en la base de datos");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
            return renta;
        }

        public static bool DevolverAutomovil(string idRenta)
        {
            try
            {
                return DALRenta.DevolverAutomovil(int.Parse(idRenta));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error " + ex.Message);
            }
        }
    }
}
