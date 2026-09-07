using Microsoft.AspNetCore.Mvc;
using SavingsTracker.API.Interfaces;
using SavingsTracker.API.Services;
using System.Security.Principal;

namespace SavingsTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly ISavingsService _savingsService;

        public SavingsController(ISavingsService savingsService)
        {
            _savingsService = savingsService;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] SavingsService.DepositRequestDto request)
        {
            var result = await  _savingsService.Deposit(request);

            if (!result.Status)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] SavingsService.WithdrawalRequestDto request)
        {
            var result = await _savingsService.Withdraw(request);

            if (result.Amount <= 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("generate")]
        public async Task<IActionResult> GenerateAccountNumber()
        {
            var accountNumber = await _savingsService.GenerateAccountNumber();

            return Ok(accountNumber);
        }

        [HttpGet("balance")]
        public async Task<IActionResult> CheckBalance()
        {
            var balance = await _savingsService.CheckBalance();

            return Ok(balance);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> ViewTransactionHistory()
        {
            var transactions = await _savingsService.ViewTransactionHistory();

            return Ok(transactions);
        }

        [HttpGet("transactions/{number}")]
        public async Task<IActionResult> ViewSingleHistory(int number)
        {
            var transaction = await _savingsService.ViewSingleHistory(number);

            if (transaction == null)
            {
                return NotFound("Transaction not found.");
            }

            return Ok(transaction);
        }
    }
}