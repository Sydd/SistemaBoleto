using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;
using Capa_de_Datos;

namespace Controladora
{
    public class Co_Niveles_Educativos
    {
        //Lista_NivelEducativo niveles = Lista_NivelEducativo.Instance();
        BD_NivelEducativo niveles = BD_NivelEducativo.Instance();

        public void NuevoNivel(string nivel)
        {
            NivelEducativo oNivel = new NivelEducativo(nivel);
            niveles.Agregar(oNivel);
        }

        public void EliminarNivel(int Id)
        {
            bool Encontro = false;
            foreach (NivelEducativo aux in niveles.TraerTodos())
            {
                if (aux.Id == Id)
                { 
                   niveles.Remover(aux);
                   Encontro = true;
                   break;
                }
            }
            if (!Encontro)
            {
                throw new Exception("No existe el nivel");
            }
        }

        public NivelEducativo Buscar_por_ID(int Id)
        {
            NivelEducativo oNivel = null;
            foreach (NivelEducativo aux in niveles.TraerTodos())
            {
                if (aux.Id == Id)
                {
                    oNivel=aux;
                    break;
                }
            }
            if (oNivel== null)
            {
                throw new Exception("El nivel no existe");
            }
            return oNivel;
        }

        public List<NivelEducativo> TraerTodo()
        {
            return niveles.TraerTodos();
        }

        public void Test_Niveles()
        {
            NuevoNivel("Primario");
            NuevoNivel("Secundario");
            NuevoNivel("Terciario");
            NuevoNivel("Universitario");
        }
    }
}
