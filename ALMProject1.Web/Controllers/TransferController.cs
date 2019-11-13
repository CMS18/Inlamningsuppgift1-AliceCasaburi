using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMProject1.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALMProject1.Web.Controllers
{
    public class TransferController : Controller
    {
        BankRepository bank = new BankRepository();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int accountIdFrom, int accountIdTo, decimal amount)
        {
            if (CheckAccountExists(accountIdFrom) && CheckAccountExists(accountIdTo))
            {
                try
                {
                    bank.Transfer(accountIdFrom, accountIdTo, amount);
                    var accountFrom = bank.Accounts.SingleOrDefault(x => x.AccountId == accountIdFrom);
                    var accountTo = bank.Accounts.SingleOrDefault(x => x.AccountId == accountIdTo);
                    TempData["Message"] = $"New balance for account {accountFrom.AccountId}: {accountFrom.Balance} $" +
                        $" New balance for account {accountTo.AccountId}: {accountTo.Balance} $";
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
