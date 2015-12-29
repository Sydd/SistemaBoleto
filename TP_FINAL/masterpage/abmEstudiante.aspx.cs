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
    public partial class abmEstudiantes : System.Web.UI.Page, IPostBackEventHandler
    {
        Co_Gestion_Usuario usuarios = new Co_Gestion_Usuario();
        Co_Gestion_Estudiantes estudiantes = new Co_Gestion_Estudiantes();

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

                if (!usuarios.Comprobar_Permiso_Acceso((Usuario)Session["usr"], paginaActual))
                    Server.Transfer("acceso_denegado.aspx");
            }
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "agregar":
                    Agregar();
                    break;
                case "modificar":
                    Modificar();
                    break;
                case "eliminar":
                    Eliminar();
                    break;
                default:
                    break;
            }
        }

        protected void Modificar()
        {
            try
            {
                Estudiante est = estudiantes.Buscar_por_dni(txtDni.Value);

                est.Id = Convert.ToInt32( txtID.Text );
                est.Mail = txtMail.Value;
                est.Nombre = txtNombre.Value;
                //apellido = no esta
                est.Telefono = txtTelefono.Value;

                estudiantes.Modificar(est);

                Limpiar_Form();
                ((Site1)this.Master).Lanzar_Modal_info("Estudiante Modificado!");
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
            }



        }

        protected void Eliminar()
        {
            try
            {
                estudiantes.Remover( Convert.ToInt32( txtID.Text ) );
                Limpiar_Form();
                ((Site1)this.Master).Lanzar_Modal_info("Estudiante Eliminado!");
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
            } 
        }

        protected void Agregar()
        {
            try
            {
                //traigo el usuario de la session para tener la institucion
                Usuario usuario = (Usuario)Session["usr"];

                //el nombre de usuario del estudiante es el mail, la contraseña se tiene que generar al activarlo
                estudiantes.Agregar(txtMail.Value, txtDni.Value, txtNombre.Value, txtTelefono.Value, usuario.InstitucionEducativa);
                Limpiar_Form();

            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
            }
        }


        //filtra la grilla por el dni
        protected void btnBuscarDni_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usr"];
                
                List<Estudiante> ListaFiltrada = estudiantes.Devolve_por_Institucion(usuario.InstitucionEducativa)
                                                       .Where( x => x.Dni.Contains( txtDni.Value) ).ToList();

                GrdEstudiante.DataSource = "";
                GrdEstudiante.DataSource = ListaFiltrada;
                GrdEstudiante.DataBind();

                Estudiante estudiante = estudiantes.Buscar_por_dni(txtDni.Value);

                txtApellido.Value = estudiante.Nombre;
                txtNombre.Value = estudiante.Nombre;
                txtID.Text = estudiante.Id.ToString();
                txtMail.Value = estudiante.Mail;
                txtTelefono.Value = estudiante.Telefono;
            
                
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
            
        }

        protected void btnGrid_ServerClick(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usr"];
            GrdEstudiante.DataSource = "";
            //List<Estudiante> gg = estudiantes.Devolve_por_Institucion(usuario.InstitucionEducativa);
            GrdEstudiante.DataSource = estudiantes.Devolve_por_Institucion(usuario.InstitucionEducativa);
            GrdEstudiante.DataBind();
        }

        protected void Limpiar_Form()
        {
            txtDni.Value = "";
            txtMail.Value = "";
            txtNombre.Value = "";
            txtApellido.Value = "";
            txtTelefono.Value = "";
        }
        
    }


}