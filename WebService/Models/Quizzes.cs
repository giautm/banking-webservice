using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingWebService.Models
{
    [Table("quizzes")]
    public class Quizzes
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [StringLength(2147483647)]
        [Column("subject")]
        public string Subject { get; set; }

        [StringLength(2147483647)]
        [Column("question")]
        public string Question { get; set; }

        [StringLength(2147483647)]
        [Column("answer")]
        public string Answer { get; set; }

        [StringLength(2147483647)]
        [Column("choose_a")]
        public string ChooseA { get; set; }

        [StringLength(2147483647)]
        [Column("choose_b")]
        public string ChooseB { get; set; }

        [StringLength(2147483647)]
        [Column("choose_c")]
        public string ChooseC { get; set; }

        [StringLength(2147483647)]
        [Column("choose_d")]
        public string ChooseD { get; set; }
    }
}