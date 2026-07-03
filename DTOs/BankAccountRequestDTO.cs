using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs
{
    public class BankAccountRequestDTO
    {
        [Required(ErrorMessage = "Holder Name is Required")]
        public string HolderName { get; set; }
        [Required(ErrorMessage = "Bank Account Number is Required")]
        [MinLength(5)]
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        [Required]
        [Range(1,100000)]
        public decimal AccountBalance { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        [MinLength(8)]
        public string IFSCCode { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
