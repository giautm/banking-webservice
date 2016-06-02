using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App
{
    public partial class Transfer : System.Web.UI.Page
    {
        private string mSessionToken = null;
        private Banking.UserAccount mAccount = null;
        private Banking.AccountSoapClient mService = new Banking.AccountSoapClient();

        protected string mMessageError = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            var ident = User.Identity as FormsIdentity;
            if (!User.Identity.IsAuthenticated || ident == null || ident.Ticket.UserData == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                mSessionToken = ident.Ticket.UserData;
                var result = mService.getAccount(mSessionToken, Request.QueryString["bankNumber"]);
                if (result._checkResult())
                {
                    mAccount = result.Account;
                    bankNumber.Text = mAccount.Number;
                    balances.Text = mAccount.Balances.ToString();
                }
            }

        }

        protected void Execute_Click(object sender, EventArgs e)
        {
            decimal amount;
            if ((decimal.TryParse(txtAmount.Text, out amount) && amount > 0 && amount <= mAccount.Balances))
            {
                var result = mService.transfer(mSessionToken, mAccount.Number, transferTo.Text, amount);
                if (result.MessageError == null)
                {
                    Response.Redirect("./Home.aspx?message=" + Server.UrlEncode("Đã chuyển khoảng thành công"));
                }
                else
                {
                    mMessageError = result.MessageError;
                }
            }
            else
            {
                mMessageError = "Số tiền không hợp lệ";
            }

        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
        }
    }
}