using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;

namespace Controladora
{
    public class CO_PasajesUrbanos
    {
        BD_PasajesUrbanos pasajes = BD_PasajesUrbanos.Instance();

        public List<PasajeUrbano> TraerTodos_por_Estudiante(Estudiante dato)
        {
            try
            {
                return pasajes.TraerTodos_por_Estudiante(dato);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
