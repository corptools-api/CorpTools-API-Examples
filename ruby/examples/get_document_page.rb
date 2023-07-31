require_relative '../request.rb'

# Example of GET /documents/:document_id/page/:page_number
# The specified page of the document is saved as a png in the 'documents' directory

DOCUMENT_ID = ENV['DOCUMENT_ID']
PAGE_NUMBER = ENV['PAGE_NUMBER']

BaseRequestRoute.request(:get, "/documents/#{DOCUMENT_ID}/page/#{PAGE_NUMBER}")
