using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO.Pipes;
using System.Text;

namespace TestingAppTest
{
    public class Test
    {
        private string ScenarioId {  get; set; }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("\n-------------------------\n");
            
            var client = new NamedPipeClientStream(".", "1", PipeDirection.InOut, PipeOptions.Asynchronous);

            client.ConnectAsync().GetAwaiter().GetResult();

            byte[] data = new byte[4];

            client.ReadAsync(data, 0, 4).GetAwaiter().GetResult();

            var lenght = BitConverter.ToInt32(data, 0);

            byte[] realData = new byte[lenght];

            client.ReadAsync(realData, 0, lenght).GetAwaiter().GetResult();

            ScenarioId = Encoding.UTF8.GetString(realData);

            client.Dispose();
        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
            
            
        }
    }

}