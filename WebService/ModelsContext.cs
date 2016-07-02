namespace BankingWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelsContext : DbContext
    {
        public ModelsContext()
            : base("name=Models")
        {
        }

        public virtual DbSet<Models.User> User { get; set; }
        public virtual DbSet<Models.UserSession> UserSession { get; set; }
        public virtual DbSet<Models.UserAccount> UserAccount { get; set; }
        public virtual DbSet<Models.Transaction> Transaction { get; set; }

        public virtual DbSet<Models.Quizzes> Quizzes { get; set; }
        public virtual DbSet<Models.Exam> Exam { get; set; }
        public virtual DbSet<Models.AnswerSheet> AnswerSheet { get; set; }
        public virtual DbSet<Models.AnswerSheetItem> AnswerSheetItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}