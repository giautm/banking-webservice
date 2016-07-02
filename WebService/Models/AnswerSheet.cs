using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingWebService.Models
{
    [Table("answer_sheet")]
    public class AnswerSheet
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        [Column("exam_id")]
        public long ExamId { get; set; }

        [StringLength(2147483647)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [StringLength(2147483647)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("score")]
        public double? Score { get; set; }

        [Column("current_quizzes")]
        public long? CurrentQuizzes { get; set; }

        [Column("is_closed")]
        public bool IsClosed { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}