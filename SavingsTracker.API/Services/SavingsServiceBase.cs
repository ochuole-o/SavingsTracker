namespace SavingsTracker.API.Services
{
    public class SavingsServiceBase
    {

        public async Task<DepositResponseDto> Deposit(DepositRequestDto request)
        {
            if (request.Amount <= 0)
            {
                return new DepositResponseDto
                {
                    Status = false,
                    ResponseCode = "99",
                    Message = "Please enter a positive amount.",
                    Balance = balance
                };
            }

            balance += request.Amount;

            transactionHistory.Add($"Deposited: {request.Amount:C}");

            return new DepositResponseDto
            {
                Status = true,
                ResponseCode = "00",
                Message = $"Successfully deposited {request.Amount:C}",
                Balance = balance
            };
        }
    }
}