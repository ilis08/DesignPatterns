using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    interface IRobot
    {
        void Print();
    }

    public class Robot : IRobot
    {
        string robotType;
        public string colorOfRobot;

        public Robot(string robotType)
        {
            this.robotType = robotType;
        }

        public void SetColor(string colorOfRobot)
        {
            this.colorOfRobot = colorOfRobot;
        }

        public void Print()
        {
            Console.WriteLine($"This is a {robotType} type robot with {colorOfRobot} color.");
        }
    }

    class RobotFactory
    {
        Dictionary<string, IRobot> shapes = new();

        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }

        public IRobot GetRobotFromFactory(string robotType)
        {
            IRobot robotCategory = null;

            if (shapes.ContainsKey(robotType))
            {
                robotCategory = shapes[robotType];
            }
            else
            {
                switch (robotType)
                {
                    case "Small":
                        robotCategory = new Robot("Small");
                        shapes.Add("Small", robotCategory);
                        break;
                    case "Large":
                        robotCategory = new Robot("Large");
                        shapes.Add("Large", robotCategory);
                        break;
                    default:
                        throw new Exception("Robot Factory can create only small and large robots.");
                }
            }

            return robotCategory;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RobotFactory myFactory = new RobotFactory();

            Robot shape;

            for (int i = 0; i < 3; i++)
            {
                shape = (Robot)myFactory.GetRobotFromFactory("Small");
                Task.Delay(1000).Wait();
                shape.SetColor(GetRandomColor());
                shape.Print();
            }

            int NumOfDistinctRobots = myFactory.TotalObjectsCreated;

            Console.WriteLine($"\nNow, total numbers of distinct robot objects is = {NumOfDistinctRobots}");
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                shape = (Robot)myFactory.GetRobotFromFactory("Large");
                Task.Delay(1000).Wait();
                shape.SetColor(GetRandomColor());
                shape.Print();
            }

            NumOfDistinctRobots = myFactory.TotalObjectsCreated;

            Console.WriteLine($"\nNow, total numbers of distinct robot objects is = {NumOfDistinctRobots}");


        }

        static string GetRandomColor()
        {
            Random r = new Random();

            int n = r.Next(100);

            if (n % 2 == 0)
            {
                return "red";
            }
            else
            {
                return "green";
            }
        }
    }
}
