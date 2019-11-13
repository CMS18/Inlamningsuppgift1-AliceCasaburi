using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMProject1.Web.Models
{
    public class BankRepository
    {
        public List<Account> Accounts { get; set; }
        public List<Customer> Customers { get; set; }

        public BankRepository()
        {
            Accounts = new List<Account>
            {
                new Account(){ Balance = 100, AccountId = 1, CustomerId = 1 },
                new Account(){ Balance = 200, AccountId = 2, CustomerId = 2 },
                new Account(){ Balance = 300, AccountId = 3, CustomerId = 3 }
            };

            Customers = new List<Customer>
            {
                new Customer(){ Name = "Jinx", CustomerId = 1, AccountId = 1 },
                new Customer(){ Name = "RuPaul", CustomerId = 2, AccountId = 2 },
                new Customer(){ Name = "Sharon", CustomerId = 3, AccountId = 3 }
            };
        }
    }
}
