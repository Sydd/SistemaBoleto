using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;

namespace Capaaccesodatos
{
    
    public class Lista_RolUsuario : CapaDatoAbstractaSingleton<Lista_RolUsuario>,I_CapaDatos<RolUsuario>
    {

        private List<RolUsuario> ColeccionRolUsuario = new List<RolUsuario>();

        public void Agregar(RolUsuario rolUsuario)
        {
            int Id_ultimo = ColeccionRolUsuario.Count + 1; // ultimo Id
            rolUsuario.Id = Id_ultimo;
            ColeccionRolUsuario.Add(rolUsuario);
        }

        public void Remover(RolUsuario dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(RolUsuario dato)
        {
            throw new NotImplementedException();
        }

        public List<RolUsuario> TraerTodos()
        {
            return ColeccionRolUsuario;
        }

        public RolUsuario Buscar_por_ID(int id)
        {
            RolUsuario oRol = null;

            foreach (RolUsuario r in ColeccionRolUsuario)
            {
                if (r.Id == id)
                {
                    oRol = r;
                }
                break;
            }
            return oRol;
        }

    }
}
