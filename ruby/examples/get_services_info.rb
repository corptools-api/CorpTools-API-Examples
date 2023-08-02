require_relative '../request.rb'

# Example of GET /services/:service_id/info

SERVICE_ID = ENV['SERVICE_ID']

params = {
	service_id: SERVICE_ID,
}

BaseRequestRoute.request(:get, "/services/#{SERVICE_ID}/info", query_params: params)