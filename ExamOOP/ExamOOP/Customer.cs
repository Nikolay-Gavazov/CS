using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class Customer
    {
        public int age = 55;
        public string firstName = "Ivan";

        public Customer(int age, string firstName)
        {
            this.age = age;
            this.firstName = firstName;
        }
    }
}
