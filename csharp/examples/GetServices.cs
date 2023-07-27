using System;
namespace Examples.examples
{
    // Example of GET /services
	public class GetServices : BaseRequest
	{
        private string _companyId;
        private string _companyName;
        private int _limit;
        private int _offset;

        public GetServices()
		{
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _companyName = Environment.GetEnvironmentVariable("COMPANY_NAME");
            _limit = 3;
            _offset = 0;
            Console.WriteLine($"GetServices: _companyId={_companyId} _companyName={_companyName}");
        }

        public override void SendRequest()
        {
            GetRequest($"services?company_id={_companyId}");
            //GetRequest($"services?company={_companyName}&limit={limit}&offset={offset}");
        }
    }
}

