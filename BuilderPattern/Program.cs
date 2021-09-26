using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            IBuilder computer = new LowSegmentComputer("Trizor");

            director.Construct(computer);

            Computer c = computer.CreateComputer();

            c.ShowComputerStates();
        }
    }

    public interface IBuilder
    {
        public Computer CreateComputer();
        public void SetSegment();
        public void AddMotherboard();
        public void AddGraphicsCard();
        public void AddComputerCase();
        public void AddProcessor();
        public void SetPrice();
    }

    public class Director
    {
        IBuilder builder;

        public void Construct(IBuilder builder)
        {
            this.builder = builder;
            builder.AddComputerCase();
            builder.AddGraphicsCard();
            builder.AddMotherboard();
            builder.AddProcessor();
            builder.SetSegment();
            builder.SetPrice();
        }
    }

    public class Computer
    {
        public string Name { get; set; }

        public string Segment { get; set; }

        public int Price { get; set; }

        public string MotherBoard { get; set; }

        public string GraphicCard { get; set; }

        public string Case { get; set; }

        public string Proc { get; set; }

        
        public void ShowComputerStates()
        {
            Console.WriteLine($"Computer name -> {Name}");
            Console.WriteLine($"Segment -> {Segment}");
            Console.WriteLine($"Price -> {Price}");
            Console.WriteLine($"Motherboard -> {MotherBoard}");
            Console.WriteLine($"Graphics card -> {GraphicCard}");
            Console.WriteLine($"Case -> {Case}");
            Console.WriteLine($"Processor -> {Proc}");
        }
    }

    public class LowSegmentComputer : Computer, IBuilder
    {
        private Computer computer;

        public LowSegmentComputer(string name)
        {
            computer = new Computer();
            computer.Name = name;
        }

        public void AddComputerCase()
        {
            computer.Case = "Frontier BACH MicroATX Black без БП";
        }

        public void AddGraphicsCard()
        {
            computer.GraphicCard = "Arktek PCI-Ex GeForce GTX 750 Ti 2GB GDDR5";
        }

        public void AddMotherboard()
        {
            computer.MotherBoard = "Huanan B75-Pro";
        }

        public void AddProcessor()
        {
            computer.Proc = "Intel Core i7-2600K";
        }

        public Computer CreateComputer()
        {
            return computer;
        }

        public void SetSegment()
        {
            computer.Segment = "Low";
        }

        public void SetPrice()
        {
            Random r = new Random();

            computer.Price = r.Next(1000, 3000);
        }
    }

}
