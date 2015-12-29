using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class InstitucionEducativa
    {
        int _Id;
        string _Nombre;
        string _Direccion;
        string _Telefono;
        List<NivelEducativo> _ListaNiveles;

        // PROPIEDADES___________________________
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public List<NivelEducativo> ListaNiveles
        {
            get { return _ListaNiveles; }
            set { _ListaNiveles = value; }
        }


        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
       
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public InstitucionEducativa(string nombre, string direccion, string telefono, List<NivelEducativo> lista)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListaNiveles = lista;
        }

        public InstitucionEducativa(string nombre, string direccion, string telefono, List<NivelEducativo> lista,int ID)
        {
            Id = ID;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListaNiveles = lista;
        }

        public InstitucionEducativa()
        {
        }
    }
}