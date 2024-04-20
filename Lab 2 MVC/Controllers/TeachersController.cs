using Lab_2_MVC.Data;
using Lab_2_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab_2_MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TeachersController(ApplicationDbContext dbContext)
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
        public async Task<IActionResult> Add(Teachers viewModel)
        {
            var teacher = new Teachers
            {
                Name = viewModel.Name,
                Gender = viewModel.Gender,
                Birthdate = viewModel.Birthdate,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                CoursesId = viewModel.CoursesId,
                ClassesId = viewModel.ClassesId,
            };

            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Searches");
        }
        public void PopulateCourses () 
        {
            IEnumerable<SelectListItem> GetCourses = dbContext.Courses.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.Courses = GetCourses;
        }
        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(Courses viewModel)
        {
            var course = new Courses
            {
                Name = viewModel.Name,
            };

            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Searches");
        }
        public IActionResult EditCourse()
        {
            PopulateCourses();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(Courses viewModel)
        {
            var course = await dbContext.Courses.FindAsync(viewModel.Id);

            if (course is not null)
            {
                course.Name = viewModel.Name;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Searches");
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
        public IActionResult CreateClass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateClass(Classes viewModel)
        {
            var newClass = new Classes
            {
                Name = viewModel.Name,
            };

            await dbContext.Classes.AddAsync(newClass);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Searches");
        }
        public IActionResult EditClass() 
        {
            PopulateClasses();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditClass(Classes viewModel)
        {
            var classes = await dbContext.Classes.FindAsync(viewModel.Id);

            if (classes is not null)
            {
                classes.Name = viewModel.Name;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Searches");
        }
        [HttpGet]
        public async Task<IActionResult> List(string Search_Data)
        {
            var teacher = dbContext.Teachers.Where(s => s.Courses.Name.Contains(Search_Data) || Search_Data == null).ToList();

            foreach(var i in teacher)
            {
                i.Courses = dbContext.Courses.FirstOrDefault(u => u.Id == i.CoursesId);
                i.Classes = dbContext.Classes.FirstOrDefault(u => u.Id == i.ClassesId);
            }

            return View(teacher);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            PopulateClasses();
            PopulateCourses();
            var teacher = await dbContext.Teachers.FindAsync(id);

            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teachers viewModel)
        {
            var teacher = await dbContext.Teachers.FindAsync(viewModel.Id);

            if (teacher is not null)
            {
                teacher.Name = viewModel.Name;
                teacher.Gender = viewModel.Gender;
                teacher.Birthdate = viewModel.Birthdate;
                teacher.Email = viewModel.Email;
                teacher.PhoneNumber = viewModel.PhoneNumber;
                teacher.CoursesId = viewModel.CoursesId;
                teacher.ClassesId = viewModel.ClassesId;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Searches");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Teachers viewModel)
        {
            var teacher = await dbContext.Teachers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (teacher is not null)
            {
                dbContext.Teachers.Remove(viewModel);

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Searches");
        }
    }
}
