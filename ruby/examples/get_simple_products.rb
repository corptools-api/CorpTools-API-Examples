require_relative '../request.rb'

# Example of GET /simple-products

WEBSITE_URL = ENV['WEBSITE_URL']

params = {
	url: WEBSITE_URL
}

BaseRequestRoute.request(:get, '/simple-products', query_params: params)