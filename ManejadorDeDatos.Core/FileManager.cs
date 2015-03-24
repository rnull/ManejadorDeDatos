using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ManejadorDeDatos.Core
{
    public class FileManager
    {
        private static string _rutaArchivoDB;

        public static void CrearArchivo(string nombreArchivo)
        {

            StreamWriter _sw = File.CreateText(nombreArchivo + ".txt");

            _rutaArchivoDB = Path.GetFileName(nombreArchivo + ".txt");

            _sw.Close();

        }


        public static void reNombrar(string nombreArchivo, string nuevoNombre)
        {
            File.Move(nombreArchivo+".txt", nuevoNombre+".txt");
        }

        public static string ObtenerDatos(string rutaArchivo)
        {
            string resultado;

            StreamReader file = new StreamReader(rutaArchivo);
            DataManager.ObtenerColumnas(file.ReadLine());

            resultado = file.ReadToEnd();


            file.Close();
            return resultado;
        }

        public static void EscribeColumnas(string[] columnas)
        {
            StreamWriter _sw = new StreamWriter(_rutaArchivoDB, true);
            for (int i = 0; i < columnas.Length-1; i++)
            {
                _sw.Write(columnas[i]); _sw.Write(' ');
            }
            _sw.Write(columnas[columnas.Length - 1]);
            _sw.Close();
        }
    }
}
