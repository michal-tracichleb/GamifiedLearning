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

        public async Task UpdateLessonAsync(Lesson lesson, List<int> deletedQuizIds)
        {
            var existing = await _lessonRepository.GetWithQuizzesAsync(lesson.Id);
            if (existing == null) return;

            existing.Quizzes = existing.Quizzes.Where(q => !deletedQuizIds.Contains(q.Id)).ToList();

            existing.Title = lesson.Title;
            existing.Description = lesson.Description;
            existing.Content = lesson.Content;
            existing.Difficulty = lesson.Difficulty;
            existing.LessonNumber = lesson.LessonNumber;

            foreach (var quiz in lesson.Quizzes)
            {
                if (deletedQuizIds.Contains(quiz.Id)) continue;
                var existingQuiz = existing.Quizzes.FirstOrDefault(q => q.Id == quiz.Id);

                if (quiz.Id != 0 && existingQuiz != null)
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