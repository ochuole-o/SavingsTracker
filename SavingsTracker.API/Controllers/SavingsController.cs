using Microsoft.AspNetCore.Mvc;
using SavingsTracker.API.Services;
using System.Security.Principal;

namespace SavingsTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavingsController : ControllerBase
    {

        public SavingsController()
        {
        }


        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] SavingsService.WithdrawalRequestDto request)
        {
            var _savingService = new SavingsService();
            var result = await _savingService.Withdraw(request);
            if (result.Amount > 0.1m) return Ok(result);
            if(result.AccountNumber.Length == 10) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("generate")]

        public async Task<IActionResult> GenerateAccountNumber()
        {
            var _savingService = new SavingsService();
            var accountNumber = await _savingService.GenerateAccountNumber();
            return Ok(accountNumber);
        }

        [HttpGet("deposit")]

        public IActionResult Deposit()
        {
            var _savingService = new SavingsService();
            var expiryDate = _savingService.GenerateAccountNumber().Result.ExpiryDate;
            _savingService.Deposit();

            if (expiryDate == DateTime.Now)
            {
                return BadRequest("Deposit failed");
            }
            return Ok("Deposit successful");
        }
    }
}