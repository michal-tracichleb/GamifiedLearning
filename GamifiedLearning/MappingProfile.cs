using AutoMapper;
using GamifiedLearning.DAL.Models;
using GamifiedLearning.Models.Lesson;

namespace GamifiedLearning
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lesson, LessonViewModel>().ReverseMap();
        }
    }
}