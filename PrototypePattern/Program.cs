using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicCar nano_base = new Nano("Green Nano") { Price = 100000 };

            BasicCar ford_base = new Ford("Ford Yellow") { Price = 500000 };

            BasicCar bc1;

            bc1 = nano_base.Clone();

            bc1.Price = BasicCar.SetPrice();

            Console.WriteLine($"Car is : {bc1.ModelName}, and it's price is {bc1.Price}");
        }
    }

    public abstract class BasicCar
    {
        public string ModelName { get; set; }

        public int Price { get; set; }

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
        }

        public override BasicCar Clone()
        {
            return (Ford)this.MemberwiseClone();
        }
    }
}
