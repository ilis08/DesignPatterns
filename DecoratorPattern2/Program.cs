using System;

namespace DecoratorPattern2
{
    public abstract class VolkswagenCar
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int Price { get; set; }

        public VolkswagenCar()
        {

        }

        public VolkswagenCar(string name, string engine, int price)
        {
            Name = name;
            Engine = engine;
            Price = price;
        }

        public abstract void BuildCar();
    }

    public class VolkswagenPolo : VolkswagenCar
    {
        public VolkswagenPolo(string name, string engine, int price) : base(name, engine, price)
        {

        }

        public override void BuildCar()
        {
            Console.WriteLine($"Build {Name} with {Engine} engine, cost {Price}.");
        }
    }

    public abstract class EquipmentDecorator : VolkswagenCar
    {
        protected VolkswagenCar car;

        public override void BuildCar()
        {
            if (car!=null)
            {
                car.BuildCar();
            }
        }

        public void SetTheCar(VolkswagenCar car)
        {
            this.car = car;
        }
    }

    public class OriginEquipment : EquipmentDecorator
    {
        public override void BuildCar()
        {
            car.Price += 50000;
            base.BuildCar();
            AddSafeLock();
        }

        private void AddSafeLock()
        {
            Console.WriteLine($"{car.Name} is equipment with Safelock technology.");
        }
    }

    public class RespectEquipment : EquipmentDecorator
    {
        public override void BuildCar()
        {
            car.Price += 100000;
            base.BuildCar();
            AddAirConditioner();
        }

        private void AddAirConditioner()
        {
            Console.WriteLine($"{car.Name} is equipment with Air conditioner.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VolkswagenCar polo = new VolkswagenPolo("Volkswagen Polo", "1.6", 1200000);

            polo.BuildCar();

            EquipmentDecorator poloOrigin = new OriginEquipment();

            poloOrigin.SetTheCar(polo);

            poloOrigin.BuildCar();

            EquipmentDecorator poloRespect = new RespectEquipment();

            poloRespect.SetTheCar(polo);

            poloRespect.BuildCar();
        }
    }
}
