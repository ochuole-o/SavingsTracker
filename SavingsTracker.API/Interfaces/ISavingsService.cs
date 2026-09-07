namespace SavingsTracker.API.Services
{
    public interface ISavingsService
    {
        decimal CheckBalance();
        Task<SavingsService.DepositRequestDto> Deposit(SavingsService.DepositRequestDto request);
        string GenerateAccount();
        Task<SavingsService.VirtualAccountNumber> GenerateAccountNumber();
        Task<string?> ViewSingleHistory(int number);
        Task<List<string>> ViewTransactionHistory();
        Task<SavingsService.WithdrawalResponseDto> Withdraw();
        Task<SavingsService.WithdrawalRequestDto> Withdraw(SavingsService.WithdrawalRequestDto request);
    }
}