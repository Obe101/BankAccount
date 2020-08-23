using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;
        //Run code before eachh test
        public void initialize()
        {
            acc = new Account();
        }
        [TestMethod]
        //[TestCategory("Deposit")]
        [DataRow(10_000)]
        [DataRow(1234.12)]
        [DataRow(10000.01)]
        [DataRow(double.MaxValue)]
        public void Deposit_TooLarge_ThrowArgumentException(double tooLargeDeposit)
        {
            

            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
        }

        [TestMethod()]
        //[TestCategory("Deposit")]
        [DataRow(100)]
        [DataRow(9999.99)] //max deposit
        [DataRow(.01)] //min deposit
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            //AAA - Arrange Act Assert

            //Arrange - Creating variables/objects
            
            const double startingBalance = 0;

            // Act - Execute method under test
            acc.Deposit(initialDeposit);

            // Assert = Check a condition
            Assert.AreEqual(startingBalance + initialDeposit, acc.Balance);
        }

        [TestMethod()]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            //Arrange
           
            double initialBalance = 0;
            double depositAmount = 10.55;

            //Act
            double newBalance = acc.Deposit(depositAmount);

            //Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);
        }
        [TestMethod]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance() 
        {
            ///Arrange
           
            double deposit1 = 10;
            double deposit2 = 35;
            double expectedBalance = deposit1 + deposit2;

            ///Act
            acc.Deposit(deposit1);
            double finalBalance = acc.Deposit(deposit2);

            ///Assert
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        //Test for negative deposits
        [TestMethod]
        public void Deposit_NegativeAmounts_ThrowArgumentException()

        {
            //Arrangeserr4
           
            double negativeDeposit = -100;

            //Assert => Act
            Assert.ThrowsException<ArgumentException>
                (
                    () => acc.Deposit(negativeDeposit)
                );
        }
        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void WithDraw_PositiveAmount_SubtractsFromBalance( double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }
        [TestMethod]
        public void WithDraw_MoreThanBalance_ThrowArgumentException()
        {
            Account myAccount = new Account();
            //An account created with the default constructor has a zero balance
            double withDrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withDrawAmount));
        }
        [TestMethod]
        public void WithDraw_NegativeAmout_ThrowArgumentException()
        {
            Account myAccount = new Account();
            double withDrawAmount = -1;

            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withDrawAmount));
        }
    }
}