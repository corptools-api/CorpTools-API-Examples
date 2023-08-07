using System;
namespace Examples.examples
{
    // Example of GET /resources/:resource_id/page/:page_number

    public class GetResourcePage : BaseRequest
	{
        private string _resourceId;
        private string _pageNumber;

        public GetResourcePage()
		{
            _pageNumber = Environment.GetEnvironmentVariable("PAGE_NUMBER");
            _resourceId = Environment.GetEnvironmentVariable("AGENCY_RESOURCE_ID");
            Console.WriteLine($"GetResource: _resourceId={_resourceId} _pageNumber={_pageNumber}");
        }

        public override string SendRequest()
        {
            return GetRequest($"resources/{_resourceId}/page/{_pageNumber}");
        }
    }
}