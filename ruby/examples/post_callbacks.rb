require_relative '../request.rb'

# Example POST /callbacks

WEBSITE_URL	= ENV['CALLBACK_URL']

params = {
	url: WEBSITE_URL
}.to_json

BaseRequestRoute.request(:post, '/callbacks', body: params)