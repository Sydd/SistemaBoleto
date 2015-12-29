using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Permiso
    {
        int _Id;
        string _Nombre;
        string _Href;


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Href
        {
            get { return _Href; }
            set { _Href = value; }
        }

       
        public Permiso(string nombre, string href) 
        {
            Nombre = nombre;
            Href   = href;
        }

        public Permiso()
        {
        }
    }
}
