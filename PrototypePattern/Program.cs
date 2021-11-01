using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicCar ford = new Ford("Ford");

            Console.WriteLine(ford.Engine.ID);


            BasicCar newFord = ford.Clone();

            Console.WriteLine(newFord.Engine.Name);

            ford.Engine.Name = "V6";

            Console.WriteLine(newFord.Engine.Name);
        }
    }

    public abstract class BasicCar
    {
        public string ModelName { get; set; }

        public int Price { get; set; }

        public Engine Engine { get; set; }

        public static int SetPrice()
        {
            int price = 0;

            Random r = new Random();

            int p = r.Next(200000, 500000);
            price = p;

            return price;
        }

        public abstract BasicCar Clone();

    }


    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
        }

        public override BasicCar Clone()
        {
            return (Nano)this.MemberwiseClone();
        }
    }

    public class Ford : BasicCar
    {
        public Ford(string m)
        {
            ModelName = m;
            Engine = new Engine("V12");
        }

        public override BasicCar Clone()
        {
            Ford newFord = (Ford)this.MemberwiseClone();

            Engine currentEngine = new Engine(this.Engine.Name);

            currentEngine.ID = this.Engine.ID;

            newFord.Engine = currentEngine;

            return newFord;
        }
    }

    public class Engine
    {
        

        public Engine(string name)
        {
            Name = name;
            ID = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid ID { get; set; }

    }
}
