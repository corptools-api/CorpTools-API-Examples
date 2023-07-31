require_relative '../request.rb'

# Example of GET /documents/bulk-download

DOCUMENT_ID = ENV['DOCUMENT_ID']

params = {
  ids: [DOCUMENT_ID]
}

BaseRequestRoute.request(:get, '/documents/bulk-download', query_params: params)
