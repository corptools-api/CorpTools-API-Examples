require_relative '../request.rb'

# Example GET /payment-methods

BaseRequestRoute.request(:get, '/payment-methods')