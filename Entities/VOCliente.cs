using System;
using System.Data;

namespace Entities
{
    public class VOCliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string UrlFoto { get; set; }

        public VOCliente(int idCliente, string nombre, string telefono, string direccion, string correo, string urlFoto)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;
            Correo = correo;
            UrlFoto = urlFoto;
        }

        public VOCliente()
        {

        }

        public VOCliente(DataRow registro)
        {
            IdCliente = (int)registro["IdCliente"];
            Nombre = (string)registro["Nombre"];
            Telefono = (string)registro["Telefono"];
            Direccion = (string)registro["Direccion"];
            Correo = (string)registro["Correo"];
            UrlFoto = (string)registro["UrlFoto"];
        }
    }
}
