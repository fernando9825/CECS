using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Notas_notas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (Session["persona"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                NombreAlumno.InnerText = Session["persona"].ToString();
            }

        }
        catch (Exception)
        {

        }
    }
}