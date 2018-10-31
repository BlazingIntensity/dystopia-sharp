using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            server.Run();

            Console.WriteLine("Program has ended, press any key to continue.");
            Console.ReadKey();
        }
    }
}
