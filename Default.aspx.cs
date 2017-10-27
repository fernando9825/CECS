using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["persona"] != null)
            {
                if (Session["seccion"].Equals(true))
                {
                    //Si es de tecnico, entonces no tiene nada que hacer aqui
                    Response.Redirect("../Notas/notasTecnico.aspx");
                }
                else
                {
                    //Se asume que es de general...
                    Response.Redirect("/Notas/notasGeneral.aspx");
                }
                
            }
            else
            {
                Session["persona"] = null;
            }
        }
        catch (Exception)
        {

        }
    }
}