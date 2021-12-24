using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class SmartHouse
    {
        private SmartKettle kettle;
        private SmartTW tw;
        private SmartLightSystem light;

        public SmartHouse()
        {
            kettle = new SmartKettle();
            tw = new SmartTW();
            light = new SmartLightSystem();
        }
           
        public void StartHomeScenario()
        {
            Console.WriteLine("Start of the scenario.");

            kettle.BoilWater();
            tw.TurnOn();
            light.TurnOnLight();
        }

    }
}
