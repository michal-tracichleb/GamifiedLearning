using GamifiedLearning.BLL.Interfaces;
using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.BLL.Services
{
    public class UserProgressService : IUserProgressService
    {
        private readonly IRepository<UserProgress> _userProgressRepo;
        private readonly IRepository<UserProgressQuiz> _userProgressQuizRepo;
        private readonly IRepository<Lesson> _lessonRepo;
        private readonly IRepository<Quiz> _quizRepo;

        public UserProgressService(
            IRepository<UserProgress> userProgressRepo,
            IRepository<UserProgressQuiz> userProgressQuizRepo,
            IRepository<Lesson> lessonRepo,
            IRepository<Quiz> quizRepo)
        {
            _userProgressRepo = userProgressRepo;
            _userProgressQuizRepo = userProgressQuizRepo;
            _lessonRepo = lessonRepo;
            _quizRepo = quizRepo;
        }

        public async Task MarkQuizCompletedAsync(int userId, int lessonId, int quizId, int quizScore)
        {
            var progress = (await _userProgressRepo.GetAllAsync())
                .FirstOrDefault(p => p.UserId == userId && p.LessonId == lessonId);

            if (progress == null)
            {
                progress = new UserProgress
                {
                    UserId = userId,
                    LessonId = lessonId,
                    Score = 0,
                    IsCompleted = false,
                    QuizzesCompleted = 0,
                    LastUpdate = DateTime.UtcNow
                };
                await _userProgressRepo.AddAsync(progress);
            }

            var existing = (await _userProgressQuizRepo.GetAllAsync())
                .FirstOrDefault(upq => upq.UserProgressId == progress.Id && upq.QuizId == quizId);

            if (existing == null)
            {
                var upq = new UserProgressQuiz
                {
                    UserProgressId = progress.Id,
                    QuizId = quizId,
                    IsCompleted = true,
                    Score = quizScore,
                    CompletedAt = DateTime.UtcNow
                };
                await _userProgressQuizRepo.AddAsync(upq);

                progress.Score += quizScore;
                progress.QuizzesCompleted++;
                progress.LastUpdate = DateTime.UtcNow;

                var totalQuizCount = (await _quizRepo.GetAllAsync()).Count(q => q.LessonId == lessonId);

                if (progress.QuizzesCompleted >= totalQuizCount)
                {
                    progress.IsCompleted = true;
                }

                await _userProgressRepo.UpdateAsync(progress);
            }
        }

        public async Task<UserProgress?> GetUserProgressAsync(int userId, int lessonId)
        {
            return (await _userProgressRepo.GetAllAsync())
                .Where(p => p.UserId == userId && p.LessonId == lessonId);
        }
    }
}