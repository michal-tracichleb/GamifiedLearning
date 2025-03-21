using GamifiedLearning.DAL.Models;

namespace GamifiedLearning.BLL.Interfaces
{
    public interface ILessonService
    {
        Task<ICollection<Lesson>> GetAllLessonsAsync();
    }
}