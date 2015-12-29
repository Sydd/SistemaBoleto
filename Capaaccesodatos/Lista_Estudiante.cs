using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Capaaccesodatos
{
    public class Lista_Estudiante : CapaDatoAbstractaSingleton<Lista_Estudiante>,I_CapaDatos<Estudiante>
    {
        private List<Estudiante> ColeccionEstudiante= new List<Estudiante>();
        public void Agregar(Estudiante dato)
        {
            int Id_ultimo = ColeccionEstudiante.Count + 1; // ultimo Id
            dato.Id = Id_ultimo;
            ColeccionEstudiante.Add(dato);
        }

        public void Remover(Estudiante dato)
        {
            ColeccionEstudiante.Remove(dato);
        }

        public void Modificar(Estudiante dato)
        {
            throw new NotImplementedException();
        }

        public List<Estudiante> TraerTodos()
        {
            return ColeccionEstudiante;
        }

        public Estudiante Buscar_por_ID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
