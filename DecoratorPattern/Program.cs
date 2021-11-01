using System;

namespace DecoratorPattern
{
    abstract class Component
    {
        public abstract void MakeHouse();
    }

    class ConcreteComponent : Component
    {
        public override void MakeHouse()
        {
            Console.WriteLine("Original House is complete. It is closed for modification.");
        }
    }

    abstract class AbstractDecorator : Component
    {
        protected Component component;

        public void SetTheComponent(Component c)
        {
            component = c;
        }

        public override void MakeHouse()
        {
            if (component!=null)
            {
                component.MakeHouse();
            }
        }
    }

    class ConcreteDecoratorEx1 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            base.MakeHouse();
            Console.WriteLine("***Using a decorator***");

            AddFloor();
        }

        private void AddFloor()
        {
            Console.WriteLine("I am making an additional floor on top of it.");
        }
    }

    class ConcreteDecoratorEx2 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            base.MakeHouse();
            Console.WriteLine("***Using another decorator***");
            PaintTheHouse();
        }

        private void PaintTheHouse()
        {
            Console.WriteLine("Now I am painting the house.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent cc = new ConcreteComponent();

            AbstractDecorator dec1 = new ConcreteDecoratorEx1();

            dec1.SetTheComponent(cc);
            dec1.MakeHouse();


            AbstractDecorator dec2 = new ConcreteDecoratorEx2();

            dec2.SetTheComponent(dec1);
            dec2.MakeHouse();

        }
    }
}
