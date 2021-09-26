using System;
using System.Linq;
using System.Threading;

namespace ProxyPattern
{
    /// <summary>
    /// Abstract class Subject
    /// </summary>
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }

    public class ConcreteSubject : Subject
    {
        private static readonly ConcreteSubject concreteSubject = new ConcreteSubject();

        private ConcreteSubject()
        {

        }

        public static ConcreteSubject GetInstance
        {
            get
            {
                return concreteSubject;
            }
        }

        public override void DoSomeWork()
        {
            Console.WriteLine("ConcreteSubject.DoSomeWork()");
        }
    }

    public class Proxy : Subject
    {
        Subject cs;

        string[] registeredUsers;
        string currentUser;

        public Proxy(string currentUser)
        {
            registeredUsers = new string[] { "Admin", "Rohit", "Sam" };

            this.currentUser = currentUser;
        }

        public override void DoSomeWork()
        {
            Console.WriteLine("Proxy call happening now...");

            Console.WriteLine($"{currentUser} wants to invoke a proxy");

            if (registeredUsers.Contains(currentUser))
            {
                cs = ConcreteSubject.GetInstance;

                cs.DoSomeWork();
            }
            else
            {
                Console.WriteLine($"Sorry {currentUser}, you do not have access.");
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            (new Thread(() =>
           {
               Proxy proxy1 = new Proxy("Aboba");

               proxy1.DoSomeWork();
           })).Start();

            Proxy proxy = new Proxy("Admin");

            proxy.DoSomeWork();
        }
    }
}
