namespace BankingWebService.Models
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("user")]
  public class User
  {
    [Column("id")]
    public long Id { get; set; }

    [StringLength(100)]
    [Column("username")]
    public string Username { get; set; }

    [StringLength(100)]
    [Column("password")]
    public string Password { get; set; }

    [StringLength(100)]
    [Column("salt")]
    public string Salt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
  }
}
