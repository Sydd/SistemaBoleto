using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capaaccesodatos;
using Capa_de_Datos;
using System.Data;

namespace Capaaccesodatos
{
    public class BD_TransporteUrbano : CapaDatoAbstractaSingleton<BD_TransporteUrbano>, I_CapaDatos<TransporteUrbano>
    {

        public void Agregar(TransporteUrbano dato)
        {
            try
            {
                string cmd = @"insert into TransportesUrbanos VALUES (" +
                                                               dato.Linea + ",'" +
                                                               dato.Descripcion + "')";
                Conexion_BD.EjecutarSql(cmd);
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
                string cmd = @"UPDATE TransportesUrbanos 
                             SET linea =" + dato.Linea +
                              ",descripcion='" + dato.Descripcion + "'";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remover(TransporteUrbano dato)
        {
            try
            {
                string cmd = "delete from TransportesUrbanos where(ID_transporteurbano = " + dato.Id + ")";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransporteUrbano Buscar_por_ID(int Id)
        {
            try
            {
                TransporteUrbano oTransporte = null;
                string cmd = "SELECT * FROM TransportesUrbanos WHERE ID_transporteurbano =" + Id;
                DataTable dtTransportes = Conexion_BD.CargarDatos(cmd);
                if (dtTransportes.Rows.Count > 0)
                {
                    DataRow primerafila = dtTransportes.Rows[0];
                    oTransporte = new TransporteUrbano(Convert.ToInt32(primerafila["ID_transporteurbano"]),
                                                        Convert.ToInt32(primerafila["linea"]),
                                                        (string)primerafila["descripcion"]);
                }
                else
                {
                    throw new Exception("No existe el transporte.");
                }
                return oTransporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransporteUrbano Buscar_por_Linea(int Linea)
        {
            try
            {
                TransporteUrbano oTransporte = null;
                string cmd = "SELECT * FROM TransportesUrbanos WHERE linea =" + Linea;
                DataTable dtTransportes = Conexion_BD.CargarDatos(cmd);
                if (dtTransportes.Rows.Count > 0)
                {
                    DataRow primerafila = dtTransportes.Rows[0];
                    oTransporte = new TransporteUrbano(Convert.ToInt32(primerafila["ID_transporteurbano"]),
                                                        Convert.ToInt32(primerafila["linea"]),
                                                        (string)primerafila["descripcion"]);
                }
                else
                {
                    throw new Exception("No existe el transporte.");
                }
                return oTransporte;
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
                List<TransporteUrbano> listatransportes = new List<TransporteUrbano>();
                string cmd = "SELECT * FROM TransportesUrbanos";
                DataTable dtTransportes = Conexion_BD.CargarDatos(cmd);
                foreach (DataRow aux in dtTransportes.Rows)
                {
                    TransporteUrbano oTransporte = new TransporteUrbano(Convert.ToInt32(aux["ID_transporteurbano"]),
                                                        Convert.ToInt32(aux["linea"]),
                                                        (string)aux["descripcion"]);
                    listatransportes.Add(oTransporte);
                }
                return listatransportes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
