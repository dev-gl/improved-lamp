using System;
using Database.Core;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database running");

            var core = new EngineCore();

            while (true)
            {

                try
                {
                    var input = Console.ReadLine();

                    Console.WriteLine();
                    var response = core.QueryAsync(input).GetAwaiter().GetResult();
                    Console.WriteLine(response);
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
