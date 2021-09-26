using System;

namespace FactoryMethodPattern
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
            Console.WriteLine("Dogs prefer barking...\n");
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
            Console.WriteLine("Tiger prefer hunting...\n");
        }

        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
    }

    public abstract class IAnimalFactory
    {
        public abstract IAnimal CreateAnimal();

        public IAnimal MakeAnimal()
        {
            Console.WriteLine("\n IAnimalFactory.MakeAnimal()-You cannot ignire parent rules.");

            IAnimal animal = CreateAnimal();
            animal.Speak();
            animal.Action();
            return animal;
        }
    }

    public class DogFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }

    public class TigerFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Tiger();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAnimalFactory tigerFactory = new TigerFactory();

            IAnimal aTiger = tigerFactory.MakeAnimal();
        }
    }
}
