using Autoreg;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SmsActivator activator = new SmsActivator();

            Console.WriteLine(activator.GetGMailPhoneNumber());
            string code = null;
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "ready":
                        activator.SetStatus(Constants.STATUSREADY);
                        break;
                    case "try":
                        code = activator.TryGetCodeActivation();
                        if (code == null)
                        {
                            Console.WriteLine(code);
                            break;
                        }
                        break;
                    case "finish":
                        activator.SetStatus(Constants.STATUSFINISH);
                        break;
                    case "refresh":
                        activator.SetStatus(Constants.STATUSREFRESH);
                        break;
                }
            }
        }
    }
}
