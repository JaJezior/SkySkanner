using System;

namespace SkySkanner
{
    class Program
    {
        static void Main()
        {
            var communicator = new Communicator();
            double ans = communicator.AskUserForDouble("xyz");
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
