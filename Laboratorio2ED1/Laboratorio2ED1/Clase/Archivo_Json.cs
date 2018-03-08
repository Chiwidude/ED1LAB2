using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArbolBinarioBu;
using System.IO;
using Newtonsoft.Json;

namespace Laboratorio2ED1.Clase
{
    public class Archivo_Json<T>
    {
        public Nodo<T> Dato(Stream ruta)
        {
            try
            {
                Nodo<T> _aux;
                StreamReader lector1 = new StreamReader(ruta);
                string Informacion = lector1.ReadToEnd();
                _aux = JsonConvert.DeserializeObject<Nodo<T>>(Informacion);
                lector1.Close();
                return _aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}