require_relative '../request.rb'

# Example of POST /services/:service_id/cancel-request

SERVICE_ID = ENV['SERVICE_ID']

BaseRequestRoute.request(:post, "/services/#{SERVICE_ID}/cancel-request")