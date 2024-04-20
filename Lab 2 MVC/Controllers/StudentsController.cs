using Lab_2_MVC.Data;
using Lab_2_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab_2_MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Add()
        {
            PopulateClasses();
            PopulateCourses();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Students viewModel)
        {
            var student = new Students
            {
                Name = viewModel.Name,
                Gender = viewModel.Gender,
                Birthdate = viewModel.Birthdate,
                CoursesId = viewModel.CoursesId,
                ClassesId = viewModel.ClassesId,
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Searches");
        }
        public void PopulateCourses()
        {
            IEnumerable<SelectListItem> GetCourses = dbContext.Courses.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.Courses = GetCourses;
        }
        public void PopulateClasses()
        {
            IEnumerable<SelectListItem> GetClasses = dbContext.Classes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.Classes = GetClasses;
        }
        [HttpGet]
        public async Task<IActionResult> List(string Search_Data)
        {
            var student = dbContext.Students.Where(s => s.Name.Contains(Search_Data) || Search_Data == null).ToList();

            foreach (var i in student)
            {
                i.Courses = dbContext.Courses.FirstOrDefault(u => u.Id == i.CoursesId);
                i.Classes = dbContext.Classes.FirstOrDefault(u => u.Id == i.ClassesId);
            }
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            PopulateClasses();
            PopulateCourses();
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Students viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Gender = viewModel.Gender;
                student.Birthdate = viewModel.Birthdate;
                student.CoursesId = viewModel.CoursesId;
                student.ClassesId = viewModel.ClassesId;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Searches");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Students viewModel)
        {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Searches");
        }
    }
}
