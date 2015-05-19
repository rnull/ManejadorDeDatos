using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorDeDatos.Core
{
    public class DataManager
    {
        private string[] _columnas;
        private List<string[]> _registros;
        private int MayorTamaño;

        public DataManager(string Cadena_de_Columnas)
        {
            _columnas = Cadena_de_Columnas.Split(' ');
            
            _registros = new List<string[]>();
        }

        public String[] GetColumnas()
        {
            return _columnas;
        }

        public List<string[]> GetRegistros()
        {
            return _registros;
        }

        public void EditarColumna(int columnaIndex, string nuevoNombre)
        {
            _columnas[columnaIndex] = nuevoNombre;
        }

        public bool ExistenColumnas()
        {
            if (_columnas != null)
            {
                return true;
            }
            return false;
        }

        public string ColumnasToString()
        {
            string resultado = "";
            for(int i = 0; i < _columnas.Length-1; i++){
                resultado += ""+_columnas[i];
                resultado += " ";
            }
            resultado +=  _columnas[_columnas.Length-1];
            return resultado;
        }

        public void AgregarColumna(string nombre)
        {
            String[] _c = new String[_columnas.Length+1];
            for (int i = 0; i < _c.Length-1; i++)
            {
                _c[i] = _columnas[i];
            }
            _c[_c.Length] = nombre;
        
            _columnas = _c;
        }

        public void AgregarRegistro(string[] nuevoRegistro)
        {
            _registros.Add(nuevoRegistro);
            GetMayorLength();
        }

        public string RegistrosToString()
        {
            string resultado = "";

            for (int i = 0; i < _registros.Count-1; i++)
            {
                for (int j = 0; j < _columnas.Length-1; j++)
                {
                    resultado += _registros[i][j] +" ";
                }
                resultado += _registros[i][_columnas.Length-1];
                resultado += "\r\n";
            }

            //Ultima iteracion sobre el ultimo elemento
            for (int j = 0; j < _columnas.Length - 1; j++)
            {
                resultado += _registros[_registros.Count-1][j] + " ";
            }
            resultado += _registros[_registros.Count - 1][_columnas.Length - 1];

            return resultado;
        }



        public void ConstruirRegistros(string dbName)
        {
            string line;

            // Read the file and display it line by line.
            StreamReader file =
                new StreamReader(dbName);
            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                _registros.Add(StringToArrayString(line));
            }

            file.Close();
        }

        private string[] StringToArrayString(string line)
        {
            return line.Split(' ');
        }

        public int GetMayorLength()
        {
            int res = 0;
            for (int i = 0; i < _columnas.Length; i++)
            {
                if (res < _columnas[i].Length)
                {
                    res = _columnas[i].Length;
                }
            }

            if (_registros != null)
            {
                foreach (var registro in _registros)
                {
                    for (int i = 0; i < registro.Length; i++)
                    {
                        if (res < registro[i].Length)
                        {
                            res = registro[i].Length;
                        }
                    }
                }   
            }
            MayorTamaño = res;
            return res;
        }

        public void AplicarSortDefault(int index)
        {
            //se ordena la columna especificada por el index
            List<string> temp = new List<string>();
            for (int i = 0; i < _registros.Count; i++)
            {
                temp.Add(_registros[i][index] +"*"+i);
            }
            temp.Sort();
            
            //Respaldamos los registros por valor
            List<string[]> _regRespaldo = new List<string[]>();
            for (int i = 0; i < _registros.Count; i++)
            {
                _regRespaldo.Add(_registros[i]);
            }

            //Movemos cada registro a la posicion que le toca seugn el temporal ya ordenado
            for (int i = 0; i < temp.Count; i++)
            {
            	string[] par = temp[i].Split('*');

                _regRespaldo[i] = _registros.ElementAt(Int32.Parse(par[1]));
            }


            for (int i = 0; i < _registros.Count; i++)
            {
                _registros[i] = _regRespaldo[i];
            }

        }
    }
}
