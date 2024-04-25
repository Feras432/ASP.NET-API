using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class BankBranchResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Url]
        public string LocationURL { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public int EmployeeCount { get; set; }
        [Required]
        public List<EmployeeResponse> Employees { get; set;}

       
    }
}
