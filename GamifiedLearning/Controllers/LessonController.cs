using AutoMapper;
using GamifiedLearning.BLL.Interfaces;
using GamifiedLearning.DAL.Models;
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

        // GET: Lesson/Create
        public IActionResult Create()
        {
            return View(new LessonViewModel());
        }

        // POST: Lesson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var lesson = _mapper.Map<Lesson>(model);
            await _lessonService.AddLessonAsync(lesson);

            return RedirectToAction(nameof(Index));
        }

        // GET: Lesson/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<LessonViewModel>(lesson);
            return View(model);
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LessonViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var lesson = _mapper.Map<Lesson>(model);
            await _lessonService.UpdateLessonAsync(lesson);

            return RedirectToAction(nameof(Index));
        }

        // GET: Lesson/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<LessonViewModel>(lesson);
            return View(model);
        }

        // POST: Lesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _lessonService.DeleteLessonAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}