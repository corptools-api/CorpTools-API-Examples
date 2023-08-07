using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public override string SendRequest()
        {
            // Construct the url with the ids param as an array in the query string
            var queryParams = new List<string>();
            foreach (var id in _documentIds.Split(','))
            {
                queryParams.Add($"ids[]={Uri.EscapeDataString(id)}");
            }
            var queryString = string.Join("&", queryParams);
            var urlWithParams = $"documents/bulk-download?{queryString}";
            return GetRequest(urlWithParams);
        }
    }
}

