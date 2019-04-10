using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPuppeteerSharp
{
    public static class Util
    {
        public static async Task<string> GetInputAsync()
        {
            return await Task.Run(() => Console.ReadLine());
        }
    }
}
