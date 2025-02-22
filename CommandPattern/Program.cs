﻿using CommandPattern;

Console.Title = "Command";

CommandManager commandManager = new();

IEmployeeManagerRepository repository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Kevin")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(222, "Clara")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(333, "Kevin")));
repository.WriteDataStore();