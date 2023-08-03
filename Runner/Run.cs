using Newtonsoft.Json;
using NUnit.Engine;
using System.IO.Pipes;
using System.Text;
using System.Xml;

namespace Runner
{
    public class Run
    {
        public async Task RunTest()
        {

            ITestEngine engine = TestEngineActivator.CreateInstance();

            var filterService = engine.Services.GetService<ITestFilterService>();

            var filterBuilder = filterService.GetTestFilterBuilder();

            filterBuilder.AddTest("TestingAppTest.Test.Test1");

            string? path = Environment.CurrentDirectory + Path.DirectorySeparatorChar ;

            path += "TestingAppTest.dll";

            TestPackage package = new TestPackage(path);

            ITestRunner runner = engine.GetRunner(package);

            XmlNode testResultOb2 = runner.Run(listener: null, filterBuilder.GetFilter());

            string jsonResult = JsonConvert.SerializeXmlNode(testResultOb2);

            Console.WriteLine(jsonResult);
        }

    }
}