using System;
using System.Configuration;

namespace DataAccess
{
    public class Conexion
    {
        public string CadenaConexion { get; private set; }

        public Conexion() => Configurar();

        private void Configurar()
        {
            try
            {
                CadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
            }
            catch (Exception)
            {
                throw new ArgumentException("Error al configurar la cadena de conexión");
            }
        }
    }
}