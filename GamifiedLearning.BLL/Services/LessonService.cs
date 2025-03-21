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
            return await _lessonRepository.GetWithQuizzesAsync(id);
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            var existing = await _lessonRepository.GetWithQuizzesAsync(lesson.Id);
            if (existing == null) return;

            existing.Title = lesson.Title;
            existing.Description = lesson.Description;
            existing.Content = lesson.Content;
            existing.Difficulty = lesson.Difficulty;
            existing.LessonNumber = lesson.LessonNumber;

            var incomingIds = lesson.Quizzes.Select(q => q.Id).ToHashSet();

            var quizzesToRemove = existing.Quizzes.Where(q => !incomingIds.Contains(q.Id)).ToList();
            foreach (var q in quizzesToRemove)
            {
                existing.Quizzes.Remove(q);
            }

            foreach (var quiz in lesson.Quizzes)
            {
                var existingQuiz = existing.Quizzes.FirstOrDefault(q => q.Id == quiz.Id);

                if (existingQuiz != null)
                {
                    existingQuiz.Question = quiz.Question;
                    existingQuiz.Answer = quiz.Answer;
                    existingQuiz.Points = quiz.Points;
                    existingQuiz.Type = quiz.Type;
                }
                else
                {
                    existing.Quizzes.Add(new Quiz
                    {
                        Question = quiz.Question,
                        Answer = quiz.Answer,
                        Points = quiz.Points,
                        Type = quiz.Type,
                        LessonId = lesson.Id
                    });
                }
            }

            await _lessonRepository.UpdateAsync(existing);
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