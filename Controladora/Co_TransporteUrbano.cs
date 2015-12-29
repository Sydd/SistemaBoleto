using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;
using Capa_de_Datos;

//Ivanso 05/11/2015
namespace Controladora
{
    public class Co_TransporteUrbano
    {
        Lista_TransporteUrbano ListaTransporteUrbano = Lista_TransporteUrbano.Instance();

        public void Nueva(int linea, string descripcion)
        {
            TransporteUrbano oTransporteUrbano = new TransporteUrbano(linea, descripcion);
            ListaTransporteUrbano.Agregar(oTransporteUrbano);
        }

        public List<TransporteUrbano> TraerTodos()
        {
            return ListaTransporteUrbano.TraerTodos();
        }

        public void EliminarTransporteUrbano(TransporteUrbano oTransporteUrbano)
        {
            ListaTransporteUrbano.Remover(oTransporteUrbano);
        }

        public void Buscar_por_ID(int id)
        {
            ListaTransporteUrbano.Buscar_por_ID(id);
        }
    }
}
