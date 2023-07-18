require_relative '../request.rb'

WEBSITE_URL	= ENV['WEBSITE_URL']
JURISDICTION 	= ENV['JURISDICTION']

params = {
  jurisdiction: JURISDICTION,
  url: WEBSITE_URL
}

BaseRequestRoute.request(:get, '/filing-products', query_params: params)