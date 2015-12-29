using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Capaaccesodatos
{
    public class Lista_Permisos : CapaDatoAbstractaSingleton<Lista_Permisos>,I_CapaDatos<Permiso>
    {
        private List<Permiso> ColeccionPermisos = new List<Permiso>();

        public void Agregar(Permiso permiso)
        {
            int Id_ultimo = ColeccionPermisos.Count + 1; // ultimo Id
            permiso.Id = Id_ultimo;
            ColeccionPermisos.Add(permiso);
        }

        public void Remover(Permiso dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Permiso dato)
        {
            throw new NotImplementedException();
        }

        public List<Permiso> TraerTodos()
        {
            return ColeccionPermisos;
        }

        public Permiso Buscar_por_ID(int id)
        {
            Permiso oPermiso = null;

            foreach (Permiso p in ColeccionPermisos)
            {
                if (p.Id == id)
                {
                    oPermiso = p;
                    break;
                }
               
            }
            return oPermiso;
        }

    }
}
