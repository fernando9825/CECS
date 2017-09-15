﻿using System;
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
                
                Response.Redirect("/Notas/notas.aspx");
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