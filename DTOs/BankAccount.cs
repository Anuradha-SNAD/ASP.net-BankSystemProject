using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Model
{
    public class BankAccount
    {
        [Key]
        public int AccountId { get; set; }
        public string HolderName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
