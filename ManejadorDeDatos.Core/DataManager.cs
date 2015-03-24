using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorDeDatos.Core
{
    public class DataManager
    {
        private static string[] _columnas;
        private static List<string[]> _registros;
        public static void ObtenerColumnas(String columnas)
        {
            _columnas = columnas.Split(' ');
        }

        public static void EditarColumna(int columnaIndex, string nuevoNombre)
        {
            _columnas[columnaIndex] = nuevoNombre;
        }

        public static String[] GetColumnas()
        {
            return _columnas;
        }

        public static void DefinirColumnas(String columnas)
        {
            _columnas = columnas.Split(' ');
            _registros = new List<string[]>();
        }

        public static bool ExistenColumnas()
        {
            if (_columnas != null)
            {
                return true;
            }
            return false;
        }

        public static string ColumnasToString()
        {
            string resultado = "";
            for(int i = 0; i < _columnas.Length; i++){
                resultado += ""+_columnas[i];
                resultado += " ";
            }
            return resultado;
        }

        public static void AgregarColumna(string nombre)
        {
            String[] _c = new String[_columnas.Length+1];
            for (int i = 0; i < _c.Length-1; i++)
            {
                _c[i] = _columnas[i];
            }
            _c[_c.Length] = nombre;
        
            _columnas = _c;
        }

        public static void AgregarRegistro(string[] nuevoRegistro)
        {
            _registros.Add(nuevoRegistro);
        }

        public static string RegistrosToString()
        {
            string resultado = "";

            for (int i = 0; i < _registros.Count; i++)
            {
                for (int j = 0; j < _columnas.Length-1; j++)
                {
                    resultado += _registros[i][j] +" ";
                }
                resultado += _registros[i][_columnas.Length-1];
                resultado += "\r\n";
            }

            return resultado;
        }
    }
}
