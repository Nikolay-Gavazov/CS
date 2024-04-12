using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class CreditAccount : SavingsAccount
    {
        public CreditAccount(string name, decimal balance) : base(name, balance)
        {  

        }

        public override void GetCredit(decimal creditAmount, Customer obj)
    {
        decimal totalCreditAmount;
        if(obj.age >= 65)
            {
                totalCreditAmount = creditAmount + creditAmount * (decimal)0.06;
            }
            else
            {
                totalCreditAmount = creditAmount + creditAmount * (decimal)0.08;
            }
        Console.WriteLine($"The Credit amount is ${totalCreditAmount} and the person is {obj.firstName} ");
    }
}
}
