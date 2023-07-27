using System;
namespace Examples.examples
{
    // Example GET /documents

    public class GetDocuments : BaseRequest
	{
        private string _status;

        public GetDocuments()
		{
            dotenv.net.DotEnv.Load();
            _status = Environment.GetEnvironmentVariable("STATUS");
            Console.WriteLine($"GetDocuments: _status={_status}");
        }

        public override void SendRequest()
        {
            GetRequest($"documents?status={_status}");
        }
    }
}

