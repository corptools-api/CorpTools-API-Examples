require_relative '../request.rb'

# Example of GET /resources/:id/page/:page

RESOURCE_ID = ENV['AGENCY_RESOURCE_ID']
PAGE = 1

BaseRequestRoute.request(:get, "/resources/#{RESOURCE_ID}/page/#{PAGE}")