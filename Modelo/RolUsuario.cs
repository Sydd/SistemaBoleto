using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class RolUsuario
    {
        int _Id;
        string _Nombre;
        List<Permiso> _Permisos;
        
        //InstitucionEducativa _InstitucionEducativa;
        
        /*PROPIEDADES_______________________________________________________________*/

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

        public List<Permiso> Permisos
        {
            get { return _Permisos; }
            set { _Permisos = value; }
        }

        //public InstitucionEducativa InstitucionEducativa
        //{
        //    get { return _InstitucionEducativa; }
        //    set { _InstitucionEducativa = value; }
        //}


        //Metodos
        public void Agregar_Permiso(Permiso permiso)
        {
            Permisos.Add(permiso);
        }

        //Constructores
        public RolUsuario() { }

        public RolUsuario(string p_Nombre)
        {
            Nombre               = p_Nombre;   
            
        }
        public RolUsuario(string nombre, List<Permiso> permisos)
        {
            Nombre = nombre;
            Permisos = permisos;
        }

        public RolUsuario(int id, string nombre, List<Permiso> permisos)
        {
            Id = id;
            Nombre = nombre;
            Permisos = permisos;
        }

        public RolUsuario(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }


        
    }
}
