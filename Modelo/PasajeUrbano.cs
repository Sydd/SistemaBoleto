using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Ivanso 05/11/2015
namespace Modelo
{
    public class PasajeUrbano
    {
        int _Id;
        DateTime _FechaPasaje;
        int _NroInterno;
        int _Autenticacion;
        TransporteUrbano _TransporteUrbano;
        Estudiante _Estudiante;

        //PROPIEDADES_____________________________________________________________________________

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        public DateTime FechaPasaje
        {
            get { return _FechaPasaje; }
            set { _FechaPasaje = value; }
        }
       
        public int NroInterno
        {
            get { return _NroInterno; }
            set { _NroInterno = value; }
        }
        
        public int Autenticacion
        {
            get { return _Autenticacion; }
            set { _Autenticacion = value; }
        }
        
        public TransporteUrbano TransporteUrbano
        {
            get { return _TransporteUrbano; }
            set { _TransporteUrbano = value; }
        }
        
        public Estudiante Estudiante
        {
            get { return _Estudiante; }
            set { _Estudiante = value; }
        }

        public string NombreTransporte
        {
            get { return _TransporteUrbano.Descripcion; }
        }


        //CONSTRUCTORES_____________________________________________________________________________

        public PasajeUrbano(int id, DateTime fechapasaje, int nrointerno, int autenticacion, TransporteUrbano transporteUrbano, Estudiante estudiante)
        {
            Id = id;
            FechaPasaje = fechapasaje;
            NroInterno = nrointerno;
            Autenticacion = autenticacion;
            TransporteUrbano = transporteUrbano;
            Estudiante = estudiante;
        }

        public PasajeUrbano(DateTime fechapasaje, int nrointerno, int autenticacion, TransporteUrbano transporteUrbano, Estudiante estudiante)
        {
            FechaPasaje = fechapasaje;
            NroInterno = nrointerno;
            Autenticacion = autenticacion;
            TransporteUrbano = transporteUrbano;
            Estudiante = estudiante;
        }
       
    }
}