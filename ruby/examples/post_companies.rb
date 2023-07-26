require_relative '../request.rb'

# Example of POST /companies

NAME	= ENV['COMPANY_NAME']
ENTITY_TYPE = ENV['ENTITY_TYPE']
JURISDICTION 	= ENV['JURISDICTION']

params = { companies: [
	{ 
		name: NAME,
		entity_type: ENTITY_TYPE,
		home_state: JURISDICTION
	}
]}.to_json

BaseRequestRoute.request(:post, '/companies', body: params)

