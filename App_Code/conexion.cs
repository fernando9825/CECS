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
    private string server;
    private string database;
    private string uid;
    private string password;

    private string usuario;
    private string pass;
    public bool autenticacion = false;
    public string usubd;
    public string passbd;

    //constructor
    public conexion()
    {
        Iniciar();
    }

    //Dandole los valores a las variables.
    private void Iniciar()
    {
        server = "127.0.0.1";
        database = "admin_academica";
        uid = "root"; //Username
        password = ""; //password
        string connectionString;
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
        string query = "SELECT * FROM maestros WHERE usuario = '" + usuario + "'";
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
                usubd = dataReader.GetString(5);
                passbd = dataReader.GetString(6);
                dataReader.Close();
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



    
