require_relative '../request.rb'

# Example of GET /documents

params = { status: 'unread' }.to_json

BaseRequestRoute.request(:get, '/documents', query_params: params)
