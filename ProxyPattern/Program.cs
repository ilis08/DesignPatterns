using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyPattern
{
   
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }

    public class ConcreteSubject : Subject
    {
        public override void DoSomeWork()
        {
            Console.WriteLine(this.GetType()+" Do some work!");
        }
    }

    public class Proxy : Subject
    {
        public string currentName { get; set; }
        private string[] allowedUsers = new[] { "Iliya", "Admin", "Ivan" };

        public Proxy(string name)
        {
            currentName = name;
        }

        private ConcreteSubject subject;

        public override void DoSomeWork()
        {
            Console.WriteLine("Proxy call...");

            Console.WriteLine($"{currentName} wants to get invo!");

            if (allowedUsers.Contains(currentName))
            {
                if (subject == null)
                {
                    subject = new ConcreteSubject();
                }

                subject.DoSomeWork();
            }
            else
            {
                Console.WriteLine($"Sorry {currentName}, you don't have permission to get info!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<string> names = new List<string>()
            {
                "Iliya", "Aboba", "Sergey", "Alex", "Ivan"
            };

            List<Task> tasks = new List<Task>();

            foreach (var item in names)
            {
                tasks.Add(new Task(
                    () =>
                    {
                        Proxy proxy = new Proxy(item);
                        proxy.DoSomeWork();
                    }));
            }

            foreach (var item in tasks)
            {
                item.Start();
            }

            foreach (var item in tasks)
            {
                item.Wait();
            }

        }
    }
}
