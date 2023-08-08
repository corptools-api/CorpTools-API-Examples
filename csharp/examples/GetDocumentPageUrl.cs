using System;

namespace Examples.examples
{
    // Example of GET /documents/:document_id/page/:page_number/url
    
    class GetDocumentPageUrl : BaseRequest
    {
        private string _documentId;
        private string _pageNumber;

        public GetDocumentPageUrl() : base()
        {
            dotenv.net.DotEnv.Load();
            _documentId = Environment.GetEnvironmentVariable("DOCUMENT_ID");
            _pageNumber = Environment.GetEnvironmentVariable("PAGE_NUMBER");
            Console.WriteLine($"GetDocumentPageUrl: document_id={_documentId} page_number={_pageNumber}");
        }

        public override string SendRequest()
        {
            string path = $"documents/{_documentId}/page/{_pageNumber}/url";
            return GetRequest(path);
        }
    }
}
