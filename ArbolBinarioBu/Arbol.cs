using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinarioBu
{
    /// <summary>
    /// Arbol BB
    /// </summary>
    /// <typeparam name="T">Tipo de Dato en Arbol</typeparam>
    public class Arbol<T> where T : IComparable
    {
        List<T> mylist;
        /// <summary>
        /// Nodo Raiz
        /// </summary>
        public Nodo<T> root;

        /// <summary>
        /// Constructor de Arbol BB
        /// </summary>
        public Arbol()
        {
            root = null;
        }


        /// <summary>
        /// Inserta un Nuevo Nodo en Arbol
        /// </summary>
        /// <param name="value">Valor Nodo Nuevo</param>
        public void Insertar(T value)
        {
            var newnode = new Nodo<T>(value);
            if (root == null)
            {
                root = newnode;
            }
            else
            {
                InsertarHijo(newnode, root);
            }
        }

        /// <summary>
        /// Metodo Recursivo de Insercion
        /// </summary>
        /// <param name="nuevo">Nodo Nuevo</param>
        /// <param name="padre">Nodo Padre del Nodo Nuevo</param>
        private void InsertarHijo(Nodo<T> nuevo, Nodo<T> padre)
        {
            if (padre != null)
            {
                if (nuevo.value.CompareTo(padre.value) <= 0)
                {
                    if (padre.izquierdo == null)
                    {
                        nuevo.nivel = padre.nivel + 1;
                        padre.izquierdo = nuevo;
                    }
                    else
                    {
                        InsertarHijo(nuevo, padre.izquierdo);
                    }
                }
                else
                {
                    if (nuevo.value.CompareTo(padre.value) > 0)
                    {
                        if (padre.derecho == null)
                        {
                            nuevo.nivel = padre.nivel + 1;
                            padre.derecho = nuevo;
                        }
                        else
                        {
                            InsertarHijo(nuevo, padre.derecho);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Eliminar la primera apracición de un valor en el Arbol
        /// </summary>
        /// <param name="valor">Valor a Eliminar</param>
        /// <returns>Nodo Eliminado</returns>
        public Nodo<T> Eliminar(T valor)
        {
            var auxiliar = root;
            var padre = root;
            var esHijoIz = true;
            while (auxiliar.value.CompareTo(valor) != 0)
            {
                padre = auxiliar;
                if (valor.CompareTo(auxiliar.value) < 0)
                {
                    esHijoIz = true;
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    esHijoIz = false;
                    auxiliar = auxiliar.derecho;
                }
                if (auxiliar == null)
                {
                    return null;
                }
            }// Fin ciclo inicial

            if (auxiliar.izquierdo == null && auxiliar.derecho == null)
            {
                if (auxiliar == root)
                {
                    root = null;
                }
                else if (esHijoIz)
                {
                    padre.izquierdo = null;
                }
                else
                {
                    padre.derecho = null;
                }
            }
            else if (auxiliar.derecho == null)
            {
                if (auxiliar == root)
                {
                    root = auxiliar.izquierdo;
                }
                else if (esHijoIz)
                {
                    padre.izquierdo = auxiliar.izquierdo;
                }
                else
                {
                    padre.derecho = auxiliar.izquierdo;
                }
            }
            else if (auxiliar.izquierdo == null)
            {
                if (auxiliar == root)
                {
                    root = auxiliar.derecho;
                }
                else if (esHijoIz)
                {
                    padre.izquierdo = auxiliar.derecho;
                }
                else
                {
                    padre.derecho = auxiliar.derecho;
                }
            }
            else
            {
                var reemplazo = Reemplazar(auxiliar);
                if (auxiliar == root)
                {
                    root = reemplazo;
                }
                else if (esHijoIz)
                {
                    padre.izquierdo = reemplazo;
                }
                else
                {
                    padre.derecho = reemplazo;
                }
                reemplazo.izquierdo = auxiliar.izquierdo;

            }
            return auxiliar;
        }

        /// <summary>
        /// Elimina un Nodo mediante sustitucion
        /// </summary>
        /// <param name="Nodoelmiminar">Nodo a Eliminar </param>
        /// <returns>Nodo de Reemplazo</returns>
        private static Nodo<T> Reemplazar(Nodo<T> Nodoelmiminar)
        {
            var reemplazopadre = Nodoelmiminar;
            var reemplazo = Nodoelmiminar;
            var auxiliar = Nodoelmiminar.derecho;
            while (auxiliar != null)
            {
                reemplazopadre = reemplazo;
                reemplazo = auxiliar;
                auxiliar = auxiliar.izquierdo;
            }
            if (reemplazo != Nodoelmiminar.derecho)
            {
                reemplazopadre.izquierdo = reemplazo.derecho;
                reemplazo.derecho = Nodoelmiminar.derecho;
            }
            return reemplazo;
        }

        /// <summary>
        /// Encuentra Nodo con la primera aparicion de un valor en el Arbol
        /// </summary>
        /// <param name="value">Valor buscado</param>
        /// <returns>Nodo con valor buscado</returns>
        public Nodo<T> Encontrar(T value)
        {
            var auxiliar = root;
            while (auxiliar.value.CompareTo(value) != 0)
            {
                if (value.CompareTo(auxiliar.value) < 0)
                {
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    auxiliar = auxiliar.derecho;
                }
                if (auxiliar == null)
                {
                    return null;
                }
            }
            return auxiliar;
        }

        /// <summary>
        /// Determina si el arbol tiene datos
        /// </summary>
        /// <returns></returns>
        bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// Recorre el arbol siguiendo el orden infijo
        /// </summary>
        /// <returns>Contenido del arbol como una cadena de caracteres</returns>
        public List<T> Infijo()
        {
            mylist = new List<T>();
            Infijo(root);
            return mylist;
        }

        /// <summary>
        /// Funcion recursiva que recorre el arbol en orden infijo
        /// </summary>
        /// <param name="raiz">Nodo Raiz</param>
        /// <param name="contenido">Cadena de caracteres con el contenido del arbol</param>
        private void Infijo(Nodo<T> raiz)
        {

            if (raiz != null)
            {
                Infijo(raiz.izquierdo);
                mylist.Add(raiz.value);
                Infijo(raiz.derecho);
            }
        }

        /// <summary>
        /// Recorre el arbol siguendo el orden postfijo
        /// </summary>
        /// <returns>Contenido del arbol como una cadena de caracteres</returns>
        public List<T> Postfijo()
        {
            mylist = new List<T>();
            Postfijo(root);
            return mylist;
        }

        /// <summary>
        /// Funcion recursiva que recorre el arbol en orden postfijo
        /// </summary>
        /// <param name="raiz">Nodo Raiz</param>
        /// <param name="contenido">Cadena de caracteres con el contenido del arbol</param>
        private void Postfijo(Nodo<T> raiz)
        {

            if (raiz != null)
            {
                Postfijo(raiz.izquierdo);
                Postfijo(raiz.derecho);
                mylist.Add(raiz.value);
            }
        }

        /// <summary>
        /// Recorre el arbol siguiendo el orden prefijo
        /// </summary>
        /// <returns>Contenido del arbol como una cadena de caracteres</returns>
        public List<T> Prefijo()
        {
            mylist = new List<T>();
            Prefijo(root);

            return mylist;
        }

        /// <summary>
        /// Funcion recursiva que recorre el arbol en orden prefijo
        /// </summary>
        /// <param name="raiz">Nodo Raiz</param>
        private void Prefijo(Nodo<T> raiz)
        {

            if (raiz != null)
            {
                mylist.Add(raiz.value);
                Prefijo(raiz.izquierdo);
                Prefijo(raiz.derecho);
            }
        }


        /// <summary>
        /// Funcion recursiva que determina la altura de del Arbol
        /// </summary>
        /// <param name="actual">Nodo Raiz</param>
        /// <returns>Altura de Arbol con Nodo Raiz</returns>
        private int Altura(Nodo<T> actual)
        {
            if (actual != null)
            {
                var alturaizquierda = Altura(actual.izquierdo);
                var alturaDerecha = Altura(actual.derecho);

                if (alturaizquierda > alturaDerecha)
                {
                    return alturaizquierda + 1;

                }
                else
                {
                    return alturaDerecha + 1;
                }

            }
            else
            {
                return -1;
            }
        }
        private int AbsValue(int one, int two)
        {
            if ((one - two) < 0)
            {
                return (one - two) * -1;
            }
            else
            {
                return (one - two);
            }
        }
        public Nodo<T> NodoDesbalanceado()
        {
            return EncontrarNodoDesbalanceado(root);
        }
        /// <summary>
        /// Fúnción recursiva, que encuentra el nodo que desbalancea el arbol
        /// </summary>
        /// <param name="node"></param>nodo con el cual realiza la búsqueda
        /// <returns></returns> Nodo que produce el desbalance, en caso exista alguno
        private Nodo<T> EncontrarNodoDesbalanceado(Nodo<T> node)
        {
            if (node != null)
            {
                var balance = AbsValue(Altura(node.izquierdo), Altura(node.derecho));

                if (balance <= 1)
                {
                    if (node.izquierdo != null)
                    {
                        return EncontrarNodoDesbalanceado(node.izquierdo);
                    }
                    else
                    {
                        return EncontrarNodoDesbalanceado(node.derecho);
                    }
                }
                else
                {
                    return node;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Función que recorre el arbol y determina si el arbol se encuentra balanceado o no
        /// </summary>
        /// <param name="node"></param> Nodo con el cual realiza el recorrido
        /// <returns></returns> verdadero si está balanceado o falso en caso no lo esté
        protected bool Balanceado(Nodo<T> node)
        {
            bool valor;

            if (node.izquierdo == null && node.derecho != null)
            {
                valor = this.Balanceado(node.derecho) && (AbsValue(0, Altura(node.derecho)) <= 1);
                return valor;
            }
            else if(node.derecho == null && node.izquierdo != null)
            {
                valor = this.Balanceado(node.izquierdo) && (AbsValue(Altura(node.izquierdo), 0) <= 1);
                return valor;
            }
            else if(node.derecho == null && node.izquierdo == null)
            {
                return true;
            }
            else
            {
                valor = this.Balanceado(node.izquierdo) && this.Balanceado(node.derecho) && (AbsValue(Altura(node.izquierdo), Altura(node.derecho))<= 1);
                return valor;
            }
        }
        public bool Balanceado()
        {
            if (root == null)
                return true;

            return Balanceado(root);
        }
        /// <summary>
        /// Función que determina si el árbol es degenerado
        /// </summary>
        /// <param name="nodo"></param> Nodo inicio de cada ejecución
        /// <returns></returns> verdadero si está degenerado o falso en caso contrario
        protected bool Degenerado(Nodo<T> nodo)
        {
            if(nodo.izquierdo != null)
            {
                if(nodo.derecho != null)
                {
                    return false;
                }
                else
                {
                    return Degenerado(nodo.izquierdo);
                }
            } else
            {
                if(nodo.derecho != null)
                {
                    return Degenerado(nodo.derecho);
                }else
                {
                    return true;
                }
            }
        }
        public bool Degenerado()
        {
            if (root == null)
                return false;
            return Degenerado(root);
               
            
        }
        
            
    }
}
    

