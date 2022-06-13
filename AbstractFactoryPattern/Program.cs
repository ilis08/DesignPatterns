using System;

namespace AbstractFactoryPattern
{
    public interface IProgram
    {
        public void ProgramType();
    }

    public class Web : IProgram
    {
        public void ProgramType()
        {
            Console.WriteLine("Create Web program");
        }
    }

    public class Desktop : IProgram
    {
        public void ProgramType()
        {
            Console.WriteLine("Create Desktop program");
        }
    }

    public interface IDeveloperFactory
    {
        public IProgram ReturnProgram();
    }

    public class WebDeveloper : IDeveloperFactory
    {
        public IProgram ReturnProgram()
        {
            return new Web();
        }
    }

    public class DesktopDeveloper : IDeveloperFactory
    {
        public IProgram ReturnProgram()
        {
            return new Desktop(); 
        }
    }

    public class Programmer
    {
        private IProgram program;

        public Programmer(IDeveloperFactory factory)
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
