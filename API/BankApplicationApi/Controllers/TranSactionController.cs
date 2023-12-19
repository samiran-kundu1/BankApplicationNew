using BusinessLayer.Interface;
using BusinessLayer.Service;
using DAL.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranSactionController : ControllerBase
    {
        #region Private Members

        //TransactionService transactionService = new TransactionService();
        ITransactionService _transactionService;
        #endregion

        public TranSactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPut]
        [Route("Deposit")]
        public IActionResult DepositAmountInAccount(int userId, int acctId, decimal amount)
        {
            try
            {
                //if balance is -1,UI will handle the failed business logic
                var balance = _transactionService.DepositAmountInAccount(userId, acctId, amount);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                //logging logic to be added
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Some Exception Occured"

                };

                throw new System.Web.Http.HttpResponseException(response);
            }
        }
        
        [HttpPut]
        [Route("WithDraw")]
        public IActionResult WithDrawAmountInAccount(int userId, int acctId, decimal amount)
        {
            try
            {
                //If returned negative value -> one business logic failed and UI is to handle it accordingly
                //Amount Greater Than Account Balance => -1
                //More Than 90% of account balance => -2
                //deposit Left With Less Than 100 => -3
                var balance = _transactionService.WithDrawAmountInAccount(userId, acctId, amount);
                return Ok(balance);
            }
            catch (Exception ex)
            {

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Some Exception Occured"

                };

                throw new System.Web.Http.HttpResponseException(response);
            }
        }
    }
}
