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
        public List<string[]> _registros;
        public string _dato;
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

        //Se inicializa el metodo burbuja 
        public void aplicarBurbuja(int index)
        {
            List<string> RegistrosIniciales = new List<string>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosIniciales.Add(_registros[i][index] + "*" + i);
            }

            char[] temporaldechar = new char[RegistrosIniciales.Count];
            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string temporal = RegistrosIniciales[i];
                temporaldechar[i] = temporal[0];
            }
            int[] temporalNumChar = new int[temporaldechar.Length];
            for (int i = 0; i < temporaldechar.Length; i++)
            {
                temporalNumChar[i] = Convert.ToInt32(temporaldechar[i]);
            }

            Algoritmos.MetodosDeOrdenamiento.PreBurbuja(temporalNumChar);

            for (int i = 0; i < temporalNumChar.Length; i++)
            {
                temporaldechar[i] = Convert.ToChar(temporalNumChar[i]);
            }

            List<string> RegistrosEnOrden = new List<string>();
            ordenacionDeElementosEnLista(RegistrosEnOrden, RegistrosIniciales, temporaldechar);

            for (int i = 0; i < RegistrosEnOrden.Count; i++)
            {
                RegistrosIniciales[i] = RegistrosEnOrden[i];
            }


            List<string[]> RegistrosFinales = new List<string[]>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosFinales.Add(_registros[i]);
            }

            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string[] par = RegistrosIniciales[i].Split('*');

                RegistrosFinales[i] = _registros.ElementAt(Int32.Parse(par[1]));
            }

            for (int i = 0; i < _registros.Count; i++)
            {
                _registros[i] = RegistrosFinales[i];
            }
        }
        //FIn Metodo burbuja

        //Se inicializa el metodo selec 
        public void aplicarSelec(int index)
        {
            List<string> RegistrosIniciales = new List<string>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosIniciales.Add(_registros[i][index] + "*" + i);
            }

            char[] temporaldechar = new char[RegistrosIniciales.Count];
            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string temporal = RegistrosIniciales[i];
                temporaldechar[i] = temporal[0];
            }
            int[] temporalNumChar = new int[temporaldechar.Length];
            for (int i = 0; i < temporaldechar.Length; i++)
            {
                temporalNumChar[i] = Convert.ToInt32(temporaldechar[i]);
            }


            Algoritmos.MetodosDeOrdenamiento.PreSelec(temporalNumChar);


            for (int i = 0; i < temporalNumChar.Length; i++)
            {
                temporaldechar[i] = Convert.ToChar(temporalNumChar[i]);
            }

            List<string> RegistrosOrdenados = new List<string>();
            ordenacionDeElementosEnLista(RegistrosOrdenados, RegistrosIniciales, temporaldechar);

            for (int i = 0; i < RegistrosOrdenados.Count; i++)
            {
                RegistrosIniciales[i] = RegistrosOrdenados[i];
            }


            List<string[]> RegistrosFinales = new List<string[]>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosFinales.Add(_registros[i]);
            }

            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string[] par = RegistrosIniciales[i].Split('*');

                RegistrosFinales[i] = _registros.ElementAt(Int32.Parse(par[1]));
            }

            for (int i = 0; i < _registros.Count; i++)
            {
                _registros[i] = RegistrosFinales[i];
            }
        }
        //FIn Metodo selec

        //Se inicializa el motodo HeapSort
        public void aplicarheapsort(int index)
        {
            List<string> RegistrosIniciales = new List<string>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosIniciales.Add(_registros[i][index] + "*" + i);
            }

            char[] temporaldechar = new char[RegistrosIniciales.Count];
            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string temporal = RegistrosIniciales[i];
                temporaldechar[i] = temporal[0];
            }
            int[] temporalNumChar = new int[temporaldechar.Length];
            for (int i = 0; i < temporaldechar.Length; i++)
            {
                temporalNumChar[i] = Convert.ToInt32(temporaldechar[i]);
            }
           

            Algoritmos.MetodosDeOrdenamiento.HeapSort(ref temporalNumChar);


            for (int i = 0; i < temporalNumChar.Length; i++)
            {
                temporaldechar[i] = Convert.ToChar(temporalNumChar[i]);
            }

            List<string> RegistrosOrdenados = new List<string>();
            ordenacionDeElementosEnLista(RegistrosOrdenados, RegistrosIniciales, temporaldechar);

            for (int i = 0; i < RegistrosOrdenados.Count; i++)
            {
                RegistrosIniciales[i] = RegistrosOrdenados[i];
            }


            List<string[]> RegistrosFinales = new List<string[]>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosFinales.Add(_registros[i]);
            }

            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string[] par = RegistrosIniciales[i].Split('*');

                RegistrosFinales[i] = _registros.ElementAt(Int32.Parse(par[1]));
            }

            for (int i = 0; i < _registros.Count; i++)
            {
                _registros[i] = RegistrosFinales[i];
            }


        }
        //Fin de heapsort

        //Se inicializa el metodo QuickSort
        public void aplicarQuickSort(int index) 
        {
            List<string> RegistrosIniciales = new List<string>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosIniciales.Add(_registros[i][index] + "*" + i);
            }

            char[] temporaldechar = new char[RegistrosIniciales.Count];
            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string temporal = RegistrosIniciales[i];
                temporaldechar[i] = temporal[0];
            }
            int[] temporalNumChar = new int[temporaldechar.Length];
            for (int i = 0; i < temporaldechar.Length; i++)
            {
                temporalNumChar[i] = Convert.ToInt32(temporaldechar[i]);
            }


            Algoritmos.MetodosDeOrdenamiento.PreQuickSort(temporalNumChar);


            for (int i = 0; i < temporalNumChar.Length; i++)
            {
                temporaldechar[i] = Convert.ToChar(temporalNumChar[i]);
            }

            List<string> RegistrosOrdenados = new List<string>();
            ordenacionDeElementosEnLista(RegistrosOrdenados, RegistrosIniciales, temporaldechar);

            for (int i = 0; i < RegistrosOrdenados.Count; i++)
            {
                RegistrosIniciales[i] = RegistrosOrdenados[i];
            }


            List<string[]> RegistrosFinales = new List<string[]>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosFinales.Add(_registros[i]);
            }

            for (int i = 0; i < RegistrosIniciales.Count; i++)
            {
                string[] par = RegistrosIniciales[i].Split('*');

                RegistrosFinales[i] = _registros.ElementAt(Int32.Parse(par[1]));
            }

            for (int i = 0; i < _registros.Count; i++)
            {
                _registros[i] = RegistrosFinales[i];
            }
        }
        //Fin de QuickSort
        private List<string> ordenacionDeElementosEnLista(List<string> ListaVacia, List<string> listaLlena,char [] charOrdenados) {
            //Primer for donde va recorrer todos los caracteres ordenados previamente
            //va ir un por uno 
            for (int i = 0; i < charOrdenados.Length; i++)
            {
                //Bool necesario para que salga del sig si es necesario
                bool salir = false;
                for (int j = 0; j < listaLlena.Count; j++)
                {
                    //Bool va primero para no repetir procesos y para que avance al sig char
                    if (salir == true)
                    {
                        //Rompe este for 
                        break;
                    }

                    //temporal donde se va comporar el primer elemento de este (caracter)
                    //con el de char ordenados
                    //se va ir uno por uno 
                    string temporal = listaLlena[j];
                    //Si es igual el primer elemento con el de char ordenado entra
                    if (temporal[0].Equals(charOrdenados[i]))
                    {

                        //Como no hay nada que comparar entra primero
                        if (i == 0)
                        {
                            ListaVacia.Add(temporal);
                            break;
                        }
                        else
                        {
                            //ahora como ya hay con que comparar entra en este for
                            for (int r = 0; r < ListaVacia.Count; r++)
                            {
                                //como solo se va repetir una ves debedo a que solo hay un 
                                //elemento se puso esta condicion 
                                //para evitar problemas con limite de rango
                                if (i == 1)
                                {
                                    if (temporal.Equals(ListaVacia[r]))
                                    {//si es igual se rompe este for y como solo se va repetir una 
                                    //vez, regresa al segundo for para el sig elemento
                                        break;
                                    }
                                    else
                                    {// si no es igual se agrega 
                                        ListaVacia.Add(temporal);
                                        salir = true;//se habilita para romper el segundo for
                                        break;
                                    }
                                }
                                else// como ya tiene mas elementos a comparar se pasa a este
                                {
                                    //si el elemtento temporar es igual a todo la cadena 
                                    //almacenada anteriormente se rompe el for y va con sig elemento
                                    if (temporal.Equals(ListaVacia[r]))
                                    {
                                        break;
                                    }
                                        //si ya es el ultimo ciclo y como no habia elementos repetidos se agrega
                                    else if (r == ListaVacia.Count - 1)
                                    {
                                       ListaVacia.Add(temporal);
                                        salir = true;
                                        break;
                                    }
                                }


                            }


                        }

                    }

                }

            }
            return ListaVacia;
        }

      public int AplicarBusquedaLineal(int index, string datoABuscar) {
            int indiceDeDatoBuscado;
            List<string> RegistrosIniciales = new List<string>();
            for (int i = 0; i < _registros.Count; i++)
            {
                RegistrosIniciales.Add(_registros[i][index]);
            }

            indiceDeDatoBuscado = Algoritmos.MetodosDeBusqueda.busquedaLineal(datoABuscar, RegistrosIniciales);

            //string dato = Convert.ToString(_registros[indiceDeDatoBuscado]);

            return indiceDeDatoBuscado;
        }
      public int AplicarBusquedaBinaria(int index, string buscado) 
      {
          List<string> listaBusqueda = new List<string>();
          for (int i = 0; i < _registros.Count; i++)
          {
              listaBusqueda.Add(_registros[i][index]);
          }

          listaBusqueda.Sort();

          int comparacion = listaBusqueda.BinarySearch(buscado);
          
          if(comparacion > 0)
          {
               //El dato fue encontrado  y regresa la posicion del datobuscado
              return comparacion;
          }
          //else No existe el dato buscado 
          return 0;
      }
    }
}
