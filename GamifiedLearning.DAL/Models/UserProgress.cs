using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.DAL.Models
{
    public class UserProgress : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public int Score { get; set; }
        public bool IsCompleted { get; set; }
        public int QuizzesCompleted { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<UserProgressQuiz> UserProgressQuizzes { get; set; }
    }
}