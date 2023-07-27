require_relative '../request.rb'

# Example of GET /websites

WEBSITE_URL = ENV['WEBSITE_URL']

params = {
  url: WEBSITE_URL
}

BaseRequestRoute.request(:get, '/websites', query_params: params)
