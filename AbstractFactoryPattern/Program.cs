using System;

namespace AbstractFactoryPattern
{
    public interface IDog
    {
        void Speak();
        void Action();
    }

    public interface ITiger
    {
        void Speak();
        void Action();

    }

    #region Wild Animal collection

    class WildDog : IDog
    {
        public void Action()
        {
            Console.WriteLine("Wild Dogs prefer to roam freely in jungles.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Wild Dog says: Bow-Wow.");
        }
    }

    class WildTiger : ITiger
    {
        public void Action()
        {
            Console.WriteLine("Wild Tigers prefer hunting in jungles.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Wild Tigers prefer hunting in jungles.\n");
        }
    }
    #endregion

    #region Pet Animal collection
    class PetDog : IDog
    {
        public void Action()
        {
            Console.WriteLine("Pet Dogs prefer to stay  at home.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Pet Dog says: Bow-Wow");
        }
    }

    class PetTiger : ITiger
    {
        public void Action()
        {
            Console.WriteLine("Pet Tigers play in an animal circus.\n");
        }

        public void Speak()
        {
            Console.WriteLine("Pet Tiger says: Halum.");
        }
    }

    #endregion

    public interface IAnimalFactory
    {
        IDog GetDog();
        ITiger GetTiger();
    }

    public class WildAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new WildDog();
        }

        public ITiger GetTiger()
        {
            return new WildTiger();
        }
    }

    public class PetAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }

        public ITiger GetTiger()
        {
            return new PetTiger();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAnimalFactory wildAnimalFactory = new WildAnimalFactory();

            IDog wildDog = wildAnimalFactory.GetDog();

            wildDog.Speak();
            wildDog.Action();
        }
    }
}
