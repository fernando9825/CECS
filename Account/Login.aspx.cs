using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using CECS;

public partial class Account_Login : Page
{

    public string txtUsuario, txtPassword;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["persona"].ToString() != null)
                {
                    Response.Redirect("../Notas/notas.aspx");
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
        }

   

        protected void LogIn(object sender, EventArgs e)
        {
            txtUsuario = UserName.Text.ToString();
            txtPassword = Password.Text.ToString();
            conexion a = new conexion();
            a.IniciarSesion(txtUsuario, txtPassword);
        
            a.CloseConnection();
            if(a.autenticacion == true)
            {
                try
                {
                    Session["persona"] = a.nombrecompleto;
                    Session["usuario"] = a.usubd;
                    Session["password"] = a.passbd;

                }
                catch (Exception)
                {

                    throw;
                }
                Response.Redirect("../Notas/notas.aspx");
            }
            else
            {
            
            }
                //////if (IsValid)
                //////{
                //////    // Validate the user password
                //////    var manager = new UserManager();
                //////    ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                //////    if (user != null)
                //////    {
                //////        IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                //////        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //////    }
                //////    else
                //////    {
                //////        FailureText.Text = "Invalid username or password.";
                //////        ErrorMessage.Visible = true;
                //////    }
                //////}
        }
}