class Program
{
    static decimal balance = 0;
    static List<string> transactionHistory = new List<string>();
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            DisplayChoices();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Deposit();
                    break;
                case "2":
                    Withdraw();
                    break;
                case "3":
                    CheckBalance();
                    break;
                case "4":
                    ViewTransactionHistory();
                    break;
                case "5":
                    ViewSingleHistory();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
            }

        }
    }

    static void DisplayChoices()
    {
        Console.Clear();
        Console.WriteLine("---Savings Tracker---");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Check Balance");
        Console.WriteLine("4. View Transaction History");
        Console.WriteLine("5. View Single Transaction");
        Console.WriteLine("6. Exit");
    }

    static void Deposit()
    {
        Console.Write("Enter amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            transactionHistory.Add($"Deposited: {amount:C}");
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
        }
    }

    static void Withdraw()
    { 
        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine();

        decimal amount;

        if (!decimal.TryParse(input, out amount))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        if(amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
            return;
        }
        
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        balance -= amount;
        transactionHistory.Add($"Withdrew: {amount:C}");
        Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {balance:C}");

    }
    static void CheckBalance()
    {
        Console.WriteLine($"Current balance: {balance:C}");
    }

    static void ViewTransactionHistory()
    {
        Console.WriteLine("Transaction History:");
        foreach (string transaction in transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }

    static void ViewSingleHistory()
    {
        Console.WriteLine("Please enter the index of the transaction you want to view:");
        string number = Console.ReadLine();

        if (int.TryParse(number, out int num))
        { if(!transactionHistory.Any())
            {
                Console.WriteLine("No transactions to display.");
                return;
            }
            if (transactionHistory.Count() >= num)
            {
                Console.WriteLine(transactionHistory[(num - 1)]);
            }
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }
}
