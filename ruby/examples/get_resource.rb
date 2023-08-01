require_relative '../request.rb'

# Example of GET /resources/:id

RESOURCE_ID = ENV['AGENCY_RESOURCE_ID']

BaseRequestRoute.request(:get, "/resources/#{RESOURCE_ID}")