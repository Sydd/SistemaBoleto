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
    public partial class ActivarEstudiante : System.Web.UI.Page, IPostBackEventHandler
    {
        Co_Gestion_Usuario oCo_Usuarios = new Co_Gestion_Usuario();
        Co_Gestion_Estudiantes Estudiantes = new Co_Gestion_Estudiantes();

        Estudiante oEstudiante = new Estudiante();

        protected void Page_Load(object sender, EventArgs e)
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

            Master.Limpiar_Modal();

            //genero el check de "Activo"
            Herramientas.Generar_Check(1, "Activo", true, PlaceCheckActivo);        
            
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "modificar":
                    Modificar();
                    break;
                default:
                    break;
            }
        }

        protected void Modificar()
        {
            oEstudiante = Estudiantes.Buscar_por_dni(txtDni.Value);
            Estudiantes.ActivarEstudiante(oEstudiante, Herramientas.IsChecked(PlaceCheckActivo));
            Limpiar_Form();
            ((Site1)this.Master).Lanzar_Modal_info("Datos modificados!");
        }

        protected void btnBuscarDni_ServerClick(object sender, EventArgs e)
        {
            try
            {
                oEstudiante = Estudiantes.Buscar_por_dni(txtDni.Value);

                txtNombre.Value = oEstudiante.Nombre;
                txtMail.Value = oEstudiante.Mail;
                txtTelefono.Value = oEstudiante.Telefono;

                if (oEstudiante.Activo)
                    Herramientas.Check(1, true, PlaceCheckActivo); 
            }
            catch (Exception ex)
            {
                Limpiar_Form();
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
           
        }

        protected void Limpiar_Form()
        {
            txtDni.Value = "";
            txtApellido.Value = "";
            txtMail.Value = "";
            txtNombre.Value = "";
            txtTelefono.Value = "";
            Herramientas.Check(1, false, PlaceCheckActivo);

        }
    }
}