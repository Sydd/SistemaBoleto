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
    public partial class abmTransUrbano : System.Web.UI.Page, IPostBackEventHandler
    {
        Co_Gestion_Usuario usuarios = new Co_Gestion_Usuario();
        Co_Gestion_Transportesurbanos transportes = new Co_Gestion_Transportesurbanos();

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

        public void Agregar()
        {
            try
            {
                transportes.Agregar(Convert.ToInt32(txtLinea.Value), txtDescripcion.Value);
                Limpiar();
            }
            catch (Exception ex)
            {
                
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message + "    SEGUIMIENTO>>>" + ex.StackTrace);
            }
        }

        public void Modificar()
        {
            try
            {
                TransporteUrbano transporte = new TransporteUrbano( Convert.ToInt32( txtID.Text ) , Convert.ToInt32( txtLinea.Value ), txtDescripcion.Value);

                transportes.Modificar(transporte);
                Limpiar();
            }
            catch (Exception ex)
            {
                
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
        }

        public void Remover()
        {
            try
            {
                transportes.Remover(Convert.ToInt32(txtID.Text));
                Limpiar();
            }
            catch (Exception ex)
            {

                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
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

        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                TransporteUrbano transporte = transportes.Buscar_por_Linea(Convert.ToInt32(txtLinea.Value));
                txtDescripcion.Value = transporte.Descripcion;
                txtID.Text = transporte.Id.ToString();
            }
            catch (Exception ex)
            {
                
                ((Site1)this.Master).Lanzar_Modal_info(ex.Message);
            }
        }

        protected void btnGrid_ServerClick(object sender, EventArgs e)
        {
           
            Grid.DataSource = "";
            Grid.DataSource = transportes.TraerTodos();
            Grid.DataBind();
        }

        protected void Limpiar()
        {
            txtLinea.Value = "";
            txtDescripcion.Value = "";
            txtID.Text = "";
        }
    }
}