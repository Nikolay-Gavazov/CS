using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Message
    {
        public Person Sender { get; }
        public Person Receiver { get; }
        public string Content { get; }

        public Message(Person sender, Person receiver, string content)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Content = content;
        }
    }
}
