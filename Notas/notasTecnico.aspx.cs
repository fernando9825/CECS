using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Notas_notasTecnico : System.Web.UI.Page
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
                try
                {
                    if(Session["seccion"].Equals(true))
                    {

                    }
                    else
                    {
                        //Si es general, no tiene nada que hacer aqui...
                        Response.Redirect("../Notas/notasGeneral.aspx");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
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
        //"SERVER=mysql5005.smarterasp.net;DATABASE=db_a2b143_fer9825;UID=a2b143_fer9825;PASSWORD=982505va;"

        String carnet;
        carnet = Session["usuario"].ToString();
        String query = "SELECT * FROM notas WHERE carnet = '" + carnet + "'";
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, mySqlConnection);
        DataTable dataTable = new DataTable();
        mySqlDataAdapter.Fill(dataTable);

        //Para darle los nombres correctos a las columnas
        dataTable.Columns["Matemáticas"].ColumnName = "Math";
        dataTable.Columns["Sociales"].ColumnName = "Scls";
        dataTable.Columns["Ciencia"].ColumnName = "CCNN";
        dataTable.Columns["Lenguaje"].ColumnName = "Lang";
        dataTable.Columns["Ingles"].ColumnName = "Igls";
        dataTable.Columns["Seminario"].ColumnName = "Smnr";
        dataTable.Columns["Informática"].ColumnName = "info";
        dataTable.Columns["Tecnología"].ColumnName = "Tecno";
        dataTable.Columns["Matemáticas_financieras"].ColumnName = "MthFin";
        dataTable.Columns["Lab_creatividad"].ColumnName = "Crea";
        dataTable.Columns["Prácticas_contables"].ColumnName = "Pract";

        if (dataTable.Rows.Count > 0)
        {
            GridView1.DataSource = dataTable;
            GridView1.DataBind();

        }
    }
}