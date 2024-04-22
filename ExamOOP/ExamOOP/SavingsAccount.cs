using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class SavingsAccount
    {
        protected string owner;
        protected decimal balance;

        public SavingsAccount(string name, decimal balance)
        {
            this.owner = name;
            this.balance = balance;
        }

        public virtual void GetCredit(decimal creditAmount, Customer obj)
        {
            decimal totalCreditAmount;

            totalCreditAmount = creditAmount + creditAmount * (decimal)0.08;
            Console.WriteLine($"The Credit amount is ${totalCreditAmount} and the person is {obj.firstName} ");
        }


    }
}
