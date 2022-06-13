using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Employee
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Manager : Employee
    {
        public Manager(int id, string name) : base(id, name)
        {
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }

    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>
        {
            new Manager(1, "Katie"), new Manager(2, "Geoff")
        };

        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Add(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(x => x.Id == managerId).Employees.Any(x => x.Id == employeeId);   
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Remove(employee);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");

                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees.");
                }
            }
        }
    }

    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository employeeManagerRepository;
        private readonly int managerId;
        private readonly Employee? employee;

        public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee? employee)
        {
            this.employeeManagerRepository = employeeManagerRepository;
            this.managerId = managerId;
            this.employee = employee;
        }

        public bool CanExecute()
        {
            if (employee == null)
            {
                return false;
            }

            if (employeeManagerRepository.HasEmployee(managerId, employee.Id))
            {
                return false;
            }

            return true;
        }

        public void Execute()
        {
            if (employee == null)
            {
                return;
            }

            employeeManagerRepository.AddEmployee(managerId, employee);
        }
    }

    public class CommandManager
    {
        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
            }
        }
    }
}
