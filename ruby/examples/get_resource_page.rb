require_relative '../request.rb'

# Example of GET /resources/:resource_id/page/:page_number

RESOURCE_ID = ENV['AGENCY_RESOURCE_ID']
PAGE_NUMBER = ENV['PAGE_NUMBER']

BaseRequestRoute.request(:get, "/resources/#{RESOURCE_ID}/page/#{PAGE_NUMBER}")