using System;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartHouse house = new();

            house.StartHomeScenario();
        }
    }
}
