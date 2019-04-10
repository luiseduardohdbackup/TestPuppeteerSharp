using PuppeteerSharp;
using System;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace TestPuppeteerSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var token = Console.ReadLine();
            var user = Credentials.Banorte.user;
            var password = Credentials.Banorte.password;
            await Banorte.Login(user, password, token);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
