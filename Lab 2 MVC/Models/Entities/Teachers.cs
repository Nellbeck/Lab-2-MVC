using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2_MVC.Models.Entities
{
    public class Teachers
    {   
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateOnly Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int ClassesId { get; set; }
        [ForeignKey("ClassesId")]
        public Classes Classes { get; set; }
        public int CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Courses Courses { get; set; }
    }
}
