require_relative '../request.rb'

# Example of GET /documents

params = { status: ENV['STATUS'] }.to_json

BaseRequestRoute.request(:get, '/documents', query_params: params)
