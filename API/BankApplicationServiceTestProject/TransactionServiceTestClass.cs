

namespace BankApplicationServiceTestProject
{
    [TestClass]
    public class TransactionServiceTestClass
    {
        #region Test cases to Deposit Amount
        [TestMethod]
        public void DepositAmountInAccountTestForInvalidAmount()
        {
            TransactionService transactionService = new TransactionService(new TransactionDALLayer());
            var result = transactionService.DepositAmountInAccount(1, 1, 10000000);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void DepositAmountInAccountTestForAmount()
        {
            TransactionService transactionService = new TransactionService(new TransactionDALLayer());
            var result = transactionService.DepositAmountInAccount(1, 1, 100);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 200);
        }
        #endregion

        #region Test cases to Withdraw Amount

        [TestMethod]
        public void WithdrawAmountInAccountTestForInvalidAmount()
        {
            TransactionService transactionService = new TransactionService(new TransactionDALLayer());
            var result = transactionService.WithDrawAmountInAccount(1, 1, 95);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, -2);
        }

        [TestMethod]
        public void WithdrawAmountInAccountWithLessThan100TestForAmount()
        {
            TransactionService transactionService = new TransactionService(new TransactionDALLayer());
            var result = transactionService.WithDrawAmountInAccount(1, 1, 10);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, -3);
        } 
        
        [TestMethod]
        public void WithdrawAmountInAccountTestForAmount()
        {
            TransactionService transactionService = new TransactionService(new TransactionDALLayer());
            var result = transactionService.WithDrawAmountInAccount(1, 2, 10);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 990);
        } 
        #endregion
    }
}