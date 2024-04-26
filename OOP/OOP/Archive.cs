using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Archive
    {
        private static List<Message> messages = new List<Message>();

        public static void AddMessage(Message message)
        { 
            messages.Add(message);
            Console.WriteLine("Message is send!");
        }

        public static void DisplayArchive()
        {
            Console.WriteLine("Message Archive:");
            foreach (Message message in messages)
            {
                Console.WriteLine($"from: {message.Sender.Name}, to: {message.Receiver.Name}, Content: {message.Content}");
            }
        }
    }
}
