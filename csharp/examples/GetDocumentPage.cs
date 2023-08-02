using System;

namespace Examples.examples
{
    // Example of GET /documents/:document_id/page/:page_number

    // The specified page of the document is saved as a png in the 'documents' directory
    
    class GetDocumentPage : BaseRequest
    {
        private string _documentId;
        private string _pageNumber;

        public GetDocumentPage() : base()
        {
            dotenv.net.DotEnv.Load();
            _documentId = Environment.GetEnvironmentVariable("DOCUMENT_ID");
            _pageNumber = Environment.GetEnvironmentVariable("PAGE_NUMBER");
            Console.WriteLine($"GetDocumentPage: document_id={_documentId} page_number={_pageNumber}");
        }

        public override void SendRequest()
        {
            string path = $"documents/{_documentId}/page/{_pageNumber}";
            GetRequest(path);
        }
    }
}
