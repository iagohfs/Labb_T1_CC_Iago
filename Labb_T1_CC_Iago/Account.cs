using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Labb_T1_CC_Iago
{
    public class Account
    {
        /*Balance ska vara kontots saldo.Använd egenskapen för att kontrollera vad saldot är efter varje funktionsanrop.Man ska inte kunna ändra saldot via egenskapen, bara genom klassens metoder.Behöver inte testas.*/
        public double Balance { get; private set; }
        bool ExitBank { get; set; }
        //double initialBalance
        //double DepositAmmount { get; set; }


        /*Konstruktorn ska anropas med det värde ni vill att kontot ska ha från början. (Om ni gör VG-versionen så ska räntesatsen också vara en parameter.)*/
        public Account()
        {
            //Balance = initialBalance;
            Balance = 10000;
            ExitBank = false;
        }

        void ChooseAmmount()
        {
            Console.WriteLine("Choose Ammount to " +
                "1. 100\n" +
                "2. 200\n" +
                "3. 500\n" +
                "4. 1000 ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Withdraw(100.0);
                    break;

                case ConsoleKey.D2:
                    Withdraw(200.0);
                    break;

                case ConsoleKey.D3:
                    Withdraw(500.0);
                    break;

                case ConsoleKey.D4:
                    Withdraw(1000.0);
                    break;
            }
        }

        /*Ökar saldot på kontot med amount.Alla double-tal som rimligtvis kan tänkas motsvara ett pengabelopp är tillåtna värden.Om funktionen får ett otillåtet double-tal som parameter ska den kasta ett Exception med ett lämpligt felmeddelande.*/
        void Deposit(double amount)
        {
            Balance += amount;
        }

        double EnterDepositAmmount(double DepositAmmount)
        {
            return DepositAmmount;
        }

        void TestDeposit()
        {
            Console.WriteLine("Max deposit value is 10000");
            //Assert.Equal(10000.0, EnterDepositAmmount(double.Parse(Console.ReadLine())));
            //Assert.Equal(10000.0, 10000.1);
        }

        void Run()
        {
            while (!ExitBank)
            {
                Console.WriteLine("Welcome to Your Account!, What would you like to do today?\n" +
                    "1. Balance\n" +
                    "2. Withdraw\n" +
                    "3. Deposit\n" +
                    "4. Transfer");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        ShowBalance();
                        break;

                    case ConsoleKey.D2:
                        break;

                    default:
                        break;
                }
            }
        }

        void ShowBalance()
        {
            Console.WriteLine("Your Balance is {0}", Balance);
        }

        /*Minskar saldot på kontot med amount och ökar med motsvarande belopp på mottagarkontot, förutsatt att inget har gått fel. Men det finns ganska många anledningar till att det kan gå fel.*/
        bool Transfer(Account target, double amount)
        {
            return false;
        }

        /*Minskar saldot på kontot med amount, förutsatt att det finns tillräckligt med pengar på kontot.Om det inte gör det ska funktionen inte dra några pengar utan i stället kasta ett Exception med ett lämpligt felmeddelande.Samma sak om amount är ett otillåtet double-tal.*/

        void Withdraw(double amount)
        {
            try
            {
                if (amount < Balance)
                {
                    Balance -= amount;
                }
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        [Fact]
        public void Testing()
        {
            Assert.Equal(2, Add(1, 1));
        }

        int Add(int one, int two)
        {
            return (one + two);
        }

    }
}
