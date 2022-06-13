using System;
using System.Collections.Generic;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Hi, guys.";

            var cloudMailService = new CloudMailService();
            cloudMailService.SendMail(message);

            var onPremiseMailService = new OnPremiseMailService();
            onPremiseMailService.SendMail(message);

            var statisticsDecorator = new StatisticsDecorator(cloudMailService);
            statisticsDecorator.SendMail(message);
        }
    }
}
 