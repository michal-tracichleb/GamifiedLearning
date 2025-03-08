using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.DAL.Models
{
    public class Quiz : IModelBase
    {
        public int Id { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int Points { get; set; }
    }
}