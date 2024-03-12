using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class ChatHistory
    {
        private static List<Message> messages = new List<Message>();

        public static void AddMessage(Message message)
        { 
            messages.Add(message);
        }

        public static void PrintChats()
        {
            foreach (var message in messages)
            {
                Console.WriteLine($"from:{message.Sender.Titel} {message.Sender.Name}\nContent: {message.Content}\n-----");
            }
        }
    }
}
