using System;

namespace SimpleFactoryPattern
{
    public interface IAnimal
    {
        void Speak();
        void Action();
    }

    public class Dog : IAnimal
    {
        public void Action()
        {
            Console.WriteLine("Dog prefer barking..");
        }

        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
    }

    public class Tiger : IAnimal
    {
        public void Action()
        {
            Console.WriteLine("Tiger prefer hunting..");
        }

        public void Speak()
        {
            Console.WriteLine("Tiger says : Halum.");
        }
    }

    public abstract class ISimpleFactory
    {
        public abstract IAnimal CreateAnimal();
    }

    public class SimpleFactory : ISimpleFactory
    {
        public override IAnimal CreateAnimal()
        {
            IAnimal intendedAnimal = null;
            Console.WriteLine("Enter your choice(0 for Dog, 1 for Tiger)");

            string b1 = Console.ReadLine();

                Console.WriteLine($"You have entered {b1}");

                switch (b1)
                {
                    case "0":
                        intendedAnimal = new Dog();
                        break;
                    case "1":
                        intendedAnimal = new Tiger();
                        break;
                    default:
                        Console.WriteLine("You must enter either 0 or 1");
                        break;
                }
            

            return intendedAnimal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;

            ISimpleFactory factory = new SimpleFactory();
            animal = factory.CreateAnimal();

            animal.Speak();
            animal.Action();
        }
    }
}
