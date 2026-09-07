using Microsoft.AspNetCore.Mvc;
using SavingsTracker.API.Services;

namespace SavingsTracker.API.Interfaces
{
    public interface ISavingsService
    {
        Task<IActionResult> Deposit([FromBody] SavingsService.DepositRequestDto request);

        Task<SavingsService.WithdrawalRequestDto> Withdraw(SavingsService.WithdrawalRequestDto request);

        Task<SavingsService.VirtualAccountNumber> GenerateAccountNumber();

        string GenerateAccount();

        decimal CheckBalance();

        Task<List<string>> ViewTransactionHistory();

        Task<string?> ViewSingleHistory(int number);
    }
}