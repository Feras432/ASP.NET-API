using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class EmployeeResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
