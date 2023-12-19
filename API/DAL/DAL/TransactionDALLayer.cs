using DAL.IDAL;
using Entities.Models;
using SharedData.Helpers;
using SharedData.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class TransactionDALLayer : ITransactionDALLayer
    {
        public decimal DepositAmountInAccount(int userId, int acctId, decimal amount)
        {
            decimal balance = DummyTestClass.GetAccounts(userId)
                .SingleOrDefault(acct => acct.AccountId == acctId).Balance + amount;

            return balance;
        }


        public decimal GetBalanceInAccount(int userId, int acctId)
        {

            return DummyTestClass.GetAccounts(userId)
                .SingleOrDefault(acct => acct.AccountId == acctId).Balance;
        }


    }
}
