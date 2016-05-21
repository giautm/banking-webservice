using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingWebService.Models
{
  [Table("transaction")]
  public class Transaction
  {
    public Transaction()
    {
      Token = Guid.NewGuid().ToString();
    }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [StringLength(2147483647)]
    [Column("token")]
    public string Token { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("session_id")]
    public long UserSession { get; set; }

    [Column("account_id")]
    public long UserAccount { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("is_approve")]
    public bool IsApprove { get; set; }
    
    [Column("approve_at")]
    public DateTime? ApproveAt { get; set; }

    [Column("approve_by")]
    public long ApproveBy { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
  }
}