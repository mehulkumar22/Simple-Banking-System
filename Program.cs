using System;

class Program
{
    static string accountHolder = "John Doe";
    static string accountNumber = "123456789";
    static int pin = 1234;
    static decimal balance = 1000.00m;

    static void Main()
    {
        Console.WriteLine("=== Welcome to Simple Bank ===");
        Console.Write("Enter your PIN: ");
        int enteredPin;

        if (!int.TryParse(Console.ReadLine(), out enteredPin) || enteredPin != pin)
        {
            Console.WriteLine("Invalid PIN. Access denied.");
            return;
        }

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Simple Banking System ===");
            Console.WriteLine($"Account Holder: {accountHolder}");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckBalance();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Withdraw();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Thank you for using Simple Bank!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void CheckBalance()
    {
        Console.WriteLine($"Your current balance is: ${balance:F2}");
    }

    static void Deposit()
    {
        Console.Write("Enter deposit amount: $");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Successfully deposited ${amount:F2}");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter withdrawal amount: $");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdrew ${amount:F2}");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }
}
