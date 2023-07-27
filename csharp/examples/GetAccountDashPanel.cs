using System;
namespace Examples.examples
{
    // Example of GET /account/dashpanel
    public class GetAccountDashPanel : BaseRequest
    {
        public GetAccountDashPanel()
        {
        }

        public override void SendRequest()
        {
            GetRequest("account/dashpanel");
        }
    }
}