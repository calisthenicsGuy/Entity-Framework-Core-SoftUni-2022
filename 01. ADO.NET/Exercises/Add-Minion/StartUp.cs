using System;

namespace Add_Minion
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(Config.connectionString);
            Console.WriteLine(engine.Run());
        }
    }
}
