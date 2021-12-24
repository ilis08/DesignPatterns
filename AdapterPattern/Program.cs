using System;

namespace AdapterPattern
{
    public interface IRectInterface
    {
        void AboutRectangle();
        double CalculateAreaOfRectangle();
    }

    public interface ITriangleInterface
    {
        void AboutTriangle();
        double CalculateAreaOfTriangle();
    }

    class Rectangle : IRectInterface
    {
        public double length;
        public double width;

        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }

        public void AboutRectangle()
        {
            Console.WriteLine("Actually, I am a Rectangle");
        }

        public double CalculateAreaOfRectangle()
        {
            return length * width;
        }
    }

    class Triangle : ITriangleInterface
    {
        public double baseT;
        public double height;
        public Triangle(double b, double h)
        {
            baseT = b;
            height = h;
        }

        public void AboutTriangle()
        {
            Console.WriteLine("Actually, I am a Triangle");
        }

        public double CalculateAreaOfTriangle()
        {
            return 0.5 * baseT * height;
        }
    }
    
    class TriangleAdapter : IRectInterface
    {
        public Triangle Triangle { get; set; }

        public TriangleAdapter(Triangle triangle)
        {
            Triangle = triangle;
        }

        public void AboutRectangle()
        {
            Triangle.AboutTriangle();
        }

        public double CalculateAreaOfRectangle()
        {
            return Triangle.CalculateAreaOfTriangle();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new(20, 10);

            Console.WriteLine($"Area of rectangle is {rect.CalculateAreaOfRectangle()}");

            Triangle triangle = new(20, 10);

            Console.WriteLine($"Area of triangle is {triangle.CalculateAreaOfTriangle()}");

            IRectInterface adapter = new TriangleAdapter(triangle);

            Console.WriteLine($"Area of Triangle using the triangle adapter is {GetArea(adapter)} square unit.");
        }

        static double GetArea(IRectInterface rect)
        {
            rect.AboutRectangle();

            return rect.CalculateAreaOfRectangle();
        }
    }
}
