using System;
using System.Threading;

namespace SingletonePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Thread(() =>
            {
                Singleton s1 = Singleton.Instance;
                Console.WriteLine(s1.Date);
            })).Start();

            Singleton s2 = Singleton.Instance;

            Console.WriteLine(s2.Date);
        }
    }

    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public string Date { get; set; }

        private Singleton()
        {
            if (instance != null)
            {
                Console.WriteLine("Already created object");
            }

            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton Instance
        {
            get
            { 
                return instance;
            }
        }
    }
}
