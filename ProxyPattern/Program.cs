using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public interface ISubject
    {
        public void GetInfo();
    }

    public class ConcreteSubject : ISubject
    {
        private string importantData = "Ax8G551nah3";

        public void GetInfo()
        {
            Console.WriteLine($"Important data is {importantData}");
        }
    }

    public class Proxy : ISubject
    {
        private ConcreteSubject concreteSubject;

        private Dictionary<string, int> allowedUsers = new()
        {
            ["Iliya"] = 1234,
            ["Alex"] = 3291
        };

        private Dictionary<string, int> currentUsers;

        public Proxy(Dictionary<string, int> currentUsers)
        {
            this.currentUsers = currentUsers;
        }

        public void GetInfo()
        {
            foreach (var item in currentUsers)
            {
                Console.WriteLine("Proxy call happening here...");
                Console.WriteLine($"{item.Key} wants to invoke a proxy method.");

                if (allowedUsers.ContainsKey(item.Key) & allowedUsers.ContainsValue(item.Value))
                {
                    if (concreteSubject==null)
                    {
                        concreteSubject = new ConcreteSubject();
                    }

                    concreteSubject.GetInfo();
                }
                else
                {
                    Console.WriteLine($"{item.Key} does not allowed to get a resources.");
                }


                Console.WriteLine("End of Proxy call.");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> users = new Dictionary<string, int>
            {
                ["Iliya"] = 1234,
                ["Aboba"] = 3245
            };

            Proxy proxy = new Proxy(users);

            proxy.GetInfo();
        }
    }

}
