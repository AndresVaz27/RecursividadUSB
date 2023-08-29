using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursividadUSB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la ruta de la memoria USB: ");
            string usbPath = Console.ReadLine();

            if (Directory.Exists(usbPath))
            {
                Console.WriteLine($"Contenido de {usbPath}:");
                ListarCarpetasYArchivos(usbPath);
            }
            else
            {
                Console.WriteLine("La ruta especificada no es válida.");
            }
            Console.ReadKey();
        }

        static void ListarCarpetasYArchivos(string path, string indent = "")
        {
            try
            {
                string[] carpetas = Directory.GetDirectories(path);
                foreach (string carpeta in carpetas)
                {
                    Console.WriteLine($"{indent}Carpeta: {Path.GetFileName(carpeta)}");
                    ListarCarpetasYArchivos(carpeta, indent + "  ");
                }

                string[] archivos = Directory.GetFiles(path);
                foreach (string archivo in archivos)
                {
                    Console.WriteLine($"{indent}Archivo: {Path.GetFileName(archivo)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{indent}Error: {ex.Message}");
            }
        }
    }
}
