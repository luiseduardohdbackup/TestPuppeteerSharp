using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPuppeteerSharp
{
    class Uber
    {
        public static Page page;

        //TODO:check how to avoid recaptcha
        public static async Task Login(string user, string password)
        {
            Console.WriteLine("Uber Login:" + user +",", password );

            await page.GoToAsync("https://partners.uber.com");
            await page.WaitForTimeoutAsync(2000);
            // Type into search box.
            await page.TypeAsync("#useridInput", user);

            Console.WriteLine("Uber Login End");

            await Util.GetInputAsync();
        }
    }
}
