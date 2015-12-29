using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capaaccesodatos;
using Modelo;

namespace Controladora
{
    public class Co_Permisos
    {
        Lista_Permisos DatosPermisos = Lista_Permisos.Instance();
        

        public Co_Permisos()
        {
        }

        public void Nuevo(string nombre, string href)
        {
            try
            {
                Permiso oPermiso = new Permiso(nombre, href);
                DatosPermisos.Agregar(oPermiso);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public List<Permiso> TraerTodos()
        {
            return DatosPermisos.TraerTodos();
        }

        /// <summary>
        /// Buscar un Permiso por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto Permiso</returns>
        public Permiso Buscar_por_ID(int id)
        {
            try
            {
                return DatosPermisos.Buscar_por_ID(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void  Test_Datos()
        {
            Nuevo("Administrar Usuarios", "abmUsuarios.aspx");
            Nuevo("Administrar Instituciones", "abmInstituciones.aspx");
            Nuevo("Administrar Transporte Urbano", "abmTransUrbano.aspx");
            Nuevo("Administrar Estudiantes", "abmEstudiante.aspx");
            Nuevo("Activar Estudiante", "ActivarEstudiante.aspx");

        }
    }
}
