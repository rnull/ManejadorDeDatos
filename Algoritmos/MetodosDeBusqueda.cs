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

    }
}
