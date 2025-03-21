using GamifiedLearning.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.Models.Quiz
{
    public class QuizViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int Points { get; set; }

        [Required]
        public QuizType Type { get; set; }
    }
}