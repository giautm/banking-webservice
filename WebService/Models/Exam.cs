using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingWebService.Models
{
    [Table("exam")]
    public class Exam
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [StringLength(2147483647)]
        [Column("title")]
        public string Title { get; set; }

        [StringLength(2147483647)]
        [Column("subject")]
        public string Subject { get; set; }

        [Column("time")]
        public double Time { get; set; }

        [StringLength(2147483647)]
        [Column("quizzes")]
        public string Quizzes { get; set; }
    }
}