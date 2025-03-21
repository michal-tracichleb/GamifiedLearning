using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;
using GamifiedLearning.DAL.Models.Enums;

namespace GamifiedLearning.DAL.Repositories
{
    internal class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(GamifiedLearningDBContext context) : base(context)
        {
        }

        public async Task<List<Lesson>> GetLessonsByDifficulty(DifficultyLevel level)
        {
            return _context.Lessons.Where(l => l.Difficulty == level).OrderBy(l => l.LessonNumber).ToList();
        }
    }
}