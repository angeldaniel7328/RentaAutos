using System;
using System.Collections.Generic;
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

        public VOCliente(DataRow registro)
        {
            IdCliente = (int)registro["IdCliente"];
            Nombre = (string)registro["Nombre"];
            Telefono = (string)registro["Telefono"];
            Direccion = (string)registro["Direccion"];
            Correo = (string)registro["Correo"];
            UrlFoto = (string)registro["UrlFoto"];
        }

        public VOCliente(Dictionary<string, object> registro)
        {
            IdCliente = (int)registro["IdCliente"];
            Nombre = (string)registro["Nombre"];
            Telefono = (string)registro["Telefono"];
            Direccion = (string)registro["Direccion"];
            Correo = (string)registro["Correo"];
            UrlFoto = (string)registro["UrlFoto"];
        }

        public VOCliente() { }
    }
}
