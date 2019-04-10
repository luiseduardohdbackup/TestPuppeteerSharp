using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPuppeteerSharp
{
    public class Banorte
    {
        //public string user;
        //public string password;
        //public string token;
        //public Banorte(string user, string password, string token)
        //{
        //    this.user = user;
        //    this.password = password;
        //    this.token = token;
        //}
        //TODO: change the token to a handler so we can ask the user for the token whenever we want.
        public static async Task Login(string user, string password, string token)
        {
            Console.WriteLine("Banorte Login:" + user + password + token);
            //var options = new LaunchOptions { Headless = true };
            var options = new LaunchOptions { Headless = false };
            Console.WriteLine("Downloading chromium");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Console.WriteLine("Navigating to developers.google.com");

            using (var browser = await Puppeteer.LaunchAsync(options))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("https://nbxi.banorte.com/NBXI/aaloginnew.aspx");
                await page.WaitForTimeoutAsync(2000);
                // Type into search box.
                await page.TypeAsync("#txtUsuario", user);

                // Wait for suggest overlay to appear and click "show all results".
                var aceptarSelector = "#btnAceptarUsuario";
                //await page.WaitForSelectorAsync(aceptarSelector);
                await page.ClickAsync(aceptarSelector);

                await page.WaitForNavigationAsync();


                // Type into search box.
                await page.TypeAsync("#txtBXIPassword", password);
                // Type into Token
                Console.WriteLine("Token:");
                await page.TypeAsync("#txtBXIToken", token);

                // Wait for suggest overlay to appear and click "show all results".
                var entrarSelector = "#btnEntrar";
                //await page.WaitForSelectorAsync(entrarSelector);
                await page.ClickAsync(entrarSelector);

                await page.WaitForNavigationAsync();

                await page.WaitForTimeoutAsync(1000);

                var outputFile = "C:\\puppeteer.jpg";
                await page.ScreenshotAsync(outputFile);
                /*
                 * Exception thrown: 'System.UnauthorizedAccessException' in System.Private.CoreLib.dll
                    An unhandled exception of type 'System.UnauthorizedAccessException' occurred in System.Private.CoreLib.dll
                    Access to the path 'C:\puppeteer.jpg' is denied.
                 */

                //                // Wait for the results page to load and display the results.
                //                var resultsSelector = ".gsc-results .gsc-thumbnail-inside a.gs-title";
                //                await page.WaitForSelectorAsync(resultsSelector);
                //                var links = await page.EvaluateFunctionAsync(@"(resultsSelector) => {
                //    const anchors = Array.from(document.querySelectorAll(resultsSelector));
                //    return anchors.map(anchor => {
                //      const title = anchor.textContent.split('|')[0].trim();
                //      return `${title} - ${anchor.href}`;
                //    });
                //}", resultsSelector);

                //                foreach (var link in links)
                //                {
                //                    Console.WriteLine(link);
                //                }

            }

            Console.WriteLine("Banorte End");
        }
    }
}
