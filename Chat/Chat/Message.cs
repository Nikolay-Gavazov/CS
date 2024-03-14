using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Message
    {
        public Human Sender { get; }
        public Human Receiver { get; }
        public string Content { get; }

        public Message(Human sender, Human receiver, string content)
        {
            Sender = sender;
            Receiver = receiver;
            Content = content;
        }
    }
}
