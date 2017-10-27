using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de conexion
/// </summary>
public class conexion
{
    private MySqlConnection connection;
    public string connectionString;
    private string server;
    private string database;
    private string uid;
    private string password;

    private string usuario;
    private string pass;
    

    //Variables para manejar el login y variables de sesion
    public bool autenticacion = false;
    public string usubd;
    public string passbd;
    public string nombrecompleto;
    public String seccioncad;
    public bool seccion;

    //constructor
    public conexion()
    {
        Iniciar();
    }

    //Dandole los valores a las variables.
    private void Iniciar()
    {
        
        //Configuración para XAMP
        //server = "127.0.0.1";
        //database = "admin_academica";
        //uid = "root"; //username
        //password = ""; //password
        
        /*
        //Configuracion para dbfree.net
        server = "db4free.net";
        database = "admin_academica";
        uid = "fernando9825"; //Username
        password = "982505"; //password

        */

        
        //Configuracion para Smarterasp.net
        server = "mysql5005.smarterasp.net";
        database = "db_a2b143_fer9825";
        uid = "a2b143_fer9825"; //Username
        password = "982505va"; //password
        

        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        //connectionString = @"Server=sql3.freemysqlhosting.net; Database=sql3193965; Uid=sql3193965; Pwd=VZrEn2fStQ; Port=3306;";

        connection = new MySqlConnection(connectionString);
    }


    //Métodos
   


    //Abrir la conección
    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            //switch (ex.Number)
            //{
            //    case 0:

            //        MessageBox.Show("Cannot connect to server.  Contact administrator");
            //        break;

            //    case 1045:
            //        MessageBox.Show("Invalid username/password, please try again");
            //        break;
            //}
            return false;
        }
    }

    //Cerrar la conexión
    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            //MessageBox.Show(ex.Message);
            return false;
        }
    }

    public void IniciarSesion(string usuario, string password)
    {
        string query = "SELECT * FROM alumnos WHERE carnet = '" + usuario + "'";
        bool conec = OpenConnection();

        if (conec == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read() == true)
            {
                //usubd = dataReader["usuario"].ToString();
                //passbd = dataReader["password"].ToString();
                usubd = dataReader.GetString(0);
                passbd = dataReader.GetString(8);
                seccioncad = dataReader.GetString(7);
                nombrecompleto = dataReader.GetString(1) + " " + dataReader.GetString(2);
                dataReader.Close();

                if (seccioncad.Contains("Técnico"))
                {
                    seccion = true;
                }else if (seccioncad.Contains("General"))
                {
                    seccion = false;
                }
            }
        }

        if(usubd == usuario)
        {
            if(passbd == password)
            {
                autenticacion = true;
            }
        }
    }

    //Select statement
    public List<string>[] Select()
    {
        string query = "SELECT * FROM Maestro where";

        //Create a list to store the result
        List<string>[] list = new List<string>[3];
        list[0] = new List<string>();
        list[1] = new List<string>();
        list[2] = new List<string>();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["name"] + "");
                list[2].Add(dataReader["age"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }

}



    
