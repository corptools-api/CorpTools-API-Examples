using System;

namespace Examples.examples
{
    // Example of GET /documents/:document_id/download
    class GetDocumentDownload : BaseRequest
    {
        private string _documentId;

        public GetDocumentDownload() : base()
        {
            dotenv.net.DotEnv.Load();
            _documentId = Environment.GetEnvironmentVariable("DOCUMENT_ID");
            Console.WriteLine($"GetDocumentDownload: document_id={_documentId}");
        }

        public override void SendRequest()
        {
            string path = $"documents/{_documentId}/download";
            GetRequest(path);
        }
    }
}
