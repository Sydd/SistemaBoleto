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
    public partial class abmUsuarios : System.Web.UI.Page, IPostBackEventHandler
    {

        Co_Gestion_Instituciones instituciones = new Co_Gestion_Instituciones();
        Co_RolUsuario Roles = new Co_RolUsuario();
        Co_Gestion_Usuario usuarios = new Co_Gestion_Usuario();
        Co_Permisos oCo_Permisos = new Co_Permisos();

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

                try
                {
                         
                    //Cargo DropDown Rol
                    DropRolUsuario.DataSource = null;
                    DropRolUsuario.DataSource = Roles.TraerTodos();
                    DropRolUsuario.DataTextField = "Nombre";
                    DropRolUsuario.DataValueField = "Id";
                    DropRolUsuario.DataBind();
                    DropRolUsuario.Items.Insert(0, new ListItem("", "-1"));

                    //Cargo DropDown Institucion
                    DropDownInstitucion.DataSource = null;
                    DropDownInstitucion.DataSource = instituciones.TraerTodos();
                    DropDownInstitucion.DataTextField = "Nombre";
                    DropDownInstitucion.DataValueField = "Id";
                    DropDownInstitucion.DataBind();
                    DropDownInstitucion.Items.Insert(0, new ListItem("", "-1"));

                }

                

                catch (Exception ex)
                {
                    ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
                }
            }
            Herramientas.Generar_Check(1, "Pertenece a Institucion Educativa", true, PlaceInstitucion);
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

        protected void Agregar()
        {          
            try
            {
                
                //si es pertenece a una institucion, carga la seleccionada, sino le asigna id 0
                InstitucionEducativa institucion = new InstitucionEducativa();
                //if (Herramientas.IsChecked(PlaceInstitucion))
                //{
                    institucion = instituciones.Buscar_por_ID(Convert.ToInt32(DropDownInstitucion.SelectedValue));
                //}
                //else
                //{
                //    institucion.Id = 0;
                //}

         
                usuarios.Agregar(txtNombre.Value,
                                 txtUsuario.Value,
                                 txtContraseña.Value,
                                 txtDni.Value,
                                 txtTelefono.Value,
                                 txtMail.Value,
                                 Roles.Buscar_por_ID( Convert.ToInt32( DropRolUsuario.SelectedValue )),
                                 institucion
                                 );
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
            }
        }

        protected void Modificar()
        {
            try
            {

                InstitucionEducativa institucion = new InstitucionEducativa();
                if ( Herramientas.IsChecked(PlaceInstitucion) )
                { 
                    institucion.Id = Convert.ToInt32(DropDownInstitucion.SelectedValue);
                }
                else
                {
                    institucion = null;
                }

                RolUsuario rol = new RolUsuario();
                rol.Id = Convert.ToInt32( DropRolUsuario.SelectedValue );


                usuarios.Modificar(Convert.ToInt32(txtID.Text),
                       txtUsuario.Value,
                       txtNombre.Value,
                       txtContraseña.Value,
                       txtDni.Value,
                       txtTelefono.Value, 
                       txtMail.Value,
                       rol,
                       institucion ); // cambiar despues por el dropdown
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }

        }

        protected void Eliminar()
        {
            try
            {
                usuarios.Remover( Convert.ToInt32(txtID.Text.Trim()), txtUsuario.Value);
            }
            catch (Exception ex)
            {            
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnGrid_ServerClick(object sender, EventArgs e)
        {
            Grid.DataSource = "";
            Grid.DataSource = usuarios.Traer_todo();
            Grid.DataBind();
        }

        protected void btnBuscarUsuario_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //filtra los datos de la grilla, es solo para mejorar el uso, no cumple funcion.
                List<Usuario> ListaFiltrada = usuarios.Traer_todo()
                        .Where(u => u.IdUsuario.Contains(txtUsuario.Value)).ToList();

                Grid.DataSource = "";
                Grid.DataSource = ListaFiltrada;
                Grid.DataBind();

                //traigo datos del usuario buscado
                Usuario usuario = usuarios.Buscar_por_Nombre(txtUsuario.Value);

                

                if (usuario.InstitucionEducativa != null)
                {
                    Herramientas.Check(PlaceInstitucion);
                    DropDownInstitucion.Enabled = true;
                    DropDownInstitucion.SelectedValue = Convert.ToString(usuario.InstitucionEducativa.Id);
                }

                DropRolUsuario.SelectedValue = Convert.ToString( usuario.RolUsuario.Id );  //cambiar cuando este DB_Roles

                txtID.Text          = usuario.Id.ToString();
                txtDni.Value        = usuario.Dni;
                txtMail.Value       = usuario.Mail;
                txtContraseña.Value = usuario.Contraseña;
                txtNombre.Value     = usuario.Nombre;
                txtTelefono.Value   = usuario.Telefono;
              
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
        }


    }
}