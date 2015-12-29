using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capa_de_Datos;
using System.Data;

namespace Capaaccesodatos
{
    public class BD_Roles : CapaDatoAbstractaSingleton<BD_Roles>, I_CapaDatos<RolUsuario>
    {
        public void Agregar(RolUsuario dato)
        {

            throw new NotImplementedException();
        }

        public void Remover(RolUsuario dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(RolUsuario dato)
        {
            throw new NotImplementedException();
        }

        public RolUsuario Buscar_por_Nombre(string nombre)
        {
            try
            {
                string cmd = "select * from RolUsuarios where(nombre='" + nombre.ToLower() + "')";
                DataTable dtRoles = Conexion_BD.CargarDatos(cmd);
                if (dtRoles.Rows.Count > 0)
                {
                    RolUsuario oRol = null;
                    foreach (DataRow aux in dtRoles.Rows)
                    {

                        oRol = new RolUsuario(Convert.ToInt32(aux["ID_rol"]), (string)aux["nombre"]);
                    }
                    return oRol;
                }
                else
                    throw new Exception("No se encontro el nivel especificado");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public RolUsuario Buscar_por_ID(int Id)
        {
            try
            {
                string cmd = @"SELECT R.*, P.nombre AS nombre_permiso, P.href
                                 FROM RolUsuarios  R
                                        LEFT JOIN dbo.RolxPermisos AS RP
                                             ON RP.ID_rol = R.ID_rol
                                        LEFT JOIN Permisos as P
                                             ON RP.ID_permiso = P.ID_permiso
                                                      WHERE(R.ID_rol=" + Id + ")";

                DataTable dtRoles = Conexion_BD.CargarDatos(cmd);

                if (dtRoles.Rows.Count > 0)
                {
                    DataRow PrimerCelda = dtRoles.Rows[0];

                    RolUsuario oRol = new RolUsuario(Convert.ToInt32(PrimerCelda["ID_rol"]), 
                                                             (string)PrimerCelda["nombre"]);


                    //Cargo Permisos para el Rol
                    List<Permiso> permisos = new List<Permiso>();
                    foreach (DataRow aux in dtRoles.Rows)
                    {
                        Permiso p = new Permiso((string)aux["nombre_permiso"],
                                                (string)aux["href"]
                                               );
                        permisos.Add(p);
                    }

                    oRol.Permisos = permisos;

                    return oRol;
                }
                else
                    throw new Exception("No se encontro el Rol especificado");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<RolUsuario> TraerTodos()
        {
            try
            {
                List<RolUsuario> roles = new List<RolUsuario>();

                string cmd = @"SELECT * FROM RolUsuarios";

                DataTable dtRoles = Conexion_BD.CargarDatos(cmd);

                foreach (DataRow aux in dtRoles.Rows)
                {
                    RolUsuario rol = new RolUsuario(Convert.ToInt32(aux["ID_rol"]), (string)aux["nombre"]);
                    roles.Add(rol);
                }
                return roles;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
    }
}
