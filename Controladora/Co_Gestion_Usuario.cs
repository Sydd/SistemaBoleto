using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capaaccesodatos;
using Modelo;

namespace Controladora
{
    public class Co_Gestion_Usuario
    {
        
        //Instancia Lista
        //Lista_Usuarios DatosUsuario = Lista_Usuarios.Instance();

        BD_Usuarios Usuarios = BD_Usuarios.Instance();
        Co_Gestion_Estudiantes Estudiantes = new Co_Gestion_Estudiantes();

        //Constructor
        public Co_Gestion_Usuario()
        {
        }


        public void Modificar(int id, string iusuario, string nombre, string contraseña, string dni, string telefono, string mail, RolUsuario rolusuario, InstitucionEducativa institucion){
            try
            {
                Usuario usuario = new Usuario(id, iusuario, nombre, contraseña, dni, telefono, mail, rolusuario, institucion);
                Usuarios.Modificar(usuario);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //Metodos
        public void Agregar(string p_Nombre, string p_IdUsuario, string p_Contraseña, string p_Dni, string p_Telefono, string p_Mail, RolUsuario p_RolUsuario, InstitucionEducativa p_InstitucionEducativa)
        { 
            try 
	        {
                Usuario oUsuario = new Usuario(p_Nombre, p_IdUsuario, p_Contraseña, p_Dni, p_Telefono, p_Mail, p_RolUsuario, p_InstitucionEducativa);
                Usuarios.Agregar(oUsuario);

	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
     
        public List<Usuario> Traer_todo()
        {
            return Usuarios.TraerTodos();
        }

        public Usuario Buscar_por_ID(int id)
        {
            return Usuarios.Buscar_por_ID(id);
        }

        public void Remover(int id, string usuario)
        {
            Usuario ousuario = new Usuario();
            ousuario.Id = id;
            ousuario.IdUsuario = usuario;

            Usuarios.Remover(ousuario);
        }

        /// <summary>
        /// Retorna un usuario completo por su nombre en sistema.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario Buscar_por_Nombre(string usuario)
        {
            try
            {
                Usuario u = Usuarios.Buscar_por_Usuario(usuario);
                u = Usuarios.Buscar_por_ID(u.Id);
                return u;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Valida el usuario ingresado en el login
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Contraseña"></param>
        /// <returns>Objeto Usuario</returns>
        public Usuario Validar_Usuario(string usuario, string contraseña)
        {
            try
            {               
                Usuario oUsuario = Usuarios.Buscar_por_Usuario(usuario);

                //si la contraseña es valida cargo el usuario completo
                if (oUsuario.Contraseña == contraseña)
                {
                    if (oUsuario.RolUsuario.Nombre == "estudiante")
                    {
                        Estudiante oEstudiante = Estudiantes.Buscar_por_ID(oUsuario.Id) as Estudiante;
                        if (oEstudiante.Activo)
                        {
                            oUsuario = oEstudiante;
                        }
                        else
                        {
                            throw new Exception("Usted no esta Activado");
                        }                                   
                    }
                    else
                    {
                        oUsuario = Buscar_por_ID(oUsuario.Id);
                    }                                     
                }
                else
                {
                    throw new Exception("La contraseña no coincide");
                }
                return oUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// <summary>
        /// Comprueba que la pagina ingresada este dentro de los permisos del rol
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="paginaActual"></param>
        /// <returns></returns>
        public bool Comprobar_Permiso_Acceso(Usuario usuario, string paginaActual)
        {
            bool autorizado = false;

            foreach (Permiso permiso in usuario.RolUsuario.Permisos)
            {
                if (permiso.Href == paginaActual)
                {
                    autorizado = true;
                    break;
                }
            }

            return autorizado;
        }

    }
}
