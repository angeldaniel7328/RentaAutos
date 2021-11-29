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
        public string Año { get; set; }
        public double? CuotaDia { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

        public VOAutomovil(int idAutomovil, string matricula, string modelo, string marca, string año, double? cuotaDia, bool? disponibilidad, string urlFoto)
        {
            IdAutomovil = idAutomovil;
            Matricula = matricula;
            Modelo = modelo;
            Marca = marca;
            Año = año;
            CuotaDia = cuotaDia;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
        }

        public VOAutomovil()
        {

        }

        public VOAutomovil(DataRow registro)
        {
            IdAutomovil = (int)registro["IdAutomovil"];
            Matricula = (string)registro["Matricula"];
            Modelo = (string)registro["Modelo"];
            Marca = (string)registro["Marca"];
            Año = (string)registro["Año"];
            CuotaDia = (double?)registro["CuotaDia"];
            Disponibilidad = (bool?)registro["Disponibilidad"];
            UrlFoto = (string)registro["UrlFoto"];
        }
    }
}
