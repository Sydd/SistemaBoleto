using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System;

namespace Capaaccesodatos
{
    public static class FTP_conexion
    {
        public static string  Guardar(Stream QR,string nombre)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://micros.somee.com//www.micros.somee.com//qr//" + nombre );
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("sydd", "lugormod32@");

                StreamReader lector = new StreamReader(QR);
                byte [] archivo = Encoding.UTF8.GetBytes(lector.ReadToEnd());
                lector.Close();
                request.ContentLength = archivo.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(archivo, 0, archivo.Length);
                requestStream.Close();

                FtpWebResponse respuesta = (FtpWebResponse)request.GetResponse();
                return respuesta.StatusDescription;
            }
            catch (Exception err)
            {
                throw err;
            }

     
        }
    }

}
