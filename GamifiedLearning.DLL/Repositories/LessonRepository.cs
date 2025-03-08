using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.DAL.Repositories
{
    internal class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(GamifiedLearningDBContext context) : base(context)
        {
        }
    }
}