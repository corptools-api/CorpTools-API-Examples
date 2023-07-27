using System;

namespace Examples.examples
{
    // Example of GET /documents/:document_id
    class GetDocument : BaseRequest
    {
        private string _documentId;

        public GetDocument() : base()
        {
            dotenv.net.DotEnv.Load();
            _documentId = Environment.GetEnvironmentVariable("DOCUMENT_ID");
            Console.WriteLine($"GetDocument: document_id={_documentId}");
        }

        public override void SendRequest()
        {
            string path = $"documents/{_documentId}";
            GetRequest(path);
        }
    }
}
