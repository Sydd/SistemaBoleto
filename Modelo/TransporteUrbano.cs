using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Ivanso 05/11/2015
namespace Modelo
{
    public class TransporteUrbano
    {
        int _Id;
        int _Linea;
        string _Descripcion;

        //PROPIEDADES______________________________________________________________________
        
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
   
        public int Linea
        {
            get { return _Linea; }
            set { _Linea = value; }
        }
       
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        //CONSTRUCTORES______________________________________________________________________

        public TransporteUrbano(int linea, string descripcion)
        {
            Linea = linea;
            Descripcion = descripcion;
        }

        public TransporteUrbano(int id, int linea, string descripcion)
        {
            Id = id;
            Linea = linea;
            Descripcion = descripcion;
        }

        public TransporteUrbano() { }

    }
}