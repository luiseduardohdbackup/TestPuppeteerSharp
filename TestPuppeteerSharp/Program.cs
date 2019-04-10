using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace TestPuppeteerSharp
{
    class Program
    {
        //cd "C:\Users\UserName\Documents\GitHub\TestPuppeteerSharp\TestPuppeteerSharp\bin\Debug\netcoreapp2.1\.local-chromium\Win64-641577\chrome-win"
        //start chrome.exe --remote-debugging-port=9222 --user-data-dir=remote-profile
        //curl localhost:9222/json/version
        //public static string wsChromeEndpointurl = "ws://localhost:9222/devtools/page/C68E3CBEA9CAA22965B3C1BAD26814F2";
        //public static string wsChromeEndpointurl = "ws://localhost:9222/devtools/page/4F737F7723F448296F0D7399013056EE";
        public static string wsChromeEndpointurl = "ws://localhost:9222/devtools/browser/f1a2cc63-57d1-42d2-9a5f-78886eec9da1";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Program Main");
            await TestUber();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine("Program Main End");
        }

        public static async Task TestUber()
        {


            Console.WriteLine("Downloading chromium");

            Console.WriteLine("Downloading browser");
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Console.WriteLine("Downloading browser end");
            //Console.WriteLine("Navigating to developers.google.com");

            var LaunchOptions = new LaunchOptions
            {
                Headless = false

            };

            var ConnectOptions = new ConnectOptions()
            {
                BrowserWSEndpoint = wsChromeEndpointurl
            };

            //var url = "https://www.google.com/";

            //await Puppeteer.LaunchAsync(LaunchOptions);

            //using (var browser = await Puppeteer.LaunchAsync(LaunchOptions))
            using (var browser = await PuppeteerSharp.Puppeteer.ConnectAsync(ConnectOptions))
            using (var page = await browser.NewPageAsync())
            {
                Uber.page = page;
                var user = Credentials.Uber.user;
                var password = Credentials.Uber.password;
                await Uber.Login(user, password);
            }
        }

        public static async Task TestBanorte ()
        {
            var token = Console.ReadLine();
            var user = Credentials.Banorte.user;
            var password = Credentials.Banorte.password;
            await Banorte.Login(user, password, token);

        }
    }
    //Util
    //https://github.com/checkly/puppeteer-recorder
    //Puppeteer recorder is a Chrome extension that records your browser interactions and generates a Puppeteer script.
    //https://medium.com/@jaredpotter1/connecting-puppeteer-to-existing-chrome-window-8a10828149e0
    //Connecting Puppeteer to Existing Chrome Window w/ reCAPTCHA
    //curl localhost:9222/json
    //https://www.igvita.com/2012/04/09/driving-google-chrome-via-websocket-api/
    //http://localhost:9222/
    //https://blog.chromium.org/2011/05/remote-debugging-with-chrome-developer.html
}
