using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Usuario
    {
        int _Id;
        string _IdUsuario; //es el usuario en el sistema
        private string _Contraseña;
        string _Nombre;
        string _Dni;
        string _mail;
        string _Telefono;
        RolUsuario _RolUsuario;
        InstitucionEducativa _InstitucionEducativa;

        /*PROPIEDADES_________________________________________________________________________*/ 

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        public string Dni
        {
            get { return _Dni; }
            set { _Dni = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public RolUsuario RolUsuario
        {
            get { return _RolUsuario; }
            set { _RolUsuario = value; }
        }

        public InstitucionEducativa InstitucionEducativa
        {
            get { return _InstitucionEducativa; }
            set { _InstitucionEducativa = value; }
        } 

        /*CONSTRUCTOR_________________________________________________________________________*/

        public Usuario() { }

        public Usuario(int p_Id, string p_Nombre, RolUsuario p_RolUsuario)
        {
            Id = p_Id;
            Nombre = p_Nombre;
            RolUsuario = p_RolUsuario;
        }

        public Usuario(int id, string nombre, string contraseña)
        {
            Id = id;
            Nombre = nombre;
            Contraseña = contraseña;
        }

        public Usuario(string p_Nombre, string p_IdUsuario, string p_Contraseña, string p_Dni, string p_Telefono, string p_Mail, RolUsuario p_RolUsuario, InstitucionEducativa p_InstitucionEducativa)
        {
            Nombre = p_Nombre;
            IdUsuario = p_IdUsuario;
            Contraseña = p_Contraseña;
            Dni = p_Dni;
            Telefono = p_Telefono;
            Mail = p_Mail;
            RolUsuario = p_RolUsuario;
            InstitucionEducativa = p_InstitucionEducativa;
        }

        public Usuario(int _ID, string p_ID_usuario, string p_Nombre, string p_Contraseña, string p_Dni, string p_Telefono, string p_Mail, RolUsuario p_RolUsuario, InstitucionEducativa p_InstitucionEducativa)
        {
            Id = _ID;
            IdUsuario = p_ID_usuario;
            Nombre = p_Nombre;
            Contraseña = p_Contraseña;
            Dni = p_Dni;
            Telefono = p_Telefono;
            Mail = p_Mail;
            RolUsuario = p_RolUsuario;
            InstitucionEducativa = p_InstitucionEducativa;
        }


    }
}
