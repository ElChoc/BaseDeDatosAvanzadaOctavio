using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArbolBinario
{
    internal class ArbolBB
    {
        private Nodo raiz;
        private Nodo trabajo;

        private int i = 0;

        public ArbolBB()
        {
            raiz = null;
        }

        internal Nodo Raiz { get => raiz; set => raiz = value; }

        //Insertar

        public Nodo Insertar(int pDato, Nodo pNodo)
        {
            Nodo temp = null;
            //Si no hay a quien insertar entonces creamos el nodo
            if (pNodo == null)
            {
                temp = new Nodo();
                temp.Dato = pDato;

                return temp;
            }

            if (pDato < pNodo.Dato)
            {
                pNodo.Izq = Insertar(pDato, pNodo.Izq);
            }

            if (pDato > pNodo.Dato)
            {
                pNodo.Der = Insertar(pDato, pNodo.Der);
            }
            return pNodo;
        }
        
        //Transversa
        public void Transversa(Nodo pNodo)
        {
            if (pNodo == null)
                return;

            //Me proceseo primero a mi
            for (int n = 0; n < i; n++)
                Console.Write(" ");

            Console.WriteLine(pNodo.Dato);
            //Si tengo izquierda, proceso a la izquierda
            if(pNodo.Izq != null)
            {
                i++;
                Console.Write("I ");
                Transversa(pNodo.Izq);
                i--;
            }
            //Si tengo a la derecha, proceso a la derecha
            if(pNodo.Der != null)
            {
                i++;
                Console.Write("D ");
                Transversa(pNodo.Der);
                i--;
            }

        }
        //BuscarPadre
        public Nodo BuscarPadre(int pDato, Nodo pNodo)
        {
            Nodo temp = null;

            if (pNodo == null)
                return null;
            //Verifico si soy el padre
            if (pNodo.Izq != null)
                if (pNodo.Izq.Dato == pDato)
                    return null;

            if (pNodo.Der != null)
                if (pNodo.Der.Dato == pDato)
                    return pNodo;
            //Si tengo izquierda, proceso a la izquierda
            if(pNodo.Izq != null && pDato < pNodo.Izq.Dato)
            {
                temp = BuscarPadre(pDato, pNodo.Izq);
            }
            //Si tengo a la derecha, proceso a la derecha
            if(pNodo.Der != null && pDato > pNodo.Dato)
            {
                temp = BuscarPadre(pDato, pNodo.Der);
            }

            return temp;

        }
        //Encontrar Minimo
        public int EncuentraMinimo(Nodo pNodo)
        {
            if (pNodo == null)
                return 0;

            trabajo = pNodo;
            int minimo = trabajo.Dato;

            while(trabajo.Izq != null)
            {
                trabajo = trabajo.Izq;
                minimo = trabajo.Dato;
            }

            return minimo;
        }
        //Encuentra el Maximo
        public int EncuentraMaximo(Nodo pNodo)
        {
            if (pNodo == null)
                return 0;
            trabajo = pNodo;
            int maximo = trabajo.Dato;

            while(trabajo.Der != null)
            {
                trabajo = trabajo.Der;
                maximo = trabajo.Dato;
            }
            return maximo;
        }
        //Transervsa Ordenada
        public void TransversaOrdenada(Nodo pNodo)
        {
            if (pNodo == null)
                return;
            //Si tengo izquierda, proceso a la izquierda
            if(pNodo.Izq != null){
                i++;
                TransversaOrdenada(pNodo.Izq);
                i--;
            }

            Console.Write("{0}, ", pNodo.Dato);
            //Si tengo a la derecha, proceso a la derecha
            if(pNodo != null)
            {
                i++;
                TransversaOrdenada(pNodo.Der);
                i--;
            }

        }
        //Find
        public Nodo Find(int key)
        {
            Nodo current = raiz;
            while(current.Dato != key)
            {
                if (key < current.Dato)
                    current = current.Izq;
                else current = current.Der;
                if (current == null)
                    return null;
            }
            return current;
        }

        //Eliminar Nodo English
        private Nodo Delete(Nodo raiz, Nodo deleteNodo)
        {
            Nodo pNodo = raiz;
            if(pNodo == null)
            {
                return pNodo;
            }
            if(deleteNodo.Dato < pNodo.Dato)
            {
                pNodo.Izq = Delete(pNodo.Izq, deleteNodo);
            }
            if(deleteNodo.Dato > pNodo.Dato)
            {
                pNodo.Der = Delete(pNodo.Der, deleteNodo);
            }
            if(deleteNodo.Dato == pNodo.Dato)
            {
                //No Child Nodes
                if (pNodo.Izq == null && pNodo.Der == null)
                {
                    pNodo = null;
                    return pNodo;
                }
                else if (pNodo.Izq == null) 
                { 
                    Nodo temp = pNodo;
                    pNodo = pNodo.Der;
                    temp = null;
                }
                //No Right child
                else if (pNodo.Der == null)
                {
                    Nodo temp = pNodo;
                    pNodo = pNodo.Izq;
                    temp = null;
                }
                else {
                    Nodo min = Find(pNodo.Der.Dato);
                    pNodo.Dato = min.Dato;
                    pNodo.Der = Delete(pNodo.Der, min);
                }
            }

            return null;
        }

        public void DeleteNode(int x)
        {
            Nodo deleteNode = new Nodo();
            deleteNode.Dato = x;
            Delete(raiz, deleteNode);
        }

        //-----------------------------------------------------------
        //Eliminar Nodo
        /*
        public Nodo borrar(Nodo pNodo, int pDato)
        {
            if (pNodo == null)
                return pNodo;
            else
                if (pDato < pNodo.Dato)
                {
                pNodo.Izq = borrar(pNodo.Izq, pDato);
                }
                else
                    if (pDato > pNodo.Dato)
                    {
                pNodo.Der = borrar(pNodo.Der,pDato);
                    }
                    else
                    {

                    }
        }
        
        ///
        public Nodo Delete(Nodo pNodo, int pDato)
        {
            if (pNodo == null)
            {
                return pNodo;
            }

            if (pDato < pNodo.Dato)
            {
                pNodo.Izq = Delete(pNodo.Izq, pDato);
            }

            if (pDato > pNodo.Dato)
            {
                pNodo.Der = Delete(pNodo.Der, pDato);
            }

            if (pNodo.Der == null && pNodo.Izq == null && pNodo.Dato == pDato)
            {
                pNodo = null;
                return pNodo;
            }
            else if (pNodo.Izq == null && pNodo.Dato == pDato)
            {
                Nodo temp = pNodo.Der;
                pNodo.Der = null;
                return temp;
            }
            else if (pNodo.Der == null && pNodo.Dato == pDato)
            {
                Nodo temp = pNodo.Izq;
                pNodo.Izq = null;
                return temp;
            }
            else if (pNodo.Der != null && pNodo.Izq != null && pNodo.Dato == pDato)
            {
                Nodo min = EncuentraMinimo(pNodo.Der);
                pNodo.Dato = min.Dato;
                pNodo.Der = Delete(pNodo.Der, min.Dato);
            }
            return pNodo;
        }
        */
    }
}
