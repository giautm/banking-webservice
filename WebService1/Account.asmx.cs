using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace BankingWebService
{
  /// <summary>
  /// Summary description for Service1
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class Account : System.Web.Services.WebService
  {
    private ModelsContext mContext = new ModelsContext();

    public class LoginResult
    {
      public string SessionToken;
      public string MessageError;

      public override string ToString()
      {
        return string.Format("Token: {0}, error message: {1}", SessionToken, MessageError);
      }
    }

    public long? _checkSessionToken(string sessionToken, LoginResult result)
    {
      var now = DateTime.Now;
      var session = mContext.UserSession
          .Where(s => s.SessionToken.Equals(sessionToken) && s.IsActived
            && (s.ExpiresAt.HasValue && DateTime.Compare(s.ExpiresAt.Value, now) > 0))
          .FirstOrDefault();

      if (session != null)
      {
        // Cập nhật lại thời gian hết hạn của phiên.
        session.refresh();
        mContext.SaveChanges();

        // Cập nhật lại Session Token nếu có thay đổi.
        result.SessionToken = session.SessionToken;

        return session.UserId;
      }
      else
      {
        // Cập nhật lại Session Token nếu có thay đổi.
        result.SessionToken = null;
        result.MessageError = "Phiên đã hết hạn hoặc không tồn tại. Vui lòng đăng nhập lại.";

        return null;
      }
    }

    public string _hashUserPassword(string password, string salt)
    {
      byte[] bytes = new UTF8Encoding().GetBytes(password + salt);
      byte[] hash = (CryptoConfig.CreateFromName("MD5") as HashAlgorithm)
        .ComputeHash(bytes);

      // string representation (similar to UNIX format)
      return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
    }

    [WebMethod]
    public LoginResult Register(Models.User user)
    {
      var result = new LoginResult();
      var readyExists = mContext.User
        .Where(u => u.Username == user.Username).Count() > 0;
      if (readyExists)
      {
        result.MessageError = "Tài khoản đã tồn tại";
      }
      else
      {
        user.Id = 0;
        // TODO: Generate password salt.
        user.Salt = "giautm";
        user.Password = _hashUserPassword(user.Password, user.Salt);
        user.CreatedAt = DateTime.Now;
        mContext.User.Add(user);
        mContext.SaveChanges();

        var currentSession = new Models.UserSession(user.Id);
        mContext.UserSession.Add(currentSession);
        mContext.UserAccount.Add(new Models.UserAccount(user.Id));
        mContext.SaveChanges();

        result.SessionToken = currentSession.SessionToken;
      }

      return result;
    }

    [WebMethod]
    public LoginResult Login(string username, string password)
    {
      var result = new LoginResult();
      var user = mContext.User
        .Where(u => u.Username.Equals(username))
        .FirstOrDefault();

      if (user != null && user.Id > 0 &&
        user.Password.Equals(_hashUserPassword(password, user.Salt)))
      {
        var session = mContext.UserSession.Add(new Models.UserSession(user.Id));
        mContext.SaveChanges();

        result.SessionToken = session.SessionToken;
      }
      else
      {
        result.MessageError = "Tên đăng nhập hoặc mật khẩu không chính xác.";
      }

      return result;
    }

    [WebMethod]
    public void Logout(string sessionToken)
    {
      var session = mContext.UserSession
          .Where(s => s.SessionToken.Equals(sessionToken) && s.IsActived)
          .FirstOrDefault();

      if (session != null)
      {
        session.IsActived = false;
        mContext.SaveChanges();
      }
    }

    public class AccountsResult : LoginResult
    {
      public List<Models.UserAccount> Accounts;
    }

    [WebMethod]
    public AccountsResult Accounts(string sessionToken)
    {
      var result = new AccountsResult();
      var userId = _checkSessionToken(sessionToken, result);
      if (userId.HasValue)
      {
        var accounts = mContext.UserAccount
          .Where(a => a.UserId == userId);

        result.Accounts = accounts.ToList();
      }

      return result;
    }

    public class NewAccountsResult : LoginResult
    {
      public Models.UserAccount Account;
    }

    [WebMethod]
    public NewAccountsResult NewAccount(string sessionToken, decimal balances = 0)
    {
      var result = new NewAccountsResult();
      var userId = _checkSessionToken(sessionToken, result);
      if (userId.HasValue)
      {
        var account = mContext.UserAccount.Add(
          new Models.UserAccount(userId.Value, balances));
        mContext.SaveChanges();

        result.Account = account;
      }

      return result;
    }

    public class TransferResult : LoginResult
    {
      public Models.Transaction Transaction;
    }

    public TransferResult transfer(string sessionToken, string accountNumber, string receiveAccountNumber, decimal amount)
    {
      var result = new TransferResult();
      var userId = _checkSessionToken(sessionToken, result);
      if (userId.HasValue)
      {
        var transfeeAccount = mContext.UserAccount
          .Where(a => a.Number == accountNumber)
          .FirstOrDefault();

        var transferAccount = mContext.UserAccount
          .Where(a => a.Number == receiveAccountNumber)
          .FirstOrDefault();

        if (transfeeAccount == null || transferAccount == null)
        {
          result.MessageError = "Tài khoản gửi hoặc nhận không tồn tại.";
        }
        else
        {
          var transaction1 = new Models.Transaction();
          var transaction2 = new Models.Transaction();
          transaction1.Token = transaction2.Token = "aaaaaaaaa";

          transaction1.UserAccount = userId.Value;
          transaction1.Amount = amount;

          transaction2.UserAccount = userId.Value;
          transaction2.Amount = amount;

          result.Transaction = transaction1;
        }
      }

      return result;
    }
  }
}