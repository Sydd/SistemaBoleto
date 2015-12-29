using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;
using Capa_de_Datos;

namespace Controladora
{
    public class Co_Gestion_Instituciones
    {
        //Lista_Instituciones Lista_Instituciones = Lista_Instituciones.Instance();
        BD_Institucion Instituciones = BD_Institucion.Instance();
        Co_Niveles_Educativos Controladora_Niveles = new Co_Niveles_Educativos();

        public void Nueva(string _nombre, string _direccion, string _telefono, List<NivelEducativo> _lista)
        {
            InstitucionEducativa oInstitucion = new InstitucionEducativa(_nombre,_direccion,_telefono,_lista);
            Instituciones.Agregar(oInstitucion);
        }

        public void EliminarInstitucion(int Id)
        {
            bool Encontro = false;
            foreach (InstitucionEducativa aux in Instituciones.TraerTodos())
            {
                if (aux.Id == Id)
                {
                    Instituciones.Remover(aux);
                    Encontro = true;
                    break;
                }
            }
            if (!Encontro)
            {
                throw new Exception("No existe el nivel");
            }
            
        }
        
        /// <summary>
        /// Metodo que recibe una lista de IDS (int) selecionados y devuelve una
        /// lista de objetos NivelEducativo
        /// </summary>
        /// <param name="ID_seleccionados">Lista de ids de niveles educativos</param>
        /// <returns></returns>
        public List<NivelEducativo> Niveles_Elegidos(List<int> ID_NivelSeleccionados)
        {
            List<NivelEducativo> ListaNiveles = new List<NivelEducativo>();
            foreach (int x in ID_NivelSeleccionados)
            {
                ListaNiveles.Add(Controladora_Niveles.Buscar_por_ID(x));
            }
            return ListaNiveles;
         
        }

        public List<NivelEducativo> DevolverNiveles()
        {
            return Controladora_Niveles.TraerTodo();
        }

        public InstitucionEducativa Buscar_por_ID(int id)
        {
            try
            {
                return Instituciones.Buscar_por_ID(id);
            }
            catch (Exception ex)
            {
                
                throw ex;
            };
        }

        public List<InstitucionEducativa> TraerTodos()
        {
            return Instituciones.TraerTodos();
        }

    }
}
