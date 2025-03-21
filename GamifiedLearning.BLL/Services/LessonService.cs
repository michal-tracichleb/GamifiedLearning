using GamifiedLearning.BLL.Interfaces;
using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.BLL.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<ICollection<Lesson>> GetAllLessonsAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task AddLessonAsync(Lesson lesson)
        {
            await _lessonRepository.AddAsync(lesson);
        }
    }
}