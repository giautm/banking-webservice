using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingWebService.Models
{
    [Table("answer_sheet_item")]
    public class AnswerSheetItem
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("answer_sheet_id")]
        public long AnswerSheetId { get; set; }

        [Column("quizzes_id")]
        public long QuizzesId { get; set; }

        [StringLength(2147483647)]
        [Column("answer")]
        public string Answer { get; set; }

        [Column("match")]
        public bool Match { get; set; }
    }
}