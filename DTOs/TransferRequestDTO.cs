using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs
{
    public class TransferRequestDTO
    {
        [Required]
        public string FromAccount { get; set; }

        [Required]
        public string ToAccount { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
    }
}
