require_relative '../request.rb'

# Example of GET /order-items/requiring-attention

COMPANY_ID = ENV['COMPANY_ID']

params = {
	company_ids: [COMPANY_ID]
}.to_json

BaseRequestRoute.request(:get, '/order-items/requiring-attention', query_params: params)