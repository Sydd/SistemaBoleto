using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Capaaccesodatos
{
    public class Lista_Instituciones : CapaDatoAbstractaSingleton<Lista_Instituciones>,I_CapaDatos<InstitucionEducativa>
    {
        private List<InstitucionEducativa> ColeccionInstituciones = new List<InstitucionEducativa>();

        public Lista_Instituciones()
        {

        }

        public void Agregar(InstitucionEducativa dato)
        {
            int Id_ultimo = ColeccionInstituciones.Count + 1; // ultimo Id
            dato.Id = Id_ultimo;
            ColeccionInstituciones.Add(dato);
        }

        public void Remover(InstitucionEducativa dato)
        {
            ColeccionInstituciones.Remove(dato);
        }

        public void Modificar(InstitucionEducativa dato)
        {
            throw new NotImplementedException();
        }

        public InstitucionEducativa Buscar_por_ID(int id)
        {
            InstitucionEducativa oInstitucion = null;

            foreach (InstitucionEducativa r in ColeccionInstituciones)
            {
                if (r.Id == id)
                {
                    oInstitucion = r;
                }
                break;
            }
            return oInstitucion;
        }

        public List<InstitucionEducativa> TraerTodos()
        {
            return ColeccionInstituciones; 
        }

    }
}
