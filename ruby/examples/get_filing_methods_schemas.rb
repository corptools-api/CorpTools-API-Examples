require_relative '../request.rb'

# Example of GET /filing-methods/schemas

COMPANY_ID        = ENV['COMPANY_ID']
FILING_METHOD_ID  = ENV['FILING_METHOD_ID']

params = {
  company_id: COMPANY_ID,
  filing_method_id: FILING_METHOD_ID
}

BaseRequestRoute.request(:get, '/filing-methods/schemas', query_params: params)
