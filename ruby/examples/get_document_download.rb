require_relative '../request.rb'

# Example of GET /documents/:document_id/download
# The specified document is saved as a pdf in the 'documents' directory

DOCUMENT_ID = ENV['DOCUMENT_ID']

BaseRequestRoute.request(:get, "/documents/#{DOCUMENT_ID}/download")
