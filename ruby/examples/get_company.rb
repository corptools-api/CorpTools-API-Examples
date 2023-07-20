require_relative '../request.rb'

COMPANY_ID = ENV['COMPANY_ID']

BaseRequestRoute.request(:get, "/companies/#{COMPANY_ID}")
