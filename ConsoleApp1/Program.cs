using SingletonePattern;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

Console.Title = "Singleton pattern";

var listInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Parallel.ForEach(listInt, number =>
{
    var result = Logger.Instance;
    result.Log("message");
});
