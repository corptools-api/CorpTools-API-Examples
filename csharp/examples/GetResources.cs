using System;
namespace Examples.examples
{
    // Example of GET /resources
    
	public class GetResources : BaseRequest
	{
		public GetResources()
		{
            Console.WriteLine($"GetResources");
        }

        public override void SendRequest()
        {
            GetRequest($"resources");
        }
    }
}

