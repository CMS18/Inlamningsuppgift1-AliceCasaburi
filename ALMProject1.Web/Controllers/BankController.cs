using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMProject1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALMProject1.Web.Controllers
{
    public class BankController : Controller
    {
        BankRepository bank = new BankRepository();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(int accountId, decimal amount)
        {
            if (CheckAccountExists(accountId))
            {
                try
                {
                    bank.Deposit(amount, accountId);
                    var account = bank.Accounts.SingleOrDefault(x => x.AccountId == accountId);
                    TempData["Message"] = $"New balance: {account.Balance} $";
                }
                catch
                {
                    TempData["Message"] = "Invalid amount";
                }
            }
            else
            {
                TempData["Message"] = "Insert valid account number";
            }

           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Withdraw(int accountId, decimal amount)
        {
            if (CheckAccountExists(accountId))
            {
                try
                {
                    bank.Withdraw(amount, accountId);
                    var account = bank.Accounts.SingleOrDefault(x => x.AccountId == accountId);
                    TempData["Message"] = $"New balance: {account.Balance} $";
                }
                catch
                {
                    TempData["Message"] = "Invalid amount";
                }

            }
            else
            {
                TempData["Message"] = "Insert valid account number";
            }



            return RedirectToAction("Index");
        }

        public bool CheckAccountExists(int accountId)
        {
            return bank.Accounts.Any(x => x.AccountId == accountId);
        }
    }
}