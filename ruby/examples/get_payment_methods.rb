require_relative '../request.rb'

# Example of GET /payment-methods

BaseRequestRoute.request(:get, '/payment-methods')