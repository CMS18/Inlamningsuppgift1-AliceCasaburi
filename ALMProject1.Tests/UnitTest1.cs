using ALMProject1.Web.Models;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ALMProject1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
           var bank = new BankRepository();
           

           var account = bank.Accounts.SingleOrDefault(x => x.AccountId == 1);
           var balanceBelore = account.Balance;

           bank.Deposit(100, 1);

           var result = account.Balance;

           Assert.AreEqual((balanceBelore + 100), result);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            var bank = new BankRepository();


            var account = bank.Accounts.SingleOrDefault(x => x.AccountId == 1);
            var balanceBelore = account.Balance;

            bank.Withdraw(100, 1);

            var result = account.Balance;

            Assert.AreEqual((balanceBelore - 100), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAmountTooHigh()
        {
            var bank = new BankRepository();
            bank.Withdraw(100000, 1);
        }
    }
}
