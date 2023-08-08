using System;
using Newtonsoft.Json;
namespace Examples.examples
{
    // Example of PATCH /companies

    // this example will update the entity_type for the specified company
  
    public class PatchCompanies : BaseRequest
    {
        private string _companyName;
        private string _entityType;

        public PatchCompanies()
		    {
            _companyName = Environment.GetEnvironmentVariable("COMPANY_NAME");
            _entityType = "Corporation";
            Console.WriteLine($"PatchCompanies: _companyName={_companyName} _entityType={_entityType}");
        }

        private class CompanyData
        {
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }
        }

        public override string SendRequest()
        {
          CompanyData companyData = new CompanyData
          {
            Company = _companyName,
            EntityType = _entityType
          };

          var companiesArray = new CompanyData[] { companyData };

          string jsonBody = JsonConvert.SerializeObject(new { companies = companiesArray });

          return PatchRequest("companies", jsonBody);
        }
      }
    }
