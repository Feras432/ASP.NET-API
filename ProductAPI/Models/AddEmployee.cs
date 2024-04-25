using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class AddEmployee
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; }
        
    }
}
