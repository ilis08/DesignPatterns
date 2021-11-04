using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyPattern
{

    public abstract class Subject
    {
        public abstract void GetInfo();
    }

    public class ConcreteSubject : Subject
    {
        private readonly string secretInfo = "XWH918MAD";

        public override void GetInfo()
        {
            Console.WriteLine($"Secret info is {secretInfo}");
        }
    }

    public class Proxy : Subject
    {
        private Dictionary<string, string> usersAvailable = new()
        {
            ["Admin"] = "a8a8",
            ["Iliya"] = "ilis08"
        };

        public Dictionary<string, string> userRequestData;

        private ConcreteSubject subject;

        public Proxy(Dictionary<string, string> dict)
        {
            userRequestData = dict;
        }

      
        public override void GetInfo()
        {
            foreach (var item in userRequestData)
            {
                Console.WriteLine("Proxy call");

                if (usersAvailable.ContainsKey(item.Key) && usersAvailable.ContainsValue(item.Value))
                {
                    if (subject == null)
                    {
                        subject = new ConcreteSubject();
                    }

                    subject.GetInfo();
                }
                else
                {
                    Console.WriteLine($"Sorry {item.Key}, you don't have permission to get value");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> users = new()
            {
                ["Admin"] = "a8a8",
                ["Aboba"] = "abpdsafa",
                ["Ivan"]="4asv9m"
            };

            Proxy proxy = new Proxy(users);

            proxy.GetInfo();
           

        }
    }
}
