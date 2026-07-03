using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs
{
    public class DepositRequestDTO
    {
        [Required]
        public string AccountNumber { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal AccountBalance { get; set; }
    }
}
