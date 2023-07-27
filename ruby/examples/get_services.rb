require_relative '../request.rb'

# Example of GET /services

COMPANY_ID = ENV['COMPANY_ID']
COMPANY_NAME = ENV['COMPANY_NAME']
LIMIT = 3
OFFSET = 0

params = {
	company_id: COMPANY_ID,
	# company: COMPANY_NAME,
	# limit: LIMIT,
	# offset: OFFSET
}

BaseRequestRoute.request(:get, '/services', query_params: params)