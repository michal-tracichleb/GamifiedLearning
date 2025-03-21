using GamifiedLearning.DAL.Models.Enums;
using GamifiedLearning.Models.Quiz;
using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.Models.Lesson
{
    public class LessonViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DifficultyLevel Difficulty { get; set; }

        [Required]
        public int LessonNumber { get; set; }

        public string Content { get; set; }

        public List<QuizViewModel> Quizzes { get; set; } = new List<QuizViewModel>();
    }
}