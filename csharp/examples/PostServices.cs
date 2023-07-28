using System;
namespace Examples.examples.models
{
    // Example of POST /services
	public class PostServices : BaseRequest
	{
        private string _companyId;
        private string _companyName;
        private string _jurisdictionId;

        public PostServices()
		{
            _companyId = Environment.GetEnvironmentVariable("COMPANY_ID");
            _companyName = Environment.GetEnvironmentVariable("COMPANY_NAME");
            _jurisdictionId = Environment.GetEnvironmentVariable("JURISDICTION_ID");
            Console.WriteLine($"PostServices: _companyId={_companyId} _companyName={_companyName} _jurisdictionId={_jurisdictionId}");
        }

        public override void SendRequest()
        {
            string[] jurisdiction_ids = new string[] { _jurisdictionId };
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                company_id = _companyId,
                //company = _companyName,
                jurisdiction_ids = jurisdiction_ids
            });

            PostRequest("services", body);
        }
    }
}

