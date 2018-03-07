using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArbolBinarioBu;
namespace Laboratorio2ED1.DBContext
{
    public class DefaultConnection<T>
    {
        private static volatile DefaultConnection<T> instance;

        private static object sync = new Object();

        public Arbol<Models.Pais> Paises = new Arbol<Models.Pais>();

        public Arbol<Models.Numero> Numeros = new Arbol<Models.Numero>();

        public Arbol<Models.Palabra> Cadenas = new Arbol<Models.Palabra>();

        public static DefaultConnection<T> getInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new DefaultConnection<T>();
                        }
                    }
                }

                return instance;
            }
        }
    }
}