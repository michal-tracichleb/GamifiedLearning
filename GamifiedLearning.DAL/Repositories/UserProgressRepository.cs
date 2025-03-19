using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifiedLearning.DAL.Repositories
{
    internal class UserProgressRepository : Repository<UserProgress>, IUserProgressRepository
    {
        public UserProgressRepository(GamifiedLearningDBContext context) : base(context)
        {
        }

        public async Task<UserProgress?> GetByUserAndLessonAsync(int userId, int lessonId)
        {
            return await _context.UserProgresses
                .Where(up => up.UserId == userId && up.LessonId == lessonId)
                .FirstOrDefaultAsync();
        }
    }
}