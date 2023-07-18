require_relative './request.rb'

params = { companies: [
	{ 
		name: 'Sample abc', 
		entity_type: 'Limited Liability Company', 
		jurisdictions: ['Maine', 'Washington']
	}
]}.to_json

BaseRequestRoute.request(:post, '/companies', body: params)

