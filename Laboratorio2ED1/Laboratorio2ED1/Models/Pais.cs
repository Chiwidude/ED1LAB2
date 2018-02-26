using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2ED1.Models
{
    public class Pais : IComparable
    {
        string Nombre { get; set; }
        string grupo { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;


            var Country = obj as Pais;
            if (Country != null)
            {
                return this.Nombre.CompareTo(Country.Nombre);
            }
            else
                throw new ArgumentException("No esta comparando los atributos correctos");


            
        }
        public override string ToString()
        {
            return  Nombre + " " +  grupo;
        }
    }
}