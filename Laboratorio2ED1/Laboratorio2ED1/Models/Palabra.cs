using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2ED1.Models
{
    public class Palabra : IComparable
    {
        public string Valor { get; set; }


        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;


            var cadena = obj as Palabra;
            if (cadena != null)
            {
                return this.Valor.CompareTo(cadena.Valor);
            }
            else
                throw new ArgumentException("No esta comparando los atributos correctos");
        }
    }
}