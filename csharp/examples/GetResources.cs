using System;
namespace Examples.examples
{
    // Example of GET /resources
	public class GetResources : BaseRequest
	{
		public GetResources()
		{
		}

        public override void SendRequest()
        {
            GetRequest($"resources");
        }
    }
}

