using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int Points { get; set; }
    }
}