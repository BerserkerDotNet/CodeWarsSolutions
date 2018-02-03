using System;

namespace Solutions.Infrastructure
{
    public class ConsoleHost : IHost
    {
        public T Read<T>(string message)
        {
            Show(message);
            return Read<T>();
        }

        public T Read<T>()
        {
            var data = Console.ReadLine();
            return (T)Convert.ChangeType(data, typeof(T));
        }

        public void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
