using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masterpage
{
    public class rol
    {
        int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

     
        public rol(int pId,string Pnombre)
        {
            Id = pId;
            Nombre = Pnombre;
        }

    }
}