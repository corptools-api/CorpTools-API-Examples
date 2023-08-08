require_relative '../request.rb'

# Example of GET /companies/:id

COMPANY_ID = ENV['COMPANY_ID']

BaseRequestRoute.request(:get, "/companies/#{COMPANY_ID}")
