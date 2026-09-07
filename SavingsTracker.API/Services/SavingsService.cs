namespace SavingsTracker.API.Services
{
    public class SavingsService : ISavingsService
    {
        static decimal balance = 0;

        static string accountNumber = "7046751015";

        static List<string> transactionHistory = new List<string>();

        public class DepositRequestDto
        {
            public decimal Amount { get; set; }
            public bool Status { get; set; }

            public string ResponseCode { get; set; }

            public string Message { get; set; }

            public decimal Balance { get; set; }

        }

        public async Task<DepositRequestDto> Deposit(DepositRequestDto request)
        {
            if (request.Amount <= 0)
            {
                return new DepositRequestDto
                {
                    Status = false,
                    ResponseCode = "99",
                    Message = "Please enter a positive amount.",
                    Balance = balance
                };
            }

            balance += request.Amount;

            transactionHistory.Add($"Deposited: {request.Amount:C}");

            return new DepositRequestDto
            {
                Status = true,
                ResponseCode = "00",
                Message = $"Successfully deposited {request.Amount:C}",
                Balance = balance
            };
        }

        public class VirtualAccountNumber
        {
            public string AccountNumber { get; set; } = string.Empty;

            public DateTime ExpiryDate { get; set; } = DateTime.Now.AddHours(2);
        }


        public async Task<VirtualAccountNumber> GenerateAccountNumber()
        {
            return new VirtualAccountNumber { AccountNumber = GenerateAccount() };
        }

        public string GenerateAccount()
        {
            Random random = new Random(); return random.Next(1000000000, 2000000000).ToString();
        }

        public class WithdrawalRequestDto
        {
            public decimal Amount { get; set; }

            public string AccountNumber { get; set; } = accountNumber;
        }

        public async Task<WithdrawalRequestDto> Withdraw(WithdrawalRequestDto request)
        {
            Console.Write("Enter amount to withdraw: ");

            decimal amount;

            if (!decimal.TryParse("2000", out amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return new WithdrawalRequestDto
                {
                    Amount = 0,
                    AccountNumber = accountNumber
                };
            }

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                return new WithdrawalRequestDto
                {
                    Amount = 0,
                    AccountNumber = accountNumber
                };

            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return new WithdrawalRequestDto
                {
                    Amount = 0,
                    AccountNumber = accountNumber
                };

            }

            balance -= amount;
            transactionHistory.Add($"Withdrew: {amount:C}");
            Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {balance:C}");
            return new WithdrawalRequestDto
            {
                Amount = amount,
                AccountNumber = accountNumber
            };


        }
        public class WithdrawalResponseDto
        {
            public bool Status { get; set; }
            public string ResponseCode { get; set; }
        }

        public async Task<WithdrawalResponseDto> Withdraw()
        {
            Console.Write("Enter amount to withdraw: ");

            decimal amount;

            if (!decimal.TryParse("2000", out amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return new WithdrawalResponseDto
                {
                    Status = false,
                    ResponseCode = "99"
                };
            }

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                return new WithdrawalResponseDto
                {
                    Status = false,
                    ResponseCode = "99"
                };

            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return new WithdrawalResponseDto
                {
                    Status = false,
                    ResponseCode = "99"
                };

            }

            balance -= amount;
            transactionHistory.Add($"Withdrew: {amount:C}");
            Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {balance:C}");
            return new WithdrawalResponseDto
            {
                Status = true,
                ResponseCode = "00"
            };


        }
        public decimal CheckBalance()
        {
            return balance;
        }

        public async Task<List<string>> ViewTransactionHistory()
        {
            return transactionHistory;
        }

        public async Task<string?> ViewSingleHistory(int number)
        {
            if (number <= 0 || number > transactionHistory.Count)
            {
                return null;
            }

            return transactionHistory[number - 1];
        }


    }
}

