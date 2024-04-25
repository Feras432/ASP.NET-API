using Bank_Branches_Individual_Mini_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class AddBankBranch : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LocationName.StartsWith("N"))
            {
                yield return new ValidationResult("Name can not start with N");
            }
        }
    }
}
