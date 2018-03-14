using System;

namespace banking_app_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Banking();
            bank.Run();
        }
    }

    class Banking
    {
        private double Balance { get; set; }

        public static string Greet()
        {
            return "Login successful! Welcome to Toi Bank of NZ Please enter the amount of your opening balance:";
        }

        public string InitialBalance()
        {
            var newBalance = GetBalanceInput();
            if (newBalance < 500)
            {
                return "Opening balance must be at least $500. Please reopen the program to try again";
            }
            else
            {
                Balance = newBalance;
                return "Success, your opening balance is $" + Balance;
            }
        }

        public string DisplayBalance()
        {
            return "Your current balance is $" + Balance;
        }

        public string ProcessWithdrawal()
        {
            var toWithdraw = GetBalanceInput();

            if (toWithdraw > Balance)
            {
                return "Cannot withdraw more than you have in the account";
            }
            else
            {
                Balance -= toWithdraw;
                return "Success. New Balance is $" + Balance;
            }
        }

        public string ProcessDeposit()
        {
            Balance += GetBalanceInput();
            return "Success. New Balance is $" + Balance;
        }

        public double GetBalanceInput()
        {
            var isNum = true;
            var balanceInput = 0.0;
            do
            {
                if (!isNum || balanceInput < 0)
                {
                    Console.WriteLine("Invalid input. Please try again: ");
                }
                isNum = double.TryParse(Console.ReadLine(), out balanceInput);
            } while (!isNum || balanceInput < 0);

            return balanceInput;
        }

        public void LoadMenu()
        {
            var option = 0.0;

            do
            {
                Console.WriteLine("\n\nPlease choose from the following options:");
                Console.WriteLine("1. Process withdrawal");
                Console.WriteLine("2. Process deposit");
                Console.WriteLine("3. Balance request");
                Console.WriteLine("0. End Program");
                Console.WriteLine("Enter option number:");
                do
                {
                    if (option < 0 || option > 3)
                    {
                        Console.WriteLine("Invalid option. Please enter a number between 0 and 3");
                    }
                    option = GetBalanceInput();
                } while (option < 0 || option > 3);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nEnter amount to withdraw: ");
                        Console.WriteLine(ProcessWithdrawal());
                        break;
                    case 2:
                        Console.WriteLine("\nEnter amount to deposit: ");
                        Console.WriteLine(ProcessDeposit());
                        break;
                    case 3:
                        Console.WriteLine(DisplayBalance());
                        break;
                }


            } while (option != 0);
        }

        public void Run()
        {
            Console.WriteLine(Greet());
            Console.WriteLine(InitialBalance());
            if (Balance >= 500)
                LoadMenu();
        }
    }
}
