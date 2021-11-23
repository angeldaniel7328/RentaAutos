using System;

namespace Entities
{
    public class VOAutomovil
    {
        public int IdAutomovil { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public double? Precio { get; set; }
        public int IdOwner { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

    }
}
