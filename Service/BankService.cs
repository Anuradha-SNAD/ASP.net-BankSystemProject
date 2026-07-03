using BankManagementSystem.DTOs;
using BankManagementSystem.Exceptions;
using BankManagementSystem.Repository;

namespace BankManagementSystem.Service
{
    public class BankService : IBankService
    {
        private readonly IBankRepository repository;

        public BankService(IBankRepository repository)
        {
            this.repository = repository;
        }
        public void Add(BankAccountRequestDTO dto)
        {
            repository.Add(dto);
        }

        public void Delete(int id)
        {
            var v = repository.GetById(id);
            if(v == null)
            {
                throw new AccountNotFoundEXception("Bank Account Id Not Found");
            }
           repository.Delete(id);

        }

        public void Deposit(DepositRequestDTO dto)
        {
            var account = repository.SearchAccountNumber(dto.AccountNumber);

            if (account == null)
            {
                throw new AccountNotFoundEXception($"Account Number '{dto.AccountNumber}' not found.");
            }

            repository.Deposit(dto);
        }

        public void Withdraw(WithdrawRequestDTO dto)
        {
            var account = repository.SearchAccountNumber(dto.AccountNumber);
            if (account == null)
            {
                throw new AccountNotFoundEXception($"Account Number '{dto.AccountNumber}' not found.");
            }
            if (account.AccountBalance < dto.AccountBalance)
            {
                throw new InsufficientBalanceException($"Insufficient balance");
            }
            repository.Withdraw(dto);
            
        }

        public void Transfer(TransferRequestDTO dto)
        {
            var sender = repository.SearchAccountNumber(dto.FromAccount);
            if(sender == null)
            {
                throw new AccountNotFoundEXception("Sender Account Not Found.");
            }

            var receiver = repository.SearchAccountNumber(dto.ToAccount);
            if (receiver == null)
            {
                throw new AccountNotFoundEXception("Receiver Account Not Found.");
            }
            if (sender.AccountBalance < dto.Amount)
            {
                throw new InsufficientBalanceException("Insufficient Balance.");
            }

            repository.Transfer(dto);
        }


        public List<BankAccountResponseDTO> GetAll()
        {
            return repository.GetAll();
        }

        public BankAccountResponseDTO GetById(int id)
        {
            var b = repository.GetById(id);
            if(b == null)
            {
                throw new AccountNotFoundEXception("Bank Account Id Not Found");
            }
            return b;
        }

        public BankAccountResponseDTO SearchAccountNumber(string AccountNumber)
        {
            return repository.SearchAccountNumber(AccountNumber);
        }

        public List<BankAccountResponseDTO> SearchByName(string name)
        {
            var bank = repository.SearchByName(name);
            return bank;
        }

        public void Update(int id, BankAccountRequestDTO dto)
        {
            var v = repository.GetById(id);
            if (v == null)
            {
                throw new AccountNotFoundEXception("Bank Account Id Not Found");
            }
            repository.Update(id, dto);
        }
    }
}
