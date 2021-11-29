using System;

namespace Entities
{
    public class VORenta
    {
        public int IdRenta { get; set; }
        public DateTime? FechaHoraRentad { get; set; }
        public DateTime? FechaHoraDevolucion { get; set; }
        public int? Estado { get; set; }
        public int? IdAutomovil { get; set; }
        public int? IdCliente { get; set; }

        public enum EstadoRenta
        {
            EN_RENTA = 1,
            REVUELTO = 2
        }
    }
}
