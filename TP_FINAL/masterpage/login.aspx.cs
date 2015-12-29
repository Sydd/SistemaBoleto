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
    public partial class login : System.Web.UI.Page, IPostBackEventHandler
    {


        Co_Gestion_Usuario oCoUsuarios = new Co_Gestion_Usuario();
        Co_RolUsuario oCoRol = new Co_RolUsuario();
        Co_Permisos oCoPermisos = new Co_Permisos();
        Co_Niveles_Educativos oCoNivelesEducativos = new Co_Niveles_Educativos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //el usuario no se logueo
                Session["usr"] = null;
            }

          

            Master.Page.ClientScript.RegisterStartupScript
               (this.GetType(), "modal", "lanzar_modal_info('hola');", true);
        }

        protected void Loguear()
        {
            try
            {
                //valido el usuario, si es invalido salta a la Exeption
                Usuario oUsuario = oCoUsuarios.Validar_Usuario(txtUsuario.Value.ToString(), txtContraseña.Value.ToString());

                //es valido entonces cargo la sesion
                Session["usr"] = (Usuario)oUsuario;
                Response.Redirect("Bienvenido.aspx", false);

            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
        }

        //este methodo atrapa la llamada desde javascript
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "login")
            {
                Loguear();
            }
            
        }
    }
}