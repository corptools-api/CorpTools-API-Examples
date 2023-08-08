using System;

namespace Examples.examples
{
    // Example of GET /documents/:document_id/download

    // The specified document is saved as a pdf in the 'documents' directory
    
    class GetDocumentDownload : BaseRequest
    {
        private string _documentId;

        public GetDocumentDownload() : base()
        {
            dotenv.net.DotEnv.Load();
            _documentId = Environment.GetEnvironmentVariable("DOCUMENT_ID");
            Console.WriteLine($"GetDocumentDownload: document_id={_documentId}");
        }

        public override string SendRequest()
        {
            string path = $"documents/{_documentId}/download";
            return GetRequest(path);
        }
    }
}
