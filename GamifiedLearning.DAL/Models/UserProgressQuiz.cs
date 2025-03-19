namespace GamifiedLearning.DAL.Models
{
    public class UserProgressQuiz : IModelBase
    {
        public int Id { get; set; }

        public int UserProgressId { get; set; }
        public UserProgress UserProgress { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public bool IsCompleted { get; set; }

        public int Score { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}