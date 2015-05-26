using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    public class MetodosDeOrdenamiento
    {

        //Metodo burbuja 
        public static void PreBurbuja(int[] caracteres)
        {

            int[] equivalenciASCII = new int[caracteres.Length];

            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (int)caracteres[i];
            }

            AplicaBurbuja(equivalenciASCII);

            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];

            }

        }

        private static void AplicaBurbuja(int[] numeros)
        {

            for (int i = 1; i < numeros.Length; i++)
            {
                for (int j = 0; j < numeros.Length - 1; j++)
                {
                    if (numeros[j] > numeros[j + 1])
                    {
                        int auxiliar = numeros[j];
                        numeros[j] = numeros[j + 1];
                        numeros[j + 1] = auxiliar;
                    }
                }
            }

        }    
        // Fin metodo burbuja

        //Metodo Selección
        public static void mSelec(int[] caracteres)
        {
            int[] equivalenciASCII = new int[caracteres.Length];

            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (int)caracteres[i];
            }

            AplicarSelec(equivalenciASCII);

            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];

            }
        }

        private static void AplicarSelec(int[] numeros)
        {
            for (int i = 0; i < numeros.Length - 1; i++)
            {
                int minimo = i;

                for (int j = i + 1; i < numeros.Length; i++)
                {
                    if (numeros[j] < numeros[minimo])
                    {
                        minimo = j;
                    }
                    int aux = numeros[i];
                    numeros[i] = numeros[minimo];
                    numeros[minimo] = aux;

                }

            }
        }
        //Fin Metodo Selección


        //Metodo de HeapSort
        //se fija un limite de nodos 
       

       

        public static  void HeapSort(ref int[] array)
        {    
            
            int[] nodos = new int[100];
            int numMayor = 0;
            nodos = array;
            numMayor = array.Length;
            //sirve para guiar a los for
            int i;
            //es para guardar el numero con el que se va estar trabajando
            int temp;
            //sirvio de prueba este for
            //for (i = (numMayor / 2) - 1; i >= 0; i--)
            //{
            //    siftDown(i, numMayor);
            //}

            //este for es donde van estar intercambiando los nodos de posicion
            for ( i = numMayor-1; i >= 1; i--)
            {
                temp = nodos[0];
                nodos[0] = nodos[i];
                nodos[i] = temp;
                siftDown(0, i - 1);

            }

        }

        //Compara el nodo raiz con sus hijos
        public void siftDown(int raiz, int Hijos) 
        {
            bool done = false;
            int HijoMayor;
            int temp;

            while ((raiz*2<=Hijos)&&(!done))
            {
                if (raiz*2==Hijos)
                {
                    HijoMayor = raiz * 2;
                }
                else if (nodos[raiz*2]>nodos[raiz*2+1])
                {
                     HijoMayor = raiz * 2;
                }
                else
                {
                    HijoMayor = raiz * 2+1;
                }

                if (nodos[raiz]<nodos[HijoMayor])
                {
                    temp = nodos[raiz];
                    nodos[raiz] = nodos[HijoMayor];
                    nodos[HijoMayor] = temp;
                    raiz = HijoMayor;
                }
                else
                {
                    done = true;
                }
            }

        }
        //Fin HeapSort
    }
}
