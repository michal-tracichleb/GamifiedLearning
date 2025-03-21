using GamifiedLearning.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.DAL.Models
{
    public class Lesson : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DifficultyLevel Difficulty { get; set; }

        public string Content { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}