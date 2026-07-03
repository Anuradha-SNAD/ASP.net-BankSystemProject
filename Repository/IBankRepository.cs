using BankManagementSystem.DTOs;

namespace BankManagementSystem.Repository
{
    public interface IBankRepository
    {
        void Add(BankAccountRequestDTO dto);

        List<BankAccountResponseDTO> GetAll();

        BankAccountResponseDTO GetById(int id);

        void Update(int id, BankAccountRequestDTO dto);
        void Delete(int id);

        List<BankAccountResponseDTO> SearchByName(string name);

        BankAccountResponseDTO SearchAccountNumber(string AccountNumber);

        void Deposit(DepositRequestDTO dto);
        void Withdraw(WithdrawRequestDTO dto);

        void Transfer(TransferRequestDTO dto);
    }
}
