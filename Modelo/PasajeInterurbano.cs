using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class PasajeInterurbano
    {
        int _Id;
        Asiento _Asiento;
        Frecuencia _Frecuencia;
        DateTime _Fecha_Hora;
        Ruta _Ruta;
        Estudiante _Estudiante;
        TransporteInterurbano _TransporteInterurbano;



        /*PROPIEDADES________________________________________________________________________________*/

        public Asiento Asiento
        {
            get { return _Asiento; }
            set { _Asiento = value; }
        }
        
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
       
        public DateTime Fecha_Hora
        {
            get { return _Fecha_Hora; }
            set { _Fecha_Hora = value; }
        }

        public Frecuencia Frecuencia
        {
            get { return _Frecuencia; }
            set { _Frecuencia = value; }
        }

        public Estudiante Estudiante
        {
            get { return _Estudiante; }
            set { _Estudiante = value; }
        }
        public Ruta Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }

        public TransporteInterurbano TransporteInterurbano
        {
            get { return _TransporteInterurbano; }
            set { _TransporteInterurbano = value; }
        }

        /*CONSTRUCTOR________________________________________________________________________________*/

        public PasajeInterurbano() { }
        public PasajeInterurbano(TransporteInterurbano p_TransporteInterurbano, Asiento p_Asiento, int p_Id, DateTime p_Fecha_Hora)
        {
            TransporteInterurbano = p_TransporteInterurbano; //si tira error revisar esto la prop se llama igual que la clase
            Asiento = p_Asiento;
            Id = p_Id;
            Fecha_Hora = p_Fecha_Hora;
        }
    }
}