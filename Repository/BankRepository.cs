using BankManagementSystem.Data;
using BankManagementSystem.DTOs;
using BankManagementSystem.Exceptions;
using BankManagementSystem.Model;

namespace BankManagementSystem.Repository
{
    public class BankRepository : IBankRepository
    {
        private AppDbContext context;

        public BankRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(BankAccountRequestDTO dto)
        {
            BankAccount b = new BankAccount()
            {
                HolderName = dto.HolderName,
                AccountNumber = dto.AccountNumber,
                AccountType = dto.AccountType,
                AccountBalance = dto.AccountBalance,
                BranchName = dto.BranchName,
                IFSCCode = dto.IFSCCode,
                CreatedDate = dto.CreatedDate,
            };
            context.bank.Add(b);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var bank = context.bank.FirstOrDefault(e=>e.AccountId == id);
           if(bank != null)
            {
                context.bank.Remove(bank);
                context.SaveChanges();
            }

        }

        public void Deposit(DepositRequestDTO dto)
        {
           var account = context.bank.FirstOrDefault(x => x.AccountNumber == dto.AccountNumber);

            if (account == null)
            {
                return;
            }

            account.AccountBalance += dto.AccountBalance;

            context.SaveChanges();

        }

        public void Withdraw(WithdrawRequestDTO dto)
        {
            var b = context.bank.FirstOrDefault(x => x.AccountNumber == dto.AccountNumber);
            b.AccountBalance -= dto.AccountBalance;
            context.SaveChanges();
        }

        public void Transfer(TransferRequestDTO dto)
        {
            var sender = context.bank.FirstOrDefault(x => x.AccountNumber == dto.FromAccount);
            var receiver = context.bank.FirstOrDefault(x => x.AccountNumber == dto.ToAccount);

            if(sender == null || receiver == null)
            {
                return;
            }
            sender.AccountBalance -= dto.Amount;
            receiver.AccountBalance += dto.Amount;
            context.SaveChanges();
        }

        public List<BankAccountResponseDTO> GetAll()
        {
            return context.bank.Select(b => new BankAccountResponseDTO()
            {
                HolderName = b.HolderName,
                AccountNumber = b.AccountNumber,
                AccountBalance = b.AccountBalance
            }).ToList();
        }

        public BankAccountResponseDTO GetById(int id)
        {
            var bank = context.bank.FirstOrDefault(b => b.AccountId == id);
            if(bank == null)
            {
                return null;
            }
            return new BankAccountResponseDTO()
            {
                HolderName = bank.HolderName,
                AccountNumber = bank.AccountNumber,
                AccountBalance = bank.AccountBalance

            };
        }

        public BankAccountResponseDTO SearchAccountNumber(string accountNumber)
        {
            return context.bank
                .Where(e => e.AccountNumber == accountNumber)
                .Select(b => new BankAccountResponseDTO
                {
                    HolderName = b.HolderName,
                    AccountNumber = b.AccountNumber,
                    AccountBalance = b.AccountBalance
                })
                .FirstOrDefault();
        }


        public List<BankAccountResponseDTO> SearchByName(string name)
        {
            return context.bank.Where(e => e.HolderName.ToLower().Contains(name.ToLower())).Select(b => new BankAccountResponseDTO
            {
                HolderName = b.HolderName,
                AccountNumber = b.AccountNumber,
                AccountBalance= b.AccountBalance

            }).ToList();
           
        }

        public void Update(int id, BankAccountRequestDTO dto)
        {
            var bank = context.bank.FirstOrDefault(b => b.AccountId == id);
            if(bank != null)
            {
                bank.HolderName = dto.HolderName;
                bank.AccountNumber = dto.AccountNumber;
                bank.AccountType = dto.AccountType;
                bank.AccountBalance = dto.AccountBalance;
                bank.BranchName = dto.BranchName;
                bank.IFSCCode = dto.IFSCCode;
                context.SaveChanges();
            }

        }
    }
}
