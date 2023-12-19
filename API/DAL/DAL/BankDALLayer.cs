using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedData.TestData;
using DAL.IDAL;
using SharedData.Helpers;

namespace DAL.DAL
{
    public class BankDALLayer : IBankDAL
    {
        
        public List<User> GetUserList()
        {
            return DummyTestClass.users;
        }
        
        public List<Account> GetUserAccountList(int userId)
        {
            //Each User Has List Of Accounts,process is to first to get all list and then filter according to condition specified
            return DummyTestClass.GetAccounts(userId);
        }
        
        public List<Account> CreateUserAccount(int userId,decimal amount)
        {
            //Each User Has List Of Accounts,process is to first to get all list and then filter according to condition specified
            var accountList = DummyTestClass.GetAccounts(userId);
            var maxAccountId =  DummyTestClass.GetAccounts(userId).Max(x=>x.AccountId);

            //Get all the account numbers of the user
            var accountNumberList = accountList.Select(x=>x.AccountNumber).ToList();
            accountList.Add(
                new Account()
                {
                    UserId = userId,
                    Balance = amount,
                    AccountId = maxAccountId + 1,
                    AccountNumber = Helper.CreateAccountNumber(accountNumberList),
                }
                );
            return accountList;
        }
        
        public List<Account> DeleteUserAccount(int userId,int accntId)
        {
            //Each User Has List Of Accounts,process is to first to get all list and then filter according to condition specified
            var accountList =  DummyTestClass.GetAccounts(userId);
            Account? accountToBeRemoved = accountList.Where(act => act.AccountId == accntId).FirstOrDefault();
            if (accountToBeRemoved != null)
            {
                accountList.Remove(accountToBeRemoved);

            }
            return accountList;
        }


     
    }
}
