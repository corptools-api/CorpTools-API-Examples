require_relative '../request.rb'

# Example of PATCH /companies

# any values passed in for name, entity_type, home_state, and jurisdictions will be updated

COMPANY	= ENV['COMPANY_NAME'] # current company name
NAME = 'Sample Company' # new name
ENTITY_TYPE = ENV['ENTITY_TYPE']
HOME_STATE 	= ENV['JURISDICTION']
JURISDICTIONS = ENV['JURISDICTIONS']

# this example request will update the company_name and jurisdictions
params = { companies: [
  {
    company: COMPANY,
    name: NAME,
    jurisdictions: [JURISDICTIONS]
  }
]}.to_json

BaseRequestRoute.request(:patch, '/companies', body: params)

