using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Difficulty { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}