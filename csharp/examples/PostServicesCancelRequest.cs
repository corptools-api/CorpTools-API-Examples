﻿using System;
namespace Examples.examples
{
	// Example of POST /services/:service_id/cancel-request

	public class PostServicesCancelRequest : BaseRequest
	{
        private string _serviceId;

        public PostServicesCancelRequest()
        {
            _serviceId = Environment.GetEnvironmentVariable("SERVICE_ID");
            
            Console.WriteLine($"PostServicesCancelRequest: _serviceId={_serviceId}");
        }

        public override void SendRequest()
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject( new {} );
            PostRequest($"services/{_serviceId}/cancel-request", body);
        }
    }
}