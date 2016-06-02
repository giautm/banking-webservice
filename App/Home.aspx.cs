using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected string mSessionToken = null;
        protected string mCurrentUser = null;
        protected string mMessage = null;

        protected Banking.AccountSoapClient mService = new Banking.AccountSoapClient();
        protected bool _checkResult(Banking.LoginResult result)
        {
            if (result.MessageError != null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage(string.Format("message={0}", result.MessageError));
                return false;
            }

            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var ident = User.Identity as FormsIdentity;
            if (!User.Identity.IsAuthenticated || ident == null || ident.Ticket.UserData == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                mCurrentUser = ident.Ticket.Name;
                mSessionToken = ident.Ticket.UserData;
                _loadAccount();

                mMessage = Request.QueryString["message"];
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            if (mSessionToken != null)
            {
                mService.Logout(mSessionToken);
            }
            mSessionToken = null;
            mCurrentUser = null;
        }

        protected void _loadAccount()
        {
            var result = mService.Accounts(mSessionToken);
            if (result._checkResult())
            {
                ListView_Tabs.DataSource = result.Accounts;
                ListView_Tabs.DataBind();
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            decimal balances;
            if (decimal.TryParse(newBalance.Text, out balances) &&
                mService.NewAccount(mSessionToken, balances)._checkResult())
            {
                _loadAccount();
            }
        }

        protected void ListView_Tabs_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Transfer"))
            {
                Response.Redirect("/Transfer.aspx?bankNumber=" + Server.UrlEncode(e.CommandArgument as string));
            }
        }
    }

    public static class LoginResult
    {
        public static bool _checkResult(this Banking.LoginResult result)
        {
            if (result.MessageError != null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage(string.Format("message={0}", result.MessageError));
                return false;
            }
            return true;
        }
    }
}