using Lab_2_MVC.Data;
using Lab_2_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_2_MVC.Controllers
{
    public class SearchesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SearchesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> List(string Search_Data)
        {
            // makes it able to search for students or teachers names, courses and class.
            var list = dbContext.Students.
                Where(s => s.Name.Contains(Search_Data) || Search_Data == null || s.Courses.Name.Contains(Search_Data) || s.Classes.Name.Contains(Search_Data)).
                ToList();

            var sList = dbContext.Teachers.
                Where(s => s.Name.Contains(Search_Data) || Search_Data == null || s.Courses.Name.Contains(Search_Data) || s.Classes.Name.Contains(Search_Data)).
                ToList();


            // matches the Courses/ClassesID of Teachers and Students to Courses/Classes ID to get the name of the Course/Class
            foreach (var i in list)
            {
                i.Courses = dbContext.Courses.FirstOrDefault(u => u.Id == i.CoursesId);
                i.Classes = dbContext.Classes.FirstOrDefault(u => u.Id == i.ClassesId);
            }

            foreach (var i in sList)
            {
                i.Courses = dbContext.Courses.FirstOrDefault(u => u.Id == i.CoursesId);
                i.Classes = dbContext.Classes.FirstOrDefault(u => u.Id == i.ClassesId);
            }
            //Return 2 models so you can show 2 models in 1 view.
            return View(Tuple.Create(list, sList));
        }
    }
}
