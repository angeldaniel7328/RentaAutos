using System;

namespace Entities
{
    public class VODevolucion
    {
        public int IdDevolucion { get; set; }
        public DateTime? FechaHora { get; set; }
        public double? CuotaTotal { get; set; }
        public int? IdRenta { get; set; }
    }
}
