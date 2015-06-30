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
        public static void PreSelec(int[] caracteres)
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

        private static void AplicarSelec(int[] numerosArray)
        {
            int temp;
            int i, j, posMin;
            int n = numerosArray.Length;

            for (i = 0; i < n - 1; i++)
            {
                posMin = i;
                for (j = i + 1; j < n; j++)
                {
                    if (numerosArray[j] < numerosArray[posMin])
                        posMin = j;
                }
                temp = numerosArray[i];
                numerosArray[i] = numerosArray[posMin];
                numerosArray[posMin] = temp;
            }
        }
        //Fin Metodo Selección

        //Metodo de HeapSort
        //se fija un limite de nodos 
        public static void HeapSort(ref int[] array)
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
            for (i = (numMayor / 2) - 1; i >= 0; i--)
            {
                siftDown(i, numMayor - 1, nodos);
            }

            //este for es donde van estar intercambiando los nodos de posicion
            for (i = numMayor - 1; i >= 1; i--)
            {
                temp = nodos[0];
                nodos[0] = nodos[i];
                nodos[i] = temp;
                siftDown(0, i - 1, nodos);

            }

        }

        //Compara el nodo raiz con sus hijos
        public static void siftDown(int raiz, int Hijos, int[] nodoss)
        {
            bool done = false;
            int HijoMayor;
            int temp;


            while ((raiz * 2 <= Hijos) && (!done))
            {
                if (raiz * 2 == Hijos)
                {
                    HijoMayor = raiz * 2;
                }
                else if (nodoss[raiz * 2] > nodoss[raiz * 2 + 1])
                {
                    HijoMayor = raiz * 2;
                }
                else
                {
                    HijoMayor = raiz * 2 + 1;
                }

                if (nodoss[raiz] < nodoss[HijoMayor])
                {
                    temp = nodoss[raiz];
                    nodoss[raiz] = nodoss[HijoMayor];
                    nodoss[HijoMayor] = temp;
                    raiz = HijoMayor;
                }
                else
                {
                    done = true;
                }
            }

        }
        //Fin HeapSort

        //Inicio Metodo QuickSort
        public static void PreQuickSort(int[] caracteres)
        {
            int[] equivalenciASCII = new int[caracteres.Length];
            int x = caracteres[0];
            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (int)caracteres[i];
            }

            quicksort(equivalenciASCII, caracteres[0], caracteres[caracteres.Length - 1]);
            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];
            }
        }

        public static void quicksort(int[] input, int low, int high)
        {
            int pivot_loc = 0;

            if (low < high)
                pivot_loc = partition(input, low, high);
            quicksort(input, low, pivot_loc - 1);
            quicksort(input, pivot_loc + 1, high);
        }

        private static int partition(int[] input, int low, int high)
        {
            int pivot = input[high];
            int i = low - 1;

            for (int j = low; j < high - 1; j++)
            {
                if (input[j] <= pivot)
                {
                    i++;
                    swap(input, i, j);
                }
            }
            swap(input, i + 1, high);
            return i + 1;
        }



        private static void swap(int[] ar, int a, int b)
        {
            int temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }
        //Fin QuickSort
    }
}

