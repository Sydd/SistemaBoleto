using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class NivelEducativo
    {
        int _Id;
        string _Nivel;


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
       

        public string Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }

        public NivelEducativo(string nivel)
        {
            Nivel = nivel;
        }

        public NivelEducativo(int id, string nivel)
        {
            Id = id;
            Nivel = nivel;
        }

        public NivelEducativo()
        {
        }
    }
}