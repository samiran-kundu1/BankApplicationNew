using BusinessLayer.Interface;
using DAL.DAL;
using DAL.IDAL;
using SharedData.Helpers;
using SharedData.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class TransactionService : ITransactionService
    {
        #region Private Members

        ITransactionDALLayer _transactionDALLayer;

        #endregion



        public TransactionService(ITransactionDALLayer _transactionDALLayer)
        {
            this._transactionDALLayer = _transactionDALLayer;
        }

        public decimal DepositAmountInAccount(int userId, int acctId, decimal amount)
        {
            if (Helper.IsValidTransactionAmountToBeDeposited(amount))
            {
                var balance = _transactionDALLayer.DepositAmountInAccount(userId, acctId, amount);
                return balance;
            }
            return Convert.ToDecimal(Constants.DepositCodes.invalidAmount);
        }

        public decimal WithDrawAmountInAccount(int userId, int acctId, decimal amount)
        {
            var balance = _transactionDALLayer.GetBalanceInAccount(userId, acctId);

            if (!Helper.IsBalanceGreaterThanAmount(balance, amount))
            {
                return Convert.ToDecimal(Constants.WithdrawCodes.amountGreaterThanAccountBalance);
            }
            if (!Helper.IsBalanceGreterThan90PercentOfAmount(balance, amount))
            {
                return Convert.ToDecimal(Constants.WithdrawCodes.moreThan90Percent);
            }
            if (!Helper.IsMinimuAmountLeftAfterWithdrawal(balance, amount))
            {
                return Convert.ToDecimal(Constants.WithdrawCodes.depositLeftWithLessThan100);
            }
            return balance - amount;
        }



    }
}
