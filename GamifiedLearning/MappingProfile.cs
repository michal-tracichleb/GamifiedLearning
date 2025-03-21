using AutoMapper;
using GamifiedLearning.DAL.Models;
using GamifiedLearning.Models.Lesson;
using GamifiedLearning.Models.Quiz;

namespace GamifiedLearning
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lesson, LessonViewModel>().ReverseMap();

            CreateMap<Lesson, LessonViewModel>()
                .ForMember(dest => dest.Quizzes, opt => opt.MapFrom(src => src.Quizzes));

            CreateMap<LessonViewModel, Lesson>()
                .ForMember(dest => dest.Quizzes, opt => opt.MapFrom(src => src.Quizzes));

            CreateMap<Quiz, QuizViewModel>().ReverseMap();
        }
    }
}