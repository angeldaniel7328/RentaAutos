using System;
using System.Data;

namespace Entities
{
    public class VORenta
    {
        public int IdRenta { get; set; }
        public DateTime? FechaHora { get; set; }
        public bool? Completada { get; set; }
        public int? Plazo { get; set; }
        public double? CuotaTotal { get; set; }
        public int? IdAutomovil { get; set; }
        public int? IdCliente { get; set; }

        public VORenta(DataRow registro)
        {
            IdRenta = (int)registro["IDRenta"];
            FechaHora = (DateTime?)registro["FechaHora"];
            Completada = (bool?)registro["Completada"];
            IdAutomovil = (int?)registro["IdAutomovil"];
            IdCliente = (int?)registro["IdCliente"];
        }

        public VORenta()
        {

        }

    }

    public class VORentaExtendida : VORenta
    {
        public string ModeloAutomovil { get; set; }
        public string UrlFotoAutomovil { get; set; }
        public string NombreCliente { get; set; }
        public string UrlFotoCliente { get; set; }

        public VORentaExtendida(DataRow registro) : base(registro)
        {
            ModeloAutomovil = (string)registro["ModeloAutomovil"];
            UrlFotoAutomovil = (string)registro["UrlFotoAutomovil"];
            NombreCliente = (string)registro["NombreCliente"];
            UrlFotoCliente = (string)registro["UrlFotoCliente"];
        }

        public VORentaExtendida()
        {

        }
    }
}
