using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class Account
    {
        double Tempamount { get; set; }
        Account account2;

        /*Balance ska vara kontots saldo.Använd egenskapen för att kontrollera vad saldot är efter varje funktionsanrop.Man ska inte kunna ändra saldot via egenskapen, bara genom klassens metoder.Behöver inte testas.*/
        private double Balance { get; set; }

        /*Konstruktorn ska anropas med det värde ni vill att kontot ska ha från början. (Om ni gör VG-versionen så ska räntesatsen också vara en parameter.)*/
        public Account()
        {
            Balance = 10000.00;

            //account2 = new Account();
            //account2.Balance = 5000.00;
        }

        #region Deposit

        /*Ökar saldot på kontot med amount.Alla double-tal som rimligtvis kan tänkas motsvara ett pengabelopp är tillåtna värden. Om funktionen får ett otillåtet double-tal som parameter ska den kasta ett Exception med ett lämpligt felmeddelande.*/

        void Deposit(double amount)
        {
            Balance += amount;
        }

        [Fact]
        public void EnterDeposit()
        {
            Tempamount = 150.00;

            bool tempcorrectinput = IsDepositable(Tempamount);

            Assert.True(tempcorrectinput);
            Deposit(Tempamount);

            Tempamount = 0;
        }

        public bool IsDepositable(double amount)
        {
            if (!(amount < 1))
            {
                return true;
            }
            else
            {
                throw new Exception("The value you entered is too low.");
                //return false;
            }
        }

        #endregion

        #region Transfer
        /*Minskar saldot på kontot med amount och ökar med motsvarande belopp på mottagarkontot, förutsatt att inget har gått fel. Men det finns ganska många anledningar till att det kan gå fel.*/
        bool Transfer(Account target, double amount)
        {
            Balance -= amount;
            target.Balance += amount;

            return false;
        }

        [Fact]
        public void ExecuteTansfer()
        {
            double amountToTransfer = 2000.00;
            bool istrueorfalse = CheckIfDoubleIsAboveOne(amountToTransfer);

            try
            {
                Assert.NotNull(account2);
            }
            catch
            {
                throw new Exception("That account doesn't exist");
            }

            try
            {

                Assert.True(istrueorfalse);
            }
            catch
            {
                throw new Exception("Transfer value is too low.");
            }

            Transfer(account2, amountToTransfer);
        }

        bool CheckIfDoubleIsAboveOne(double value)
        {
            if (value > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Withdraw

        /*Minskar saldot på kontot med amount, förutsatt att det finns tillräckligt med pengar på kontot.Om det inte gör det ska funktionen inte dra några pengar utan i stället kasta ett Exception med ett lämpligt felmeddelande.Samma sak om amount är ett otillåtet double-tal.*/

        void Withdraw(double amount)
        {
            Balance -= amount;
        }

        [Fact]
        public void EnterWithdraw()
        {
            Tempamount = 500;

            bool isthereenoughmoneytoextract = IsWithdrawable(Tempamount);

            try
            {
                Assert.True(isthereenoughmoneytoextract);
            }
            catch
            {
                throw new Exception("The value you entered is not correct");
            }

            Withdraw(Tempamount);

            Tempamount = 0;
        }

        public bool IsWithdrawable(double amount)
        {
            if (amount > 0)
            {
                if (amount > Balance)
                {
                    throw new Exception("Insufficient funds");
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
