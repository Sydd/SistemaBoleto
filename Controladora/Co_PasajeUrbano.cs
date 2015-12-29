using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;

//Ivanso 05/11/2015
namespace Controladora
{
    public class Co_PasajeUrbano
    {
        Lista_PasajeUrbano ListaPasajeUrbano = Lista_PasajeUrbano.Instance();

        public void Nueva(DateTime ferchapasaje, int nrointerno, int autenticacion, TransporteUrbano transporteurbano, Estudiante estudiante)
        {
            PasajeUrbano oPasajeUrbano = new PasajeUrbano(ferchapasaje, nrointerno, autenticacion, transporteurbano, estudiante);
            ListaPasajeUrbano.Agregar(oPasajeUrbano);
        }

        public List<PasajeUrbano> TraerTodos()
        {
            return ListaPasajeUrbano.TraerTodos();
        }

        public void EliminarPasajeUrbano(PasajeUrbano oPasajeUrbano)
        {
            ListaPasajeUrbano.Remover(oPasajeUrbano);
        }

        public void Buscar_por_ID(int id)
        {
            ListaPasajeUrbano.Buscar_por_ID(id);
        }

    }
}
