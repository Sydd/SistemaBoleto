using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Controladora;
using Modelo;

namespace masterpage
{
    public abstract class AbtractWebForm : System.Web.UI.Page
    {
        Co_Gestion_Usuario oCo_Usuarios = new Co_Gestion_Usuario();

        internal void Page_Load()
        {
            //Valido Acceso
            if (Session["usr"] == null)
            {
                Server.Transfer("login.aspx");
            }
            else
            {
                string paginaActual = System.IO.Path.GetFileName(Request.PhysicalPath);

                if (!oCo_Usuarios.Comprobar_Permiso_Acceso((Usuario)Session["usr"], paginaActual))
                    Server.Transfer("acceso_denegado.aspx");
            }
        }
    }
}