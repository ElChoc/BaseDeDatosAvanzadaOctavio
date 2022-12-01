using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    internal class Nodo
    {
        private int dato;
        private Nodo izq;
        private Nodo der;

        public int Dato { get => dato; set => dato = value; }
        internal Nodo Izq { get => izq; set => izq = value; }
        internal Nodo Der { get => der; set => der = value; }

        public Nodo()
        {
            dato = 0;
            izq = null;
            der = null;
        }
    }
 }

