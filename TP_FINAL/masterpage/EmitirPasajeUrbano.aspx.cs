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
    public partial class EmitirPasajeUrbano : System.Web.UI.Page
    {
        Co_Gestion_Estudiantes Estudiantes = new Co_Gestion_Estudiantes();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBDNI_ServerClick(object sender, EventArgs e)
        {
            txtNombre.Value = "hola";
        }


    }
}