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
    public partial class abmInstituciones : System.Web.UI.Page, IPostBackEventHandler, I_CustomWebForm
    {

        Co_Gestion_Instituciones oCo_Instituciones = new Co_Gestion_Instituciones();
        Co_Niveles_Educativos oCo_Niveles_Educaticos = new Co_Niveles_Educativos();
        Co_Gestion_Usuario oCo_Usuario = new Co_Gestion_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //Valido Acceso
                if (Session["usr"] == null)
                {
                    Server.Transfer("login.aspx");
                }
                else
                {
                    string paginaActual = System.IO.Path.GetFileName(Request.PhysicalPath);

                    if (!oCo_Usuario.Comprobar_Permiso_Acceso((Usuario)Session["usr"], paginaActual))
                        Response.Redirect("acceso_denegado.aspx", false);

                }
            }

            try
            {
                //Cargo Checks de Niveles Educativos
                foreach (NivelEducativo Nivel in oCo_Niveles_Educaticos.TraerTodo())
                {
                    Herramientas.Generar_Check(Nivel.Id, Nivel.Nivel, false, PlaceChecksNiveles); //la clase herramientas esta dentro de este directorio.
                }
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
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
                    Remover();
                    break;
                default:
                    break;
            }
        }

        protected void btnGrid_ServerClick(object sender, EventArgs e)
        {
            //cargo grid
            Grid.DataSource = "";
            Grid.DataSource = oCo_Instituciones.TraerTodos();
            Grid.DataBind();
        }

        public void Agregar()
        {
            try
            {
                //Traigo Ids de Checks elegidos            
                List<int> ChecksElegidos = new List<int>();
                ChecksElegidos = Herramientas.Ids_Checks_Seleccionados(PlaceChecksNiveles); //PlaceCheckNiveles niveles es el el Placeholder donde estan los checks

                oCo_Instituciones.Nueva(txtNombre.Value,
                                        txtDireccion.Value,
                                        txtTelefono.Value,
                                        oCo_Instituciones.Niveles_Elegidos(ChecksElegidos)
                                        );

                txtNombre.Value = "";
                txtDireccion.Value = "";
                txtTelefono.Value = "";
            }
            catch (Exception ex)
            {
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
            }
        }

        public void Remover()
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }

        public void Limpiar_Form()
        {
            throw new NotImplementedException();
        }

        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //filtra los datos de la grilla, es solo para mejorar el uso, no cumple funcion.
                List<InstitucionEducativa> ListaFiltrada = oCo_Instituciones.TraerTodos()
                        .Where(u => u.Nombre.Contains(txtNombre.Value)).ToList();

                Grid.DataSource = "";
                Grid.DataSource = ListaFiltrada;
                Grid.DataBind();

            }
            catch (Exception ex)
            {

                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }

        }
    }
}