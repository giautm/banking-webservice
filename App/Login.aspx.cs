using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var message = Request.QueryString["message"];
            if (message != null)
            {
                login.FailureText = message;
            }
        }

        protected void login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var service = new Banking.AccountSoapClient();
            var result = service.Login(this.login.UserName, this.login.Password);
            if (result.MessageError == null)
            {
                e.Authenticated = true;
                // Create the cookie that contains the forms authentication ticket
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(login.UserName, login.RememberMeSet);

                // Get the FormsAuthenticationTicket out of the encrypted cookie

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                // Create a new FormsAuthenticationTicket that includes our custom User Data

                FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name,
                    ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, result.SessionToken);

                authCookie.Value = FormsAuthentication.Encrypt(newTicket);

                // Manually add the authCookie to the Cookies collection
                Response.Cookies.Add(authCookie);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(login.UserName, login.RememberMeSet));
            }
            else
            {
                login.FailureText = result.MessageError;
            }
        }
    }
}