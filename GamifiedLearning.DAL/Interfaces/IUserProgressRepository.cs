using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.DAL.Interfaces
{
    public interface IUserProgressRepository : IRepository<UserProgress>
    {
        Task<UserProgress?> GetByUserAndLessonAsync(int userId, int lessonId);
    }
}