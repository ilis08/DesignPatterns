using System;

namespace FactoryMethodPattern
{
    public interface ITable
    {

    }

    public class WoodTable : ITable
    {
        public WoodTable()
        {
            Console.WriteLine("Wood table was built");
        }
    }

    public class IronTable : ITable
    {
        public IronTable()
        {
            Console.WriteLine("IronTable was built");
        }
    }

    public abstract class TableFactory
    {
        public abstract ITable CreateTable();

    }

    public class WoodTableFactory : TableFactory
    {
        public override ITable CreateTable()
        {
            return new WoodTable();
        }
    }

    public class IronTableFactory : TableFactory
    {
        public override ITable CreateTable()
        {
            return new IronTable();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TableFactory factory = new WoodTableFactory();

            ITable table = factory.CreateTable();

        }
    }
}
