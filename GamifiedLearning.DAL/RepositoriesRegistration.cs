using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GamifiedLearning.DAL
{
    public static class RepositoriesRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IUserProgressRepository, UserProgressRepository>();
        }
    }
}