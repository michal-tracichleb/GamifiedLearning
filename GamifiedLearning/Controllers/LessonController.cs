using AutoMapper;
using GamifiedLearning.BLL.Interfaces;
using GamifiedLearning.Models.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamifiedLearning.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(
            ILessonService lessonService,
            IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            var viewModel = _mapper.Map<ICollection<LessonViewModel>>(lessons);
            return View(viewModel);
        }
    }
}