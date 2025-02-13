using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lap2_API.Dtos
{
    public class ReadDeparmentDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string  Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(50)]
        public string  Location { get; set; }

        public string  Manager { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Manager_hiredate { get; set; }

        public int NumberOfStudent {  get; set; }
    }
}
