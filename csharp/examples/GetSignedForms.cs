using System;
namespace Examples.examples
{
    // Example of GET /signed-forms
    public class GetSignedForms : BaseRequest
    {
        private string _filingMethodId;
        private string _websiteId;

        public GetSignedForms()
        {
            dotenv.net.DotEnv.Load();
            _filingMethodId = Environment.GetEnvironmentVariable("FILING_METHOD_ID");
            _websiteId = Environment.GetEnvironmentVariable("WEBSITE_ID");

            Console.WriteLine($"GetSignedForms: _filingMethodIde={_filingMethodId} _websiteId={_websiteId}");
        }


        public override void SendRequest()
        {
            GetRequest($"signed-forms?filing_method_id={_filingMethodId}&website_id={_websiteId}");
        }
    }
    
}

