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
    public class BD_PasajesUrbanos : CapaDatoAbstractaSingleton< BD_PasajesUrbanos>,I_CapaDatos<PasajeUrbano>
    {

        public void Agregar(PasajeUrbano dato)
        {

            try
            {
                string cmd = @"insert into PasajesUrbanos VALUES (" + dato.Estudiante.Id + "," +
                                                               dato.TransporteUrbano.Id + "," +
                                                               "getdate()" + "," +
                                                               dato.NroInterno + ")";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Modificar(PasajeUrbano dato)
        {
            try
            {
                string cmd = @"update  PasajesUrbanos 
                            set ID_usuario =" + dato.Estudiante.Id +
                            ",ID_transporteurbano = " + dato.TransporteUrbano.Id +
                            ",fecha = '" + dato.FechaPasaje +
                            "',nmrointerno =" + dato.NroInterno + 
                            ",autenticacion=" + dato.Autenticacion;
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        public PasajeUrbano Buscar_por_ID(int Id)
        {
            try
            {
  
                string cmd = @"SELECT P.fecha as 'fechaemitido',P.nmrointerno,P.autenticacion,U.ID_usuario,U.nombre,T.ID_transporteurbano,T.linea,T.descripcion
                               FROM PasajesUrbanos P
                               INNER JOIN Usuarios U
                               ON P.ID_usuario =  U.ID_usuario
                               INNER JOIN TransportesUrbanos T
                               ON P.ID_transporteurbano = T.ID_transporteurbano
                               WHERE(P.ID_pasajeurbano=" + Id + ")";

                DataTable dtP = Conexion_BD.CargarDatos(cmd);
                if (dtP.Rows.Count > 0)
                {
                    DataRow primercelda = dtP.Rows[0];
                    PasajeUrbano opasaje = new PasajeUrbano(
                        Id,
                        Convert.ToDateTime(primercelda["fechaemitido"]),
                        Convert.ToInt32(primercelda["nmrointerno"]),
                        Convert.ToInt32(primercelda["autenticacion"]),
                        new TransporteUrbano(Convert.ToInt32(primercelda["ID_transporteurbano"]),
                                            Convert.ToInt32(primercelda["linea"]),
                                            (string)primercelda["descripcion"]),
                        new Estudiante(Convert.ToInt32(primercelda["ID_usuario"]),
                                            (string)primercelda["nmrointerno"],
                                            null));

                    return opasaje;
                }
                else
                    throw new Exception("No se encontro el pasaje especificado");

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Remover(PasajeUrbano dato)
        {
            try
            {
                string cmd = "delete from PasajesUrbanos where(ID_pasajeurbano = " + dato.Id + ")";
                Conexion_BD.EjecutarSql(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public List<PasajeUrbano> TraerTodos()
        {
            try
            {
  
                string cmd = @"SELECT P.fecha as 'fechaemitido',P.ID_pasajeurbano,P.nmrointerno,P.autenticacion,U.ID_usuario,U.nombre,T.ID_transporteurbano,T.linea,T.descripcion
                               FROM PasajesUrbanos P
                               INNER JOIN Usuarios U
                               ON P.ID_usuario =  U.ID_usuario
                               INNER JOIN TransportesUrbanos T
                               ON P.ID_transporteurbano = T.ID_transporteurbano";

                DataTable dtP = Conexion_BD.CargarDatos(cmd);
                List<PasajeUrbano> oLista = new List<PasajeUrbano>();
                foreach(DataRow primercelda in dtP.Rows)
                {
                    PasajeUrbano opasaje = new PasajeUrbano(
                    Convert.ToInt32(primercelda["ID_pasajeurbano"]),
                    Convert.ToDateTime(primercelda["fechaemitido"]),
                    Convert.ToInt32(primercelda["nmrointerno"]),
                    Convert.ToInt32(primercelda["autenticacion"]),
                    new TransporteUrbano(Convert.ToInt32(primercelda["ID_transporteurbano"]),
                                        Convert.ToInt32(primercelda["linea"]),
                                        (string)primercelda["descripcion"]),
                    new Estudiante(Convert.ToInt32(primercelda["ID_usuario"]),
                                        (string)primercelda["nmrointerno"],
                                        null));
                    oLista.Add(opasaje);
                }
                return oLista;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<PasajeUrbano> TraerTodos_por_Estudiante(Estudiante dato)
        {
            try
            {

                string cmd = @"SELECT P.fecha as 'fechaemitido',P.ID_pasajeurbano,P.nmrointerno,U.ID_usuario,U.nombre,T.ID_transporteurbano,T.linea,T.descripcion
                               FROM PasajesUrbanos P
                               INNER JOIN Usuarios U
                               ON P.ID_usuario =  U.ID_usuario
                               INNER JOIN TransportesUrbanos T
                               ON P.ID_transporteurbano = T.ID_transporteurbano
                                   WHERE ( P.ID_usuario = " + dato.Id + ")";
                                

                DataTable dtP = Conexion_BD.CargarDatos(cmd);
                List<PasajeUrbano> oLista = new List<PasajeUrbano>();
                foreach (DataRow primercelda in dtP.Rows)
                {


                    PasajeUrbano opasaje = new PasajeUrbano(
                    Convert.ToInt32(primercelda["ID_pasajeurbano"]),
                    Convert.ToDateTime(primercelda["fechaemitido"]),
                    Convert.ToInt32(primercelda["nmrointerno"]),
                    Convert.ToInt32(primercelda["ID_usuario"]),
                    new TransporteUrbano(Convert.ToInt32(primercelda["ID_transporteurbano"]),
                                        Convert.ToInt32(primercelda["linea"]),
                                        (string)primercelda["descripcion"]),
                    new Estudiante(Convert.ToInt32(primercelda["ID_usuario"]),
                                        (string)primercelda["nombre"],
                                        null));

                   

                    oLista.Add(opasaje);
                }
                return oLista;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}