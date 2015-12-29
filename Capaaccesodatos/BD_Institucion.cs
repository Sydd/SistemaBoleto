using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capa_de_Datos;
using System.Data;
namespace Capaaccesodatos
{
    public class BD_Institucion : CapaDatoAbstractaSingleton<BD_Institucion>,I_CapaDatos<InstitucionEducativa>
    {
        public void Agregar(InstitucionEducativa dato)
        {
            try
            {
                string cmd = "insert into Instituciones values '" + dato.Nombre + "','"+ dato.Direccion +"',"+ dato.Telefono + " SELECT @@IDENTITY";
                dato.Id = Conexion_BD.EjecutarEscalar(cmd);
                foreach (NivelEducativo aux in dato.ListaNiveles)
                {
                    cmd = "insert into InstixNiveles values (" + aux.Id + "," + dato.Id  + ")";
                    Conexion_BD.EjecutarSql(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remover(InstitucionEducativa dato)
        {
            try
            {
                string cmd = "delete from NivelesEducativos where(ID_institucion=" + dato.Id + ")";
                Conexion_BD.EjecutarSql(cmd);

    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(InstitucionEducativa dato)
        {
            try
            {
                string cmd = "UPDATE Instituciones SET nombre=" + "'" + dato.Nombre + 
                            "',direccion ='" + dato.Direccion + 
                            "',telefono='" + dato.Telefono + 
                            "' WHERE ID_institucion = " + dato.Id;                
                Conexion_BD.EjecutarSql(cmd);       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InstitucionEducativa> TraerTodos()
        {          
            try
            {
                List<InstitucionEducativa> listaInstituciones = new List<InstitucionEducativa>();
                string cmd = "select ID_institucion as ID FROM Instituciones";
                DataTable dtInstituciones = Conexion_BD.CargarDatos(cmd);
                foreach (DataRow aux in dtInstituciones.Rows)
                {
                    InstitucionEducativa institucion = Buscar_por_ID(Convert.ToInt32(aux["ID"]));
                    listaInstituciones.Add(institucion);
                }
                return listaInstituciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca la institucion por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public InstitucionEducativa Buscar_por_ID(int Id)
        {
            try
            {
                BD_NivelEducativo  bdniveles = BD_NivelEducativo.Instance();
                //Este codigo SQL es un poco complejo, despues lo charlamos. (funciona)
                //Trae la Institucion con sus niveles.
                string cmd =    @"SELECT INS.nombre,INS.ID_institucion,INS.direccion,INS.telefono,IxN.ID_nivel,N.nivel 
                                FROM Instituciones as INS
                                LEFT JOIN InstixNiveles as IxN
                                ON INS.ID_institucion=IxN.ID_institucion
                                LEFT JOIN NivelesEducativos as N
                                ON IxN.ID_nivel = N.ID_nivel
                                WHERE(INS.ID_institucion=" + Id + ")";

                DataTable dtInstituciones = Conexion_BD.CargarDatos(cmd);
                if (dtInstituciones.Rows.Count > 0)
                {
                    List<NivelEducativo> listaNiveles = new List<NivelEducativo>();
                    foreach (DataRow aux in dtInstituciones.Rows)
                    {
                        NivelEducativo nivel = new NivelEducativo(Convert.ToInt32(aux["ID_nivel"]),(string)aux["nivel"]);
                        listaNiveles.Add(nivel);
                    }

                    DataRow PrimerCelda = dtInstituciones.Rows[0];
                    InstitucionEducativa institucion = new InstitucionEducativa((string)PrimerCelda["nombre"], (string)PrimerCelda["direccion"], Convert.ToString(PrimerCelda["telefono"]), listaNiveles, Convert.ToInt32(PrimerCelda["ID_institucion"]));
                    return institucion;
                }
                else
                    throw new Exception("No se encontro la institucion especificada");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
