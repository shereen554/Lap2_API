using System.ComponentModel.DataAnnotations;

namespace Lap2_API.Dtos
{
    public class ReadStudentDto
    {
        public int St_Id { get; set; }

        [StringLength(50)]
        public string St_Fname { get; set; }

        [StringLength(10)]
        public string St_Lname { get; set; }

        [StringLength(100)]
        public string St_Address { get; set; }

        public int? St_Age { get; set; }

        public string Department { get; set; }

        public string SuperVisor { get; set; }
    }
}
