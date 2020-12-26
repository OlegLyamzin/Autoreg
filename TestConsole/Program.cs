using Autoreg;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SmsActivator activator = new SmsActivator();

            Console.WriteLine(activator.GetBalance());
        }
    }
}
