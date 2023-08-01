require_relative '../request.rb'

# Example of GET /registered-agent-products

WEBSITE_URL = ENV['WEBSITE_URL']

params = {
	url: WEBSITE_URL,
}

BaseRequestRoute.request(:get, '/registered-agent-products', query_params: params)