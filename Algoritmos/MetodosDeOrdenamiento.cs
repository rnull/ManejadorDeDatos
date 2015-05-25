using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    public class MetodosDeOrdenamiento
    {

        private static void mBurbuja(int[] numeros)
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

        private static void mSelec(int[] numeros)
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

        private static int mQuick(double[] numeros, int primero, int ultimo)
        {
            int ultimo1 = ultimo;
            double pivote = primero;
            double temporal;

            int izq = primero + 1;
            int der = ultimo1;

            do
            {
                while ((izq <= der) && (izq <= pivote))
                    izq++;
                while ((izq <= der) && (der > pivote))
                    der--;
                if (izq < der)
                {
                    temporal = numeros[izq];
                    numeros[izq] = numeros[der];
                    numeros[der] = temporal;
                }
            }
            while (izq <= der);

            temporal = numeros[0];
            numeros[0] = ultimo1;
            numeros[numeros.Length - 1] = temporal;

            return der;
        }

        public static void OnCharBurbuja(int[] caracteres)
        {

            int[] equivalenciASCII = new int[caracteres.Length];

            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (int)caracteres[i];
            }

            mBurbuja(equivalenciASCII);

            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];

            }

        }

        public static void OnCharQuick(int[] caracteres)
        {
            double[] equivalenciASCII = new double[caracteres.Length];
            int x = caracteres[0];
            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (double)caracteres[i];
            }

            mQuick(equivalenciASCII, caracteres[0], caracteres[caracteres.Length - 1]);
            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];
            }
        }

        public static void OnCharSelec(int[] caracteres)
        {
            int[] equivalenciASCII = new int[caracteres.Length];

            for (int i = 0; i < caracteres.Length; i++)
            {
                equivalenciASCII[i] = (int)caracteres[i];
            }

            mSelec(equivalenciASCII);

            for (int i = 0; i < caracteres.Length; i++)
            {
                caracteres[i] = (char)equivalenciASCII[i];

            }
        }
    }
}
