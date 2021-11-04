using System;
using System.Collections.Generic;

namespace DecoratorPattern
{
    public abstract class Dealership
    {
        public Dealership(int numVehicle)
        {
            NumVehicles = numVehicle;
        }

        public Dealership()
        {

        }

        public int NumVehicles { get; set; }

        public abstract void ShowStates();
    }

    public class CarDealership : Dealership
    {
        public int Area { get; set; }

        public CarDealership(int numCars,int area) : base(numCars)
        {
            Area = area;
        }

        public override void ShowStates()
        {
            Console.WriteLine("\nCarDealership ----- ");
            Console.WriteLine($"Number of car inside : {NumVehicles}");
            Console.WriteLine($"Area of dealership is {Area} sqr meters");
        }
    }

    public class MotoDealership : Dealership
    {
        public int NumberOfMotoSections { get; set; }


        public MotoDealership(int numMoto, int numOfSections) : base(numMoto)
        {
            NumberOfMotoSections = numOfSections; 
        }

        public override void ShowStates()
        {
            Console.WriteLine("\nMotoDealership ----- ");
            Console.WriteLine($"Number of moto inside : {NumVehicles}");
            Console.WriteLine($"Number of moto sections is {NumberOfMotoSections}");
        }
    }

    public class DealershipDecorator : Dealership
    {
        protected Dealership dealership;

        public DealershipDecorator(Dealership dealership)
        {
            this.dealership = dealership;
        }

        public override void ShowStates()
        {
            dealership.ShowStates();
        }
    }

    public class SaleVehicle : DealershipDecorator
    {
        public List<string> buyers = new();

        public SaleVehicle(Dealership dealership) : base(dealership)
        {

        }

        public void Sell(string buyerName)
        {
            buyers.Add(buyerName);
            dealership.NumVehicles--;       
        }
        
        public override void ShowStates()
        {
            base.ShowStates();

            Console.WriteLine("Buyers");

            foreach (var item in buyers)
            {
                Console.WriteLine($"Buyer : {item}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dealership carDealership = new CarDealership(15, 100);

            SaleVehicle sale = new SaleVehicle(carDealership);

            sale.Sell("Iliya");
            sale.Sell("Ivan");
            sale.Sell("Sergey");

            sale.ShowStates();

        }
    }
}
