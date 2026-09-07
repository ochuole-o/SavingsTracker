using static SavingsTracker.API.Services.SavingsService;

namespace SavingsTracker.API.Interfaces
{
    public interface ISavingsService
    {
        DepositRequestDto Deposit(DepositRequestDto request);
        WithdrawalResponseDto Withdraw(WithdrawalRequestDto request);
        decimal CheckBalance();
    }
}
