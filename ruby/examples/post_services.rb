require_relative '../request.rb'

# Example of POST /services

COMPANY_ID = ENV['COMPANY_ID']
COMPANY_NAME = ENV['COMPANY_NAME']
JURISDICTION_ID = ENV['JURISDICTION_ID']

body = {
	company_id: COMPANY_ID,
	# company: COMPANY_NAME,
	 jurisdiction_ids: [JURISDICTION_ID]
}.to_json

BaseRequestRoute.request(:post, '/services', body: body)