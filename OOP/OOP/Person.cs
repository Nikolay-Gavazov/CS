using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public void SendMessage(Person recipient, string message)
        {
            Message msg = new Message(this, recipient, message);
            Archive.AddMessage(msg);
        }
    }
}
