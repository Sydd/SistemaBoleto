using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Capa_de_Datos;
using System.Data;
using System.Data.SqlClient;

namespace Capaaccesodatos
{
    public class BD_Usuarios : CapaDatoAbstractaSingleton<BD_Usuarios>,I_CapaDatos<Usuario>
    {

        public void Agregar(Usuario dato)
        {
            try
            {
                string cmd = "insert into Usuarios VALUES (" + dato.RolUsuario.Id + "," +
                                                               dato.InstitucionEducativa.Id + ",'" +
                                                               dato.Nombre + "'," + 
                                                               dato.Dni + ",'" + 
                                                               dato.Mail + "'," +
                                                               dato.Telefono + ",'" +
                                                               dato.Contraseña + "','" +
                                                               dato.IdUsuario + "')";
                Conexion_BD.EjecutarSql(cmd);
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
         /// <summary>
        /// Agrega un Usuario y retorna la ID
        /// </summary>
        /// <returns></returns> 
        public int AgregarEscalado(Usuario dato)
        {
            try
            {
                string cmd = "insert into Usuarios VALUES (" + dato.RolUsuario.Id + "," +
                                                               dato.InstitucionEducativa.Id + ",'" +
                                                               dato.Nombre + "','" + 
                                                               dato.Dni + "','" + 
                                                               dato.Mail + "','" +
                                                               dato.Telefono + "','" +
                                                               dato.Contraseña + "','" +
                                                               dato.IdUsuario + "') SELECT @@IDENTITY";
               return  Conexion_BD.EjecutarEscalar(cmd);
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(Usuario dato)
        {
            try
            {
                string cmd = "delete  Usuarios where Id_usuario=" + dato.Id ;
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(Usuario dato)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> TraerTodos()
        {       
            try
            {
                List<Usuario> listaUsuariosAux = new List<Usuario>();
                string cmd = @"SELECT U.ID_usuario,U.nombre,R.nombre as 'Rol',I.nombre as 'Institucion',U.dni,U.mail,U.telefono,U.password,U.usuario
                               FROM Usuarios as U
                               LEFT JOIN Instituciones as I
                                    ON U.ID_institucion = I.ID_institucion
                               LEFT JOIN RolUsuarios as R
                                    ON U.ID_rol = R.ID_rol
                                         WHERE R.nombre <> 'estudiante'";

                DataTable dtUsuarios = Conexion_BD.CargarDatos(cmd);
                foreach (DataRow aux in dtUsuarios.Rows)
                {
                    
                    Usuario user = new Usuario(Convert.ToInt32(aux["ID_usuario"]),
                                                       (string)aux["usuario"],
                                                       (string)aux["nombre"],
                                                       (string)aux["password"],
                                             Convert.ToString( aux["dni"] ),
                                             Convert.ToString( aux["telefono"] ),
                                                       (string)aux["mail"],
                                                                    null,
                                                                    null);

                    listaUsuariosAux.Add(user);

                }
                return listaUsuariosAux;
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }

        }

        public Usuario Buscar_por_ID(int Id)
        {
            try
            {
    
                //La consulta devuelve el Usuario, su Rol y los Permisos
                    string cmd = @"SELECT U.*, R.ID_rol, R.nombre AS nombre_rol, P.ID_permiso AS ID_permiso, P.nombre AS nombre_permiso, P.href AS href
                                        FROM dbo.Usuarios AS U
                                            LEFT JOIN dbo.RolUsuarios AS R
                                                ON R.ID_rol = U.ID_rol
                                            LEFT JOIN dbo.RolxPermisos AS RP
                                                ON RP.ID_rol = R.ID_rol
                                            LEFT JOIN Permisos as P
                                                ON RP.ID_permiso = P.ID_permiso
                                                    WHERE(U.ID_usuario=" + Id + ")";

                

                DataTable dtUsuario = Conexion_BD.CargarDatos(cmd);
                if (dtUsuario.Rows.Count > 0)
                {

                    DataRow PrimerCelda = dtUsuario.Rows[0];

                    //Cargo datos del Usuario
                    Usuario oUsuario = new Usuario(Convert.ToInt32(PrimerCelda["ID_usuario"]),
                                                     (string)PrimerCelda["usuario"],
                                                     (string)PrimerCelda["nombre"],
                                                     (string)PrimerCelda["password"],
                                                     Convert.ToString(PrimerCelda["dni"]),
                                                     Convert.ToString(PrimerCelda["telefono"]),
                                                     (string)PrimerCelda["mail"],
                                                     null,
                                                     null
                                                  );  
                                        
                    //Cargo Rol de Usuario
                    RolUsuario Rol = new RolUsuario(  Convert.ToInt32( PrimerCelda["ID_rol"] ),
                                                      (string)PrimerCelda["nombre_rol"],
                                                      null
                                                   );

                    //Cargo Permisos para el Rol
                    List<Permiso> Permisos = new List<Permiso>();
                    foreach (DataRow aux in dtUsuario.Rows)
                    {
                        Permiso p = new Permiso(  (string)aux["nombre_permiso"],
                                                  (string)aux["href"]
                                               );
                        Permisos.Add(p);
                    }

                    //Cargo la institucion educativa
                    BD_Institucion Instituciones = BD_Institucion.Instance();

                    int id_institucion = Convert.ToInt32(PrimerCelda["ID_institucion"]);
                    InstitucionEducativa Institucion = Instituciones.Buscar_por_ID(id_institucion);
                   
                    //Cargo los objetos al Usuario
                    Rol.Permisos = Permisos;
                    oUsuario.RolUsuario = Rol;
                    oUsuario.InstitucionEducativa = Institucion;

                    return oUsuario;

                }
                else
                    throw new Exception("No se encontro el usuario");

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Usuario Validar_Usuario(string p_IdUsuario, string p_Contraseña)
        {
            throw new NotImplementedException();
        }

        public Usuario Buscar_por_Usuario(string usuario)
        {
            try
            {
                string cmd = @"SELECT U.ID_usuario, U.usuario, U.password, R.Nombre as NombreRol
	                                FROM dbo.Usuarios AS U
                                        LEFT JOIN dbo.RolUsuarios AS R
                                             ON R.ID_rol = U.ID_rol
                                                 WHERE(U.usuario='" + usuario + "')";

                DataTable dtUsuario = Conexion_BD.CargarDatos(cmd);
                if (dtUsuario.Rows.Count > 0)
                {
                    DataRow PrimerCelda = dtUsuario.Rows[0];

                    //Cargo datos del Usuario
                    Usuario oUsuario = new Usuario( Convert.ToInt32( PrimerCelda["ID_usuario"] ),
                                                             (string)PrimerCelda["usuario"],
                                                             (string)PrimerCelda["password"]
                                                  );

                    RolUsuario rol = new RolUsuario((string)PrimerCelda["NombreRol"]);
                    oUsuario.RolUsuario = rol;

                    return oUsuario;
                }
                else
                    throw new Exception("No se encontro el usuario");
            }
            catch (SqlException ex)
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
