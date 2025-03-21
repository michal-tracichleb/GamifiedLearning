using GamifiedLearning.BLL.Interfaces;
using GamifiedLearning.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GamifiedLearning.BLL
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILessonService, LessonService>();
        }
    }
}