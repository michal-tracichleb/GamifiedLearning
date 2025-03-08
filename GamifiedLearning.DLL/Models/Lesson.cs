using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.DAL.Models
{
    public class Lesson : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Difficulty { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}