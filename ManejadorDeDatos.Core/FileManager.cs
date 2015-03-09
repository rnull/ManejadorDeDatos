using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorDeDatos.Core
{
    public class FileManager
    {
        public static void CrearArchivo(string nombreArchivo)
        {

            var BD = File.CreateText(nombreArchivo + ".txt");
            BD.Close();


        }


        public static void reNombrar(string nombreArchivo, string nuevoNombre)
        {

            File.Move(nombreArchivo+"txt", nuevoNombre+"txt");

        }
    }
}
