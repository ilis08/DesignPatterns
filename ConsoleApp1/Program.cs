using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<Singleton>> tasks = new();

            for (int i = 0; i < 100; i++)
            {
                tasks.Add(new Task<Singleton>(
                    () =>
                    {
                        return Singleton.Instance;
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

            Console.WriteLine(Singleton.instances);
        }
    }

    public sealed class Singleton
    {
        private static volatile Singleton instance;

        public string Date { get; set; }

        private static object obj = new object();

        private Singleton()
        {
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            ++instances;
                            instance = new Singleton();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Object is already created");
                }

                return instance;
            }
        }

        public static int instances = 0;
    }
}
