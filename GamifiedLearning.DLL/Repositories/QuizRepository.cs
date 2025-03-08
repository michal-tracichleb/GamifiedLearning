using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.DAL.Repositories
{
    internal class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        public QuizRepository(GamifiedLearningDBContext context) : base(context)
        {
        }
    }
}