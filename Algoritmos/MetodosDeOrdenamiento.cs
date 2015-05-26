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
        public static void mBurbuja(int[] caracteres)
        {

            int[] equivalenciASCII = new int[caracteres.Length];

            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (int)caracteres[i];
            }

            Aplicar(equivalenciASCII);

            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];

            }

        }

        private static void Aplicar(int[] numeros)
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

    }
}
