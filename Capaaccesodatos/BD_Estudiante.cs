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
    public class BD_Estudiante : CapaDatoAbstractaSingleton<BD_Estudiante>,I_CapaDatos<Estudiante>
    {

        public void Agregar(Estudiante dato)
        {
        	 try
            {
                Usuario usuario = new Usuario(dato.Nombre, dato.IdUsuario, "", dato.Dni, dato.Telefono, dato.Mail, dato.RolUsuario, dato.InstitucionEducativa);
                int _ID = BD_Usuarios.Instance().AgregarEscalado(usuario);
                string cmd = "insert into Estudiantes VALUES (" + _ID + ",'" +
                                                               dato.Fecha_Alta + "','" +
                                                               dato.Qr + "'," + 
                                                               Convert.ToInt32( dato.Activo )+ ")";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

	   	public void Modificar(Estudiante dato)
        {
            try
            {
                string cmd = @"UPDATE Usuarios
                                  SET
                                    ID_institucion = " + dato.InstitucionEducativa.Id + 
                                    ",nombre = '" + dato.Nombre +           
                                    "',dni =" + dato.Dni + 
                                    ",mail = '" + dato.Mail +
                                    "',telefono = " + dato.Telefono +
                                    ", password = '" + dato.Contraseña +
                                    "',usuario = '" + dato.IdUsuario +
                                            "' WHERE ID_usuario = " + dato.Id;

                                Conexion_BD.EjecutarSql(cmd);   

                cmd =        @"UPDATE Estudiantes
                                SET
                                fechadealta = '" + dato.Fecha_Alta + 
                                "',qr = '" + dato.Qr +
                                "',activo = " + Convert.ToInt32(dato.Activo) +
                                " WHERE ID_usuario = " + dato.Id;

                                Conexion_BD.EjecutarSql(cmd);    
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(Estudiante dato)
        {
	       try
            {
                string cmd = "delete from Usuarios where(ID_usuario = " + dato.Id + ")";
                Conexion_BD.EjecutarSql(cmd);
            }
           catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Activar (Estudiante dato)
        {
        	try
            {
                string cmd = "UPDATE Estudiantes SET activo=1  WHERE ID_usuario = " + dato.Id ;                
                Conexion_BD.EjecutarSql(cmd);
                cmd = "UPDATE Usuarios SET password = "+ dato.Contraseña +"  WHERE ID_usuario =  "+ dato.Id ;
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Desactivar (Estudiante dato)
        {
        	try
            {
                string cmd = "UPDATE Estudiantes SET activo=0 WHERE ID_usuario = " + dato.Id;                
                Conexion_BD.EjecutarSql(cmd);       
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Estudiante Buscar_por_dni(string dni)
        {
            try
            {
                string cmd =    @"SELECT U.*,E.fechadealta,E.qr,E.activo,I.nombre as institucion,I.direccion,I.telefono as telefonoinstitucion 
                                    FROM Estudiantes E
                                    INNER JOIN Usuarios U
                                    ON U.ID_usuario = E.ID_usuario
                                    INNER JOIN Instituciones I
                                    ON I.ID_institucion = U.ID_institucion
                                    WHERE dni = " + dni;


                DataTable dtEstuadiante = Conexion_BD.CargarDatos(cmd);
                Estudiante oEstudiante = null;

                if (dtEstuadiante.Rows.Count > 0)
                {
                    DataRow aux = dtEstuadiante.Rows[0];
                    // Por ahora la lista de niveles va a quedar en null, trae el usuario con una institucion sin niveles.

                    InstitucionEducativa insti = new InstitucionEducativa(
                                                                    (string)aux["institucion"], 
                                                                    (string)aux["direccion"],
                                                           Convert.ToString(aux["telefonoinstitucion"]),
                                                                                 null, 
                                                            Convert.ToInt32(aux["ID_institucion"]));


                    oEstudiante = new Estudiante(
                                            Convert.ToInt32(aux["ID_usuario"]),
                                                    (string)aux["usuario"],
                                          Convert.ToString((aux["dni"])),
                                                    (string)aux["password"],
                                                    (string)aux["nombre"],
                                                    (string)aux["mail"],
                                           Convert.ToString(aux["telefono"]),
                                                    (string)aux["qr"],
                                         Convert.ToDateTime(aux["fechadealta"]),
                                         Convert.ToBoolean( aux["activo"] ), 
                                                                 null,
                                                                 insti );

                }
                else
                {
                    throw new Exception("No se encontro el alumno especificado");
                }
            return oEstudiante;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Estudiante Buscar_por_ID(int Id)
        {
            try
            {
                string cmd =    @"SELECT U.*,E.fechadealta,E.qr,E.activo,I.nombre as institucion,I.direccion,I.telefono as telefonoinstitucion 
                                    FROM Estudiantes E
                                    INNER JOIN Usuarios U
                                    ON U.ID_usuario = E.ID_usuario
                                    INNER JOIN Instituciones I
                                    ON I.ID_institucion = U.ID_institucion
                                    WHERE U.ID_Usuario = " + Id;
                DataTable dtEstuadiante = Conexion_BD.CargarDatos(cmd);
                Estudiante oEstudiante = null;
                if (dtEstuadiante.Rows.Count > 0)
                {
                    DataRow aux = dtEstuadiante.Rows[0];
                    // Por ahora la lista de niveles va a quedar en null, trae el usuario con una institucion sin niveles.
                    InstitucionEducativa insti = new InstitucionEducativa(
                                            (string)aux["institucion"], 
                                            (string)aux["direccion"],
                                            Convert.ToString(aux["telefonoinstitucion"]),
                                            null, 
                                            Convert.ToInt32(aux["ID_institucion"]));

                    oEstudiante = new Estudiante(
                                            Convert.ToInt32(aux["ID_usuario"]),
                                            (string)aux["usuario"],
                                            Convert.ToString((aux["dni"])),
                                            (string)aux["password"],
                                            (string)aux["nombre"],
                                            (string)aux["mail"],
                                            Convert.ToString(aux["telefono"]),
                                            (string)aux["qr"],
                                            Convert.ToDateTime(aux["fechadealta"]),
                                            Convert.ToBoolean( aux["activo"] ), 
                                            null,
                                            insti );

                    //Le asigno el rol
                    RolUsuario rol = new RolUsuario();
                    rol.Id = Convert.ToInt32(aux["ID_rol"]);

               
                    //Cargo Permisos para el Rol
                    string cmd2 = @"SELECT P.nombre AS nombre_permiso, P.href
                                        FROM RolxPermisos RP
                                        JOIN Permisos P
                                            ON P.ID_permiso = RP.ID_permiso
                                        WHERE (RP.ID_rol =" + rol.Id +")";
                    DataTable dtPermisos = Conexion_BD.CargarDatos(cmd2);
         
                    List<Permiso> permisos = new List<Permiso>();
                    foreach (DataRow aux2 in dtPermisos.Rows)
                    {
                        Permiso p = new Permiso((string)aux2["nombre_permiso"],
                                                  (string)aux2["href"]
                                               );
                        permisos.Add(p);
                    }

                    rol.Permisos = permisos;
                    oEstudiante.RolUsuario = rol;
                    
                }
                else
                {
                    throw new Exception("No se encontro el alumno especificado");
                }
            return oEstudiante;
            }
            catch (SqlException ex)
            {
                throw ex;
            }        }

        public List<Estudiante> Devolver_por_Institucion(InstitucionEducativa insti)
        {
        	try
        	{
        		List<Estudiante> listaEstudiantes = new List<Estudiante>();
                string cmd = @" SELECT U.ID_usuario,U.nombre,U.dni,U.mail,U.telefono,U.password,U.usuario,E.fechadealta,E.qr,E.activo 
								    FROM Usuarios U
								        INNER JOIN Estudiantes E
								            ON U.ID_usuario = E.ID_usuario
								               WHERE U.ID_institucion = " + insti.Id
                                                    + "   ORDER BY U.ID_usuario";


			    DataTable dtEstudiantes = Conexion_BD.CargarDatos(cmd);
				if (dtEstudiantes.Rows.Count > 0)
				{
					foreach (DataRow aux in dtEstudiantes.Rows)
					{

						Estudiante oEstudiante = new Estudiante(Convert.ToInt32(aux["ID_usuario"]),
                                                                        (string)aux["usuario"],
                                                                       Convert.ToString((aux["dni"])),
																		(string)aux["password"],
                                                                        (string)aux["nombre"],
                                                                        (string)aux["mail"],
																	     Convert.ToString(aux["telefono"]),
                                                                        (string)aux["qr"],
                                                                        Convert.ToDateTime(aux["fechadealta"]),
																		Convert.ToBoolean( aux["activo"] ), 
                                                                                    null, 
                                                                                    insti ) ;

                       
						listaEstudiantes.Add(oEstudiante);
					}
				}
				else
				{
					throw new Exception ("No hay estudiantes en esa Institucion.");
				}
				return listaEstudiantes;
        	}
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Estudiante> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
