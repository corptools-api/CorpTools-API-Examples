require_relative '../request.rb'

# Example of GET /filing-products/offerings

COMPANY_ID	 = ENV['COMPANY_ID']
JURISDICTION = ENV['JURISDICTION']

params = {
  company_id: COMPANY_ID,
  jurisdiction: JURISDICTION
}

BaseRequestRoute.request(:get, '/filing-products/offerings', query_params: params)