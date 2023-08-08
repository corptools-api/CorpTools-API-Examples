require_relative '../request.rb'

# Example of GET /documents/:document_id/page/:page_number/url

DOCUMENT_ID = ENV['DOCUMENT_ID']
PAGE_NUMBER = ENV['PAGE_NUMBER']

BaseRequestRoute.request(:get, "/documents/#{DOCUMENT_ID}/page/#{PAGE_NUMBER}/url")
