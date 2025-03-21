using GamifiedLearning.DAL.Models;
using GamifiedLearning.DAL.Models.Enums;

namespace GamifiedLearning.DAL.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        public Task<List<Lesson>> GetLessonsByDifficulty(DifficultyLevel level);
    }
}