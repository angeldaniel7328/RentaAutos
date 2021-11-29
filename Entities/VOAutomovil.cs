using System;

namespace Entities
{
    public class VOAutomovil
    {
        public int IdAutomovil { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Año { get; set; }
        public double? Cuota { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

    }
}
