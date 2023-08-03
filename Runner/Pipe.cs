using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    public class Pipe
    {
        public async Task OpenServer(string scenarioId)
        {
            var server = new NamedPipeServerStream("1", PipeDirection.InOut);

            await server.WaitForConnectionAsync();

            var data = Encoding.UTF8.GetBytes(scenarioId);

            var lenghtData = BitConverter.GetBytes(data.Length);

            await server.WriteAsync(lenghtData, 0, 4);

            await server.WriteAsync(data, 0, data.Length);

            server.Dispose();
        }
    }
}
