using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    public class MetodosDeBusqueda
    {

        //Inicia BusquedaLineal
        public static int busquedaLineal(string elementoABuscar,List<string> datos)
        {
           
            for (int indice = 0; indice < datos.Count; indice++)
            {
                if (datos[indice] == elementoABuscar)
                {
                    return indice;
                }
            }
            return -1; //No se encontro coincidencia
        }
        //Fin BusquedaLineal
        //Inicio Busqueda Binaria
        public static int busquedaBinaria(List<int> vector, int superior, int dato)
        {
            int centro, inf = 0, sup = superior - 1;
            while (inf <= sup)
            {
                centro = ((sup - inf) / 2) + inf;
                if (vector[centro] == dato) return centro;
                else if (dato < vector[centro]) sup = centro - 1;
                else inf = centro + 1;
            }
            return -1;
        }
    }
}
