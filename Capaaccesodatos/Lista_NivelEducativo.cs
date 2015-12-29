using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Capaaccesodatos
{
    public class Lista_NivelEducativo : CapaDatoAbstractaSingleton<Lista_NivelEducativo>,I_CapaDatos<NivelEducativo>
    {
        private List<NivelEducativo> ColeccionNiveles = new List<NivelEducativo>();


        public void Agregar(NivelEducativo dato)
        {
            int Id_ultimo = ColeccionNiveles.Count + 1; // ultimo Id
            dato.Id = Id_ultimo;
            ColeccionNiveles.Add(dato);
        }

        public void Remover(NivelEducativo dato)
        {
            ColeccionNiveles.Remove(dato);
        }

        public void Modificar(NivelEducativo dato)
        {
            throw new NotImplementedException();
        }

        public List<NivelEducativo> TraerTodos()
        {
            return ColeccionNiveles;
        }

        public NivelEducativo Buscar_por_ID(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
