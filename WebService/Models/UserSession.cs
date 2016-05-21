namespace BankingWebService.Models
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Runtime.Serialization;
  [Table("user_session")]
  public class UserSession
  {
    public UserSession()
    {
      SessionToken = Guid.NewGuid().ToString();
      IsActived = true;
      CreatedAt = DateTime.Now;
      ExpiresAt = CreatedAt.Value.AddMinutes(5);
    }

    public UserSession(long userId)
    {
      UserId = userId;
      SessionToken = Guid.NewGuid().ToString();
      IsActived = true;
      CreatedAt = DateTime.Now;
      ExpiresAt = CreatedAt.Value.AddMinutes(5);
    }

    public void refresh()
    {
      ExpiresAt = DateTime.Now.AddMinutes(5);
    }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [StringLength(2147483647)]
    [Column("session_token")]
    public string SessionToken { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    [Column("is_actived")]
    public bool IsActived { get; set; }
  }
}
