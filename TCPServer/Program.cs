using System;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Communication cm = new Communication();

            Task.Run(cm.start);

            Console.ReadLine();
        }
    }
}
