using System;
using System.Data;

namespace Entities
{
    public class VOAutomovil
    {
        public int IdAutomovil { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public double? Cuota { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

        public VOAutomovil(DataRow registro)
        {
            IdAutomovil = (int)registro["IdAutomovil"];
            Matricula = (string)registro["Matricula"];
            Modelo = (string)registro["Modelo"];
            Marca = (string)registro["Marca"];
            Cuota = double.Parse(registro["Cuota"].ToString());
            Disponibilidad = bool.Parse(registro["Disponibilidad"].ToString());
            UrlFoto = (string)registro["UrlFoto"];
        }

        public VOAutomovil()
        {

        }
    }
}
