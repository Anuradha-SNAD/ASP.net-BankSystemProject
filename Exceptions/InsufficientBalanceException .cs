namespace BankManagementSystem.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg):base(msg)
        {

        }
    }
}
