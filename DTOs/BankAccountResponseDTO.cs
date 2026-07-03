using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs
{
    public class BankAccountResponseDTO
    {
        public string HolderName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
   
    }
}
