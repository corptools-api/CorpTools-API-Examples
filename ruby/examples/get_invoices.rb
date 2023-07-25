require_relative '../request.rb'

# Example of GET /invoices
# An array of company names or company_ids may be provided, but not both

COMPANY_ID = ENV['COMPANY_ID']

params = {
  company_ids: [COMPANY_ID]
}

BaseRequestRoute.request(:get, '/invoices', query_params: params)
