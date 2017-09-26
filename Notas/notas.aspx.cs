using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                GridBDMySQL();
            }

        }
        catch (Exception)
        {

        }

       
    }

    private void GridBDMySQL()
    {
        string server, database, uid, password, connectionString;
        /*
        server = "127.0.0.1";
        database = "admin_academica";
        uid = "root"; //Username
        password = ""; //password
        */

        //Configuracion para Smarterasp.net
        server = "mysql5005.smarterasp.net";
        database = "db_a2b143_fer9825";
        uid = "a2b143_fer9825"; //Username
        password = "982505va"; //password

        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM maestros", mySqlConnection);
        DataTable dataTable = new DataTable();

        mySqlDataAdapter.Fill(dataTable);
        if(dataTable.Rows.Count > 0)
        {
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }


    }
}