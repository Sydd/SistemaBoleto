using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capaaccesodatos;
using Capa_de_Datos;
using Modelo;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.IO;


namespace Controladora
{
    public class Co_Gestion_Estudiantes
    {
        BD_Estudiante estudiantes = BD_Estudiante.Instance();
         

        //Lista_Estudiante ListaEstudiantes = Lista_Estudiante.Instance();
       // Co_Gestion_Estudiantes Controladora_Estudiantes = new Co_Gestion_Estudiantes();

        public void Agregar(string mail, string dni, string nombre, string telefono, InstitucionEducativa institucion)
        {
            Estudiante oEstudiante = new Estudiante(mail, dni, dni, nombre, mail, telefono, "", DateTime.Today , false,  BD_Roles.Instance().Buscar_por_Nombre("estudiante"), institucion);
            estudiantes.Agregar(oEstudiante);
        }

        public void Remover(int id)
        {
            Estudiante estudiante = new Estudiante();
            estudiante.Id = id;

            estudiantes.Remover(estudiante);
        }

        public void Modificar(Estudiante dato)
        {
            estudiantes.Modificar(dato);
        }

        public List<Estudiante> Devolve_por_Institucion(InstitucionEducativa institucion)
        {
            return estudiantes.Devolver_por_Institucion(institucion);
        }

        public Estudiante Buscar_por_ID(int id)
         {
             return estudiantes.Buscar_por_ID(id);
         }

        public Estudiante Buscar_por_dni(string dni) 
         {
             return estudiantes.Buscar_por_dni(dni);
         }

        public List<Estudiante> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void EliminarEstudiante(string _oEstudiante)
         {
             throw new NotImplementedException();
         }


        /// <summary>
        /// Activa o lo desactiva si se indica el segundo parametro.
        /// </summary>
        /// <param name="estudiante"></param>
        /// <param name="desactivar"></param>
        public void ActivarEstudiante(Estudiante estudiante, bool activar)
        {
            if (activar)
	        {

                //Le genero una contraseña si es la primera ves que se activa
                if (estudiante.Contraseña == "")
	            {
                    Random rnd = new Random();
                    estudiante.Contraseña = Convert.ToString( rnd.Next(0, 999999) );
	            } 


                //genero su codigo QR
                string cadena = estudiante.Dni.Trim() + estudiante.Contraseña.Trim();
                QRCodeEncoder enc = new QRCodeEncoder();
                Bitmap qrcode = enc.Encode(cadena);
                qrcode.Save("C:\\NVIDIA\\" + estudiante.Dni + ".png", ImageFormat.Png);
                
               
                estudiantes.Activar(estudiante); 
	        }
            else
	        {
                estudiantes.Desactivar(estudiante);
	        }           
        }

    }
}
