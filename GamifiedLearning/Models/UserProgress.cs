namespace GamifiedLearning.Models
{
    public class UserProgress
    {
        public int UserProgressId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int CorrectAnswers { get; set; }

        public bool IsLessonCompleted { get; set; }
    }
}