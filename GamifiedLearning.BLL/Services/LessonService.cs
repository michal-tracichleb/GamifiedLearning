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

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            return await _lessonRepository.GetAsync(id);
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            await _lessonRepository.UpdateAsync(lesson);
        }

        public async Task DeleteLessonAsync(int id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            if (lesson != null)
            {
                await _lessonRepository.DeleteAsync(lesson);
            }
        }
    }
}