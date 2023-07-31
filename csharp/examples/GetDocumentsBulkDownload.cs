using System;
namespace Examples.examples
{
    // Example of GET /documents/bulk-download

    public class GetDocumentsBulkDownload : BaseRequest
	{
        private string _documentIds;

        public GetDocumentsBulkDownload()
		{
            dotenv.net.DotEnv.Load();
            _documentIds = Environment.GetEnvironmentVariable("DOCUMENT_ID");
            Console.WriteLine($"GetDocumentsBulkDownload: _documentIds={_documentIds}");
        }

        public override void SendRequest()
        {
            GetRequest($"documents/bulk-download?ids={_documentIds}");
        }
    }
}

