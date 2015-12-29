using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;
using Capa_de_Datos;

namespace Controladora
{
    public class Co_RolUsuario
    {
        BD_Roles roles = BD_Roles.Instance();
        //Lista_RolUsuario DatosRolUsuario = Lista_RolUsuario.Instance();
        Co_Permisos oCoPermisos = new Co_Permisos();

        //Constructor, por defecto se crea el rol Admin adentro.
        public Co_RolUsuario()
        {

        }

        public RolUsuario Nuevo(string nombre, List<Permiso> permisos)
        {
            try
            {
                RolUsuario oUsuario = new RolUsuario(nombre, permisos);
                roles.Agregar(oUsuario);
                return oUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RolUsuario> TraerTodos()
        {
            return roles.TraerTodos();
        }

        public RolUsuario Buscar_por_ID(int id)
        {
            try
            {
                return roles.Buscar_por_ID(id);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}
