using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2_MVC.Models.Entities
{
    public class Search
    {
        [Key]
        public Guid? Id { get; set; }
        [ForeignKey("FKTeacher")]
        public Guid? FKTeacher { get; set; }
        [ForeignKey("FKStudent")]
        public Guid? FKStudent { get; set; }

        public Teachers? Teachers { get; set; }
        public Students? Students { get; set; }
        public IEnumerable<Teachers> ITeachers { get; set; }
        public IEnumerable<Teachers> IStudents { get; set; }

    }
}
