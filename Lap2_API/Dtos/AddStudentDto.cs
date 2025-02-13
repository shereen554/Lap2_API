using System.ComponentModel.DataAnnotations;

namespace Lap2_API.Dtos
{
    public class AddStudentDto
    {

        [StringLength(50)]
        public string St_Fname { get; set; }

        [StringLength(10)]
        public string St_Lname { get; set; }

        [StringLength(100)]
        public string St_Address { get; set; }

        public int? St_Age { get; set; }

        public int? SupervisorId { get; set; }
        public int? DepartMentId { get; set; }
    }
}
