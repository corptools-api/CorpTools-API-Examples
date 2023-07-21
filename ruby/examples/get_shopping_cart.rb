require_relative '../request.rb'

# Example of GET /shopping-cart

COMPANY_ID = ENV['COMPANY_ID']

params = {
  company_id: [COMPANY_ID]
}

BaseRequestRoute.request(:get, '/shopping-cart', query_params: params)