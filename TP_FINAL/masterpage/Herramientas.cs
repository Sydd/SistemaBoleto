using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Modelo;

namespace masterpage
{
    public static class Herramientas
    {

        /// <summary>
        /// Carga el Menu lateral, con cada Permiso en el Rol
        /// </summary>
        /// <param name="pRol"></param>
        /// <param name="pEnDonde"></param>
        public static void Cargar_Menu(RolUsuario pRol, PlaceHolder pEnDonde)
        {
            foreach (Permiso permiso in pRol.Permisos)
            {
                HtmlGenericControl oItemMenu = new HtmlGenericControl("a");
                oItemMenu.Attributes["class"] = "mdl-navigation__link";
                oItemMenu.Attributes["href"] = permiso.Href;
                oItemMenu.InnerText = permiso.Nombre;
                pEnDonde.Controls.Add(oItemMenu);
            }
            
        }

        /// <summary>
        /// Genera el Html del Checkbox dentro del Placeholder como parametro.
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pValue"></param>
        /// <param name="es_switch"></param>
        /// <param name="pEnDonde"></param>
        public static void Generar_Check(int pId, string pValue, bool es_switch, PlaceHolder pEnDonde)
        {
            string LabelclassValue = es_switch ? "mdl-switch mdl-js-switch mdl-js-ripple-effect" : "mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect"; ;
            string IdCheckValue = "id_" + pValue;
            string InputClassValue = es_switch ? "mdl-switch__input" : "mdl-checkbox__input";
            string SpanClassValue = es_switch ? "mdl-switch__label" : "mdl-checkbox__label";

            //Genero la Estructura HTML
            HtmlGenericControl oLabel = new HtmlGenericControl("label");
            oLabel.Attributes["class"] = LabelclassValue;
            oLabel.Attributes["for"] = IdCheckValue;

            HtmlInputCheckBox oCheck = new HtmlInputCheckBox();
            oCheck.Attributes["class"] = InputClassValue;
            oCheck.Attributes["id"] = IdCheckValue;
            oCheck.Attributes["value"] = pId.ToString();
            oLabel.Controls.Add(oCheck);

            HtmlGenericControl oSpan = new HtmlGenericControl("span");
            oSpan.Attributes["class"] = SpanClassValue;
            oSpan.InnerText = pValue;
            oLabel.Controls.Add(oSpan);

            //Agrego al PlaceHolder
            pEnDonde.Controls.Add(oLabel);

        }

        /// <summary>
        /// Devuelve una lista de Ids de los checkbox seleccionados dentro del Placeholder, para muchos checks.
        /// </summary>
        /// <param name="pDeDonde"></param>
        /// <returns></returns>
        static public List<int> Ids_Checks_Seleccionados (PlaceHolder pDeDonde)
        {
            List<int> Seleccionados = new List<int>();

            foreach (Control item in pDeDonde.Controls)
            {
                foreach (Control check in item.Controls)
                {
                    if (check is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox check1 = check as HtmlInputCheckBox;
                        if (check1.Checked)
                        {
                            Seleccionados.Add(Convert.ToInt32(check1.Value));
                        }
                    }
                }
            }
            return Seleccionados;
        }

        /// <summary>
        /// Devuelve si se chequeo el check dentro del Placeholder, para un solo check.
        /// </summary>
        /// <param name="pDeDonde"></param>
        /// <returns></returns>
        static public bool IsChecked(PlaceHolder pDeDonde)
        {
            bool seleccionado = false;

            foreach (Control item in pDeDonde.Controls)
            {
                foreach (Control check in item.Controls)
                {
                    if (check is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox check1 = check as HtmlInputCheckBox;
                        if (check1.Checked)
                        {
                            seleccionado = true;
                            break;
                        }
                    }
                }
            }
            return seleccionado;
        }

        /// <summary>
        /// Prende el check dentro del place holder, para un solo check
        /// </summary>
        /// <param name="pDeDonde"></param>
        static public void Check(int value, bool prendido, PlaceHolder pDeDonde)
        {
            foreach (Control item in pDeDonde.Controls)
            {
                foreach (Control check in item.Controls)
                {
                    if (check is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox check1 = check as HtmlInputCheckBox;
                        if (check1.Value == value.ToString())
                        {
                            check1.Checked = prendido;    
                        }                                
                    }
                }
            }
            
        }


        static public void Check(PlaceHolder pDeDonde)
        {
            foreach (Control item in pDeDonde.Controls)
            {
                foreach (Control check in item.Controls)
                {
                    if (check is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox check1 = check as HtmlInputCheckBox;
                        check1.Checked = true;
                    }
                }
            }

        }

    }
}