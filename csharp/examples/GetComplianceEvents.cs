using System;

namespace Examples.examples
{
    // Example of GET /compliance-events

    // Either a company or company_id may be provided, but not both
    // Either an array of jurisdictions or jurisdiction_ids may be provided, but not both
    // Start_date and end_date are required

    class GetComplianceEvents : BaseRequest
    {
		private string _companyId;
        private string _startDate;
        private string _endDate;

        public GetComplianceEvents() : base()
		{
            dotenv.net.DotEnv.Load();
            _companyId      = Environment.GetEnvironmentVariable("COMPANY_ID");
            _startDate      = Environment.GetEnvironmentVariable("START_DATE");
            _endDate        = Environment.GetEnvironmentVariable("END_DATE");
            Console.WriteLine($"GetComplianceEvents: _companyId={_companyId} _startDate={_startDate} _endDate={_endDate}");
        }

        public override void SendRequest()
        {
            string path = "compliance-events";
            string queryParams = $"?company_id={_companyId}&start_date={_startDate}&end_date={_endDate}";
            GetRequest(path + queryParams);
        }
	}
}
