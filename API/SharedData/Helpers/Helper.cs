using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Helpers
{
    
    public static class Helper
    {
        

        #region Helper Methods
        public static int CreateAccountNumber(List<int> existingAccounts)
        {
            //Possible solution -> use guid instead??
            var rnd = new Random();
            var accountNumber = rnd.Next(1, int.MaxValue);
            
            //If account genrated is repeated
            while(existingAccounts.Contains(accountNumber))
            {
                accountNumber = rnd.Next(1, int.MaxValue);
            }

            return accountNumber;
        }

        public static bool IsMinimuAmountLeftAfterWithdrawal(decimal balance, decimal amount)
        {
            return balance - amount > Constants.minAmountAllowed;
        }

        public static bool IsBalanceGreterThan90PercentOfAmount(decimal balance, decimal amount)
        {
            return (balance * .9M) > amount;
        }

        public static bool IsBalanceGreaterThanAmount(decimal balance, decimal amount)
        {
            return balance > amount;
        }

        public static bool IsValidTransactionAmountToBeDeposited(decimal amount)
        {
            return amount < Constants.maxAmountAllowed;
        }
        #endregion
    }
}
