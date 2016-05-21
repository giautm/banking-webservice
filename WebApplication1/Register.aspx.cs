using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
  public partial class Register : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
      var service = new BankingWebService.Account();
      var session = service.login(txtUsername.Text, txtPassword.Text);

      txtResult.Text = session.ToString();
    }
  }
}