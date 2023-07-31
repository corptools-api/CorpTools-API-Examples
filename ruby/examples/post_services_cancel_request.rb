require_relative '../request.rb'

# Example of POST /services/:id/cancel-request

SERVICE_ID = ENV['SERVICE_ID']

BaseRequestRoute.request(:post, "/services/#{SERVICE_ID}/cancel-request")