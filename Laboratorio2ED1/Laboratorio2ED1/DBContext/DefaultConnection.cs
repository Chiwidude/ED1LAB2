using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArbolBinarioBu;
namespace Laboratorio2ED1.DBContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection instance;

        private static object sync = new Object();

        public Arbol<Models.Pais> Paises = new Arbol<Models.Pais>();

        public Arbol<int> Numeros = new Arbol<int>();

        public Arbol<string> Cadenas = new Arbol<string>();

        public static DefaultConnection getInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new DefaultConnection();
                        }
                    }
                }

                return instance;
            }
        }
    }
}