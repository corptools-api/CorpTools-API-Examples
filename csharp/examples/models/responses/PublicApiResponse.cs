using System;
using System.Collections.Generic;

namespace Examples.examples
{
	public class PublicApiResponse<T>
	{
		public List<T> result { get; set; }
		public string status_code { get; set; }
		public Boolean success { get; set; }
		public string timestamp { get; set; }
		public List<string> invoice_ids { get; set; } // only used in shopping-cart checkout response
    }

    public class PublicApiSingleResultResponse<T>
    {
        public T result { get; set; }
        public Boolean success { get; set; }
        public string timestamp { get; set; }
    }
}