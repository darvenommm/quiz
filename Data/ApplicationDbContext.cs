using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Quiz.Models;

namespace Quiz.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Test> Test { get; set; } = null!;

    public DbSet<Question> Questions { get; set; } = null!;

    public DbSet<Answer> Answers { get; set; } = null!;

    public DbSet<Result> Results { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Связь Test <-> Question
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Test)
            .WithMany(t => t.Questions)
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь Question <-> Answer
        modelBuilder.Entity<Answer>()
            .HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Result <-> Test
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Test)
            .WithMany(t => t.Results)
            .HasForeignKey(r => r.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Result <-> и User
        modelBuilder.Entity<Result>()
            .HasOne(r => r.User)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

