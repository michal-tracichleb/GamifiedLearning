using GamifiedLearning.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamifiedLearning.DAL
{
    public class GamifiedLearningDBContext : IdentityDbContext<User>
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<UserProgressQuiz> UserProgressQuizzes { get; set; }

        public GamifiedLearningDBContext(DbContextOptions<GamifiedLearningDBContext> options) : base(options)
        {
        }
    }
}