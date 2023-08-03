using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Run model = new Run();
            Pipe server = new Pipe();
            server.OpenServer("1");
            await model.RunTest();

            server.OpenServer("2");
            await model.RunTest();
            
            server.OpenServer("3");
            await model.RunTest();
            
            server.OpenServer("4");
            await model.RunTest();

        }
    }
}
