using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2ED1.Models
{
    public class Numero: IComparable
    {
        public int Valor { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;


            var number = obj as Numero;
            if (number != null)
            {
                return this.Valor.CompareTo(number.Valor);
            }
            else
                throw new ArgumentException("No esta comparando los atributos correctos");
        }
    }
}