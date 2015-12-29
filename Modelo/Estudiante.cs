using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    // HECHA POR IVANSO EL 29/10/2015______________________________________________________________
    public class Estudiante : Usuario
    {
        string _Qr;
        DateTime _Fecha_Alta;
        bool _Activo;

        // __PROPIEDADES____________________________________________________________

        public string Qr
        {
            get { return _Qr; }
            set { _Qr = value; }
        }
        
        public DateTime Fecha_Alta
        {
            get { return _Fecha_Alta; }
            set { _Fecha_Alta = value; }
        }
       
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        // CONSTRUCTOR ______________________________________________________________

        public Estudiante(int id, string nombre, RolUsuario rol)
            : base(id, nombre, rol)
        {
          
        }
        public Estudiante(int id, string username, string dni, string pass, string nombre, string mail, string telefono, string qr, DateTime alta, bool activo,RolUsuario rol,InstitucionEducativa insti)
        : base (id,username,nombre,pass,dni,telefono, mail, rol, insti) 
        {
            Qr= qr;
            Fecha_Alta = alta;
            Activo = activo;
        }

         public Estudiante(string username, string dni, string pass, string nombre, string mail, string telefono, string qr, DateTime alta, bool activo,RolUsuario rol,InstitucionEducativa insti)
        : base (nombre,username,pass,dni,telefono, mail, rol, insti) 
        {
            Qr= qr;
            Fecha_Alta = alta;
            Activo = activo;
        }

         public Estudiante() { }

    }
}