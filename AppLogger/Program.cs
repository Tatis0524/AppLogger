using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogger
{
    public class Logger
    {
        private static Logger instancia;

        private List<string> logs = new List<string>();

        private Logger() { }

        public static Logger ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Logger();
            }
            return instancia;
        }

        public void RegistrarInformacion(string mensaje)
        {
            logs.Add($"INFORMACIÓN: {mensaje}");
        }

        public void RegistrarAdvertencia(string mensaje)
        {
            logs.Add($"ADVERTENCIA: {mensaje}");
        }

        public void RegistrarError(string mensaje)
        {
            logs.Add($"ERROR: {mensaje}");
        }

        public void MostrarRegistros()
        {
            Console.WriteLine("=== Registros de actividad ===");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("==============================");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.ObtenerInstancia();

            logger.RegistrarInformacion("Inicio de la aplicación.");
            logger.RegistrarAdvertencia("Conexión a la base de datos lenta.");
            logger.RegistrarError("Error al cargar el archivo de configuración.");

            RealizarOperacion1();
            RealizarOperacion2();

            logger.MostrarRegistros();

            Console.ReadKey();
        }

        static void RealizarOperacion1()
        {
            Logger logger = Logger.ObtenerInstancia();
            logger.RegistrarInformacion("Operación 1 completada con éxito.");
        }

        static void RealizarOperacion2()
        {
            Logger logger = Logger.ObtenerInstancia();
            logger.RegistrarError("Operación 2 falló por un error inesperado.");
        }
    }
}
