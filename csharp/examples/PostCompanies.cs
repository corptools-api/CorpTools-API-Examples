using System;
using Newtonsoft.Json;
namespace Examples.examples
{
    // POST /companies
    public class PostCompanies : BaseRequest
    {
        private string _companyName;
        private string _jurisdiction;
        private string _entityType;

        public PostCompanies()
		    {
            _companyName = Environment.GetEnvironmentVariable("COMPANY_NAME");
            _jurisdiction = Environment.GetEnvironmentVariable("JURISDICTION");
            _entityType = Environment.GetEnvironmentVariable("ENTITY_TYPE");
            Console.WriteLine($"PostCompanies: _companyName={_companyName} _jurisdiction={_jurisdiction} _entityType={_entityType}");
        }
        
        private class CompanyData
        {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("home_state")]
        public string HomeState { get; set; }

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }
        }

        public override void SendRequest()
        {
          CompanyData companyData = new CompanyData
          {
            Name = _companyName,
            HomeState = _jurisdiction,
            EntityType = _entityType
          };

          var companiesArray = new CompanyData[] { companyData };

          string jsonBody = JsonConvert.SerializeObject(new { companies = companiesArray });

          PostRequest("companies", jsonBody);
        }
      }
    }
