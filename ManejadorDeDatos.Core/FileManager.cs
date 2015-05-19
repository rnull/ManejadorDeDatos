using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ManejadorDeDatos.Core
{
    public class FileManager
    {
        private string _ArchivoDB;

        public FileManager(string rutaArchivo)
        {
            _ArchivoDB = rutaArchivo;
        }

        public void CrearArchivo()
        {

            StreamWriter _sw = File.CreateText(_ArchivoDB + ".txt");

            _ArchivoDB = Path.GetFileName(_ArchivoDB + ".txt");

            _sw.Close();

        }

        public void CargarArchivo()
        {            

        }



        public void reNombrar(string nuevoNombre)
        {
            File.Move(_ArchivoDB, nuevoNombre + ".txt");
        }

        //public string ObtenerDatos(string rutaArchivo)
        //{
        //    string resultado;

        //    StreamReader file = new StreamReader(rutaArchivo);
        //    DataManager.ObtenerColumnas(file.ReadLine());

        //    resultado = file.ReadToEnd();


        //    file.Close();
        //    return resultado;
        //}

        //public static void EscribeColumnas(string[] columnas)
        //{
        //    StreamWriter _sw = new StreamWriter(_rutaArchivoDB, true);
        //    for (int i = 0; i < columnas.Length-1; i++)
        //    {
        //        _sw.Write(columnas[i]); _sw.Write(' ');
        //    }
        //    _sw.Write(columnas[columnas.Length - 1]);
        //    _sw.Close();
        //}

        public void GuardarCambios(string text)
        {
            File.WriteAllText(_ArchivoDB, text);
        }

        public string GetColumnas()
        {
            StreamReader file = new StreamReader(_ArchivoDB);
            return file.ReadLine();
        }

        public string GetDBName()
        {
            return _ArchivoDB;
        }
    }
}
