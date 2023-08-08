using System;
namespace Examples.examples
{
    // Example of GET /documents

    public class GetDocuments : BaseRequest
	{
        private string _status;

        public GetDocuments()
		{
            dotenv.net.DotEnv.Load();
            _status = Environment.GetEnvironmentVariable("STATUS");
            Console.WriteLine($"GetDocuments: _status={_status}");
        }

        public override string SendRequest()
        {
            return GetRequest($"documents?status={_status}");
        }
    }
}

