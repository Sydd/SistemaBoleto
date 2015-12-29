using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Modelo;

namespace masterpage
{
    public partial class ConsultarPasajesUrbanos : System.Web.UI.Page
    {
        Co_Gestion_Usuario usuarios = new Co_Gestion_Usuario();
        CO_PasajesUrbanos pasajes = new CO_PasajesUrbanos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Valido Acceso
                if (Session["usr"] == null)
                {
                    Server.Transfer("login.aspx");
                }
                else
                {
                    string paginaActual = System.IO.Path.GetFileName(Request.PhysicalPath);

                    if (!usuarios.Comprobar_Permiso_Acceso((Usuario)Session["usr"], paginaActual))
                        Server.Transfer("acceso_denegado.aspx");
                }
            }
        }

        protected void btnGrid_ServerClick(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usr"];
            Estudiante estudiante = new Estudiante();
            estudiante.Id = user.Id;
            

            Grid.DataSource = "";
            Grid.DataSource = pasajes.TraerTodos_por_Estudiante(estudiante);
            Grid.DataBind();
        }
    }
}