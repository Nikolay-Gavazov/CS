using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Human
    {
        public string Name { get; set; }
        public string Titel { get; set; }

        public Human(string name, string titel)
        {
            Name = name;
            Titel = titel; 
        }

        public void SendMessage(Human recipient, string message)
        {
            Message msg = new Message(this, recipient, message);
            ChatHistory.AddMessage(msg);
        }
    }
}
