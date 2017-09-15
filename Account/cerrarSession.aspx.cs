using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_cerrarSession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["persona"] != null)
            {
                Session.Remove("persona");
                Session.Remove("usuario");
                Session.Remove("password");
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
        catch (Exception)
        {

        }
    }
}