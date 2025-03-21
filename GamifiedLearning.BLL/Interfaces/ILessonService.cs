﻿using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.BLL.Interfaces
{
    public interface ILessonService
    {
        Task<ICollection<Lesson>> GetAllLessonsAsync();

        Task AddLessonAsync(Lesson lesson);

        Task<Lesson> GetLessonByIdAsync(int id);

        Task UpdateLessonAsync(Lesson lesson, List<int> deletedQuizIds);

        Task DeleteLessonAsync(int id);
    }
}