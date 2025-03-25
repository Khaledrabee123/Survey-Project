using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication3.Models.WebApplication3.Models;
using System.Reflection.Emit;
using Survay.Models.DTOs;

namespace Survay.Models.database
{
    public class db : IdentityDbContext<User>
    {



        public db()
        {

        }

        public db(DbContextOptions options) : base(options) { }


        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-T3ABVVQ\\MSSQLSERVER01;Initial Catalog =survay;Integrated Security=true;TrustServerCertificate=True;Encrypt=False");
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Servey> Surveys { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Choice> choses { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }



        public void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Important for Identity

            // User - Survey (1 to Many)
            builder.Entity<Servey>()
                .HasOne(s => s.Creator)
                .WithMany(u => u.CreatedSurveys)
                .HasForeignKey(s => s.UserID) // Fixed foreign key
                .OnDelete(DeleteBehavior.Restrict);

            // Survey - Questions (1 to Many)
            builder.Entity<Question>()
                .HasOne(q => q.Survey)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            // Question - Choices (1 to Many)
            builder.Entity<Choice>() // Fixed entity name
                .HasOne(o => o.Question)
                .WithMany(q => q.Choices) // Fixed property name
                .HasForeignKey(o => o.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Response (1 to Many)
            builder.Entity<Response>()
                .HasOne(r => r.Survey)
                .WithMany(s => s.Responses)
                .HasForeignKey(r => r.SurveyID)
                .OnDelete(DeleteBehavior.NoAction); // ✅ Fix here

            // User - Response (1 to Many) ✅ Keep as Restrict
            builder.Entity<Response>()
                .HasOne(r => r.User)
                .WithMany(u => u.Responses)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            // Response - Answer (1 to Many)
            builder.Entity<Answer>()
                .HasOne(a => a.Response)
                .WithMany(r => r.Answers)
                .HasForeignKey(a => a.ResponseID)
                .OnDelete(DeleteBehavior.Cascade);


            // Option - Answer (Optional relation for MCQ)
            builder.Entity<Answer>()
                .HasOne(a => a.Option)
                .WithMany()
                .HasForeignKey(a => a.OptionID)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
