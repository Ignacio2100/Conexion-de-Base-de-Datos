using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2
{
    class Conexion
    {

        public static MySqlConnection conexion()
        {
            string servidor= "localhost";
            string basedatos = "bdejemplo01";
            string usuario = "root";
            string pass = "Guatemala2022.";

            string cadenaconexion = "Database="+ basedatos + "; Data Source="+servidor+"; User Id="+usuario+"; Password="+pass+"";
            
            try
            {
                MySqlConnection ConexionBD = new MySqlConnection(cadenaconexion);
                return ConexionBD;

            }
            catch (MySqlException ex)
            {

                Console.WriteLine("Error: "+ ex.Message);
                return null;
            }
        }
    }
}
