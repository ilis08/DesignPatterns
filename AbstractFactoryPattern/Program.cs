using System;

namespace AbstractFactoryPattern
{
    public abstract class Program
    {
        public abstract void ProgramType();
    }

    public class Web : Program
    {
        public override void ProgramType()
        {
            Console.WriteLine("Create Web program");
        }
    }

    public class Desktop : Program
    {
        public override void ProgramType()
        {
            Console.WriteLine("Create Desktop program");
        }
    }

    public abstract class DeveloperFactory
    {
        public abstract Program ReturnProgram();
    }

    public class WebDeveloper : DeveloperFactory
    {
        public override Program ReturnProgram()
        {
            return new Web();
        }
    }

    public class DesktopDeveloper : DeveloperFactory
    {
        public override Program ReturnProgram()
        {
            return new Desktop(); 
        }
    }

    public class Programmer
    {
        private Program program;

        public Programmer(DeveloperFactory factory)
        {
            program = factory.ReturnProgram();
        }

        public void Program()
        {
            program.ProgramType();
        }
    }

    class Start
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer(new WebDeveloper());

            programmer.Program();
        }
    }
}
