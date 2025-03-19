using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.DAL.Repositories
{
    internal class UserProgressQuizRepository : Repository<UserProgressQuiz>, IUserProgressQuizRepository
    {
        public UserProgressQuizRepository(GamifiedLearningDBContext context) : base(context)
        {
        }
    }
}