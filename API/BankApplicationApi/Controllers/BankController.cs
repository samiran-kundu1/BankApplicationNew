using BusinessLayer.Interface;
using BusinessLayer.Service;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace BankApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        #region Private Members

        //Dependency Injection
        IBankService _bankService;

        #endregion

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet(Name = "GetBankUsers")]
        public IActionResult GetUsers()
        {

            try
            {
                return Ok(_bankService.GetUserList());
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
            
            //return Ok(bankService.GetUserList());
        }



        [HttpGet]
        //[HttpGet("{id}")]
        [Route("GetUserAccount")]
        public IActionResult GetUserAccount(int userId)
        {
            try
            {
                return Ok(_bankService.GetUserAccountList(userId));
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
        
        [HttpPost]
        //[HttpGet("{id}")]
        [Route("CreateAccount")]
        public IActionResult CreateUserAccount(int userId,decimal amount = 100)
        {
            try
            {
                return Ok(_bankService.CreateUserAccount(userId, amount));
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
        
        [HttpDelete]
        //[HttpGet("{id}")]
        [Route("DeleteAccount")]
        public IActionResult DeleteUserAccount([FromBody] Account account)
        {
            try
            {
                return Ok(_bankService.DeleteUserAccount(account.UserId, account.AccountId));
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
