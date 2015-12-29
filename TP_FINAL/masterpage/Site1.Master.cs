using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controladora;

namespace masterpage
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Co_Gestion_Usuario oCoUsuarios = new Co_Gestion_Usuario();
        Co_Permisos oCoPermisos = new Co_Permisos();
        Co_RolUsuario oCoRolUsuario = new Co_RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usr"] != null)
            {
                //cargo datos propios del usuario logueado
                Usuario oUsuario = (Usuario)Session["usr"];
                lblUsuario.InnerText = oUsuario.IdUsuario;
                Herramientas.Cargar_Menu(oUsuario.RolUsuario, PlaceMenu);
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["usr"] = null;
            Response.Redirect("login.aspx", false);
        }

        protected void modal_Aceptar_ServerClick(object sender, EventArgs e)
        {
            modal_mensaje.InnerText = "";
            dialogo_modal.Attributes["style"] = "visibility: hidden;";
        }

        public void Limpiar_Modal()
        {
            dialogo_modal.Attributes["style"] = "visibility: hidden;";
            modal_mensaje.InnerText = "";
            modal_aceptar.Style.Add("display", "none");
        }

        public void Lanzar_Modal_info(string mensaje)
        {
            dialogo_modal.Attributes["style"] = "visibility: visible;";
            modal_mensaje.InnerText = mensaje;
            modal_aceptar.Style.Add("display", "block");
        }   


    }
}