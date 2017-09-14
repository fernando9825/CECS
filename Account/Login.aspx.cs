using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using CECS;

public partial class Account_Login : Page
{
    public string txtUsuario, txtPassword;
        ////protected void Page_Load(object sender, EventArgs e)
        ////{
        ////    RegisterHyperLink.NavigateUrl = "Register";
        ////    OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
        ////    var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        ////    if (!String.IsNullOrEmpty(returnUrl))
        ////    {
        ////        RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        ////    }
        ////}

        protected void LogIn(object sender, EventArgs e)
        {
        txtUsuario = UserName.Text.ToString();
        txtPassword = Password.Text.ToString();
        conexion a = new conexion();
        a.IniciarSesion(txtUsuario, txtPassword);
        
        a.CloseConnection();
        if(a.autenticacion == true)
        {
            Response.Redirect("../Default.aspx");
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