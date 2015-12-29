using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using Capa_de_Datos;

namespace Capaaccesodatos
{
    public class BD_NivelEducativo : CapaDatoAbstractaSingleton<BD_NivelEducativo>, I_CapaDatos<NivelEducativo>
    {
        public void Agregar(NivelEducativo dato)
        {
            try
            {
                string cmd = "insert into NivelesEducativos values ('" + dato.Nivel + "')" ;
                Conexion_BD.EjecutarSql(cmd);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remover(NivelEducativo dato)
        {
            try
            {
                string cmd = "delete from NivelesEducativos where(ID_nivel=" + dato.Id + ")";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(NivelEducativo dato)
        {
            try
            {
                string cmd = "UPDATE NivelesEducativos SET nivel= ' " + dato.Nivel + "'";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NivelEducativo> TraerTodos()
        {
            try
            {
                List<NivelEducativo> listaNiveles = new List<NivelEducativo>();
                string cmd = "select * from NivelesEducativos";
                DataTable dtNiveles = Conexion_BD.CargarDatos(cmd);
                foreach (DataRow aux in dtNiveles.Rows)
                {
                    NivelEducativo nivel = new NivelEducativo(Convert.ToInt32(aux["ID_nivel"]),(string)aux["nivel"]);
                    listaNiveles.Add(nivel);
                }
                return listaNiveles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NivelEducativo Buscar_por_ID(int dato)
        {
           try
            {
                string cmd = "select * from NivelesEducativos where(ID_nivel=" + dato + ")";
                DataTable dtNiveles = Conexion_BD.CargarDatos(cmd);
                if (dtNiveles.Rows.Count > 0 )
                {
                    NivelEducativo nivel= null;
                    foreach (DataRow aux in dtNiveles.Rows)
                    {
                        nivel = new NivelEducativo(Convert.ToInt32(aux["ID_nivel"]),(string)aux["nivel"]);
                    }
                    return nivel;
                }
                else
                    throw new Exception ("No se encontro el nivel especificado");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SolicitarId()
        {
            throw new NotImplementedException();
        }

    }
    
}
