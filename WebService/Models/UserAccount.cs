using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankingWebService.Models
{
  [Table("user_account")]
  public class UserAccount
  {
    [Column("account_id")]
    public long Id { get; set; }

    [StringLength(20)]
    [Column("account_number")]
    public string Number { get; set; }

    [Column("balances")]
    public decimal Balances { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    public UserAccount()
    {
      UserId = 0;
      Balances = 0;
      CreatedAt = UpdatedAt = DateTime.Now;
    }

    public UserAccount(long userId, decimal balances = 0, string accountNumber = null)
    {
      UserId = userId;
      Balances = balances;
      if (accountNumber == null || accountNumber.Length == 0)
      {
        Number = _generateAccountNumber();
      }
      else
      {
        Number = accountNumber;
      }
      CreatedAt = UpdatedAt = DateTime.Now;
    }

    public string _generateAccountNumber()
    {
      return string.Empty;
    }
  }
}