using System;

namespace Entities
{
    public class VORenta
    {
        public int IdRenta { get; set; }
        public DateTime? FechaHora { get; set; }
        public string Estado { get; set; }
        public int? IdAutomovil { get; set; }
        public int? IdCliente { get; set; }

        public enum EstadoRenta
        {
            EN_PROCESO,
            DEVUELTO
        }
    }
}
