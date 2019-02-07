using System;

namespace Database
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Database loading");

            var core = new EngineCore();
            
            core.Load();

            Console.WriteLine("Database running");
            
            while (true)
            {
                try
                {
                    Console.WriteLine("-- enter command");
                    var input = Console.ReadLine();
                  
                    if(input.ToLowerInvariant() == "exit")
                        return;

                    Console.WriteLine("--");
                    var response = core.Query(input);
                    Console.WriteLine();

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
