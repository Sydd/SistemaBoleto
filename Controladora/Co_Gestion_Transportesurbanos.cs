using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;

namespace Controladora
{
    public class Co_Gestion_Transportesurbanos
    {
        BD_TransporteUrbano trasportes = BD_TransporteUrbano.Instance();

        public void Agregar(int linea, string descripcion)
        {
            try
            {    
                TransporteUrbano transporte = new TransporteUrbano(linea, descripcion);
                trasportes.Agregar(transporte);    
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void Modificar(TransporteUrbano dato)
        {
            try
            {
                trasportes.Modificar(dato);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void Remover(int id)
        {
            try
            {
                TransporteUrbano transporte = new TransporteUrbano();
                transporte.Id = id;
                trasportes.Remover(transporte);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public TransporteUrbano Buscar_por_Linea(int linea)
        {
            try
            {
                return trasportes.Buscar_por_Linea(linea);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<TransporteUrbano> TraerTodos()
        {
            try
            {
                return trasportes.TraerTodos();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
