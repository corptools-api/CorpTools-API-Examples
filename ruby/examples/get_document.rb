require_relative '../request.rb'

# Example of GET /documents/:document_id

DOCUMENT_ID = ENV['DOCUMENT_ID']

BaseRequestRoute.request(:get, "/documents/#{DOCUMENT_ID}")
