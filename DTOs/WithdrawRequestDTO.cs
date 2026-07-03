using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs
{
    public class WithdrawRequestDTO
    {
        [Required]
        public string AccountNumber { get; set; }
        [Range(1,double.MaxValue)]
        public decimal AccountBalance { get; set; }
    }
}
