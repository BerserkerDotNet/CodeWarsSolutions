using Ninject;
using Ninject.Extensions.Conventions;
using Solutions.Infrastructure;
using System;
using System.Linq;

namespace Solutions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IHost>().To<ConsoleHost>()
                .InSingletonScope();
            kernel.Bind(s => s.FromThisAssembly()
                .Select(c => typeof(ISolution).IsAssignableFrom(c))
                .BindAllInterfaces());

            var allSolutions = kernel.GetAll<ISolution>()
                .ToArray();

            Console.WriteLine("Select solution:");
            var index = 0;
            foreach (var solution in allSolutions)
            {
                Console.WriteLine($"{index}. {solution.DisplayName}");
                index++;
            }
            var option = int.Parse(Console.ReadLine());

            if (option > allSolutions.Length || option < 0)
            {
                Console.WriteLine("Bad option.");
            }
            else
            {
                allSolutions[option].Execute(kernel.Get<IHost>());
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
