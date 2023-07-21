require_relative '../request.rb'

# Example DELETE /payment-methods/:id

PAYMENT_METHOD_ID = ENV['PAYMENT_METHOD_ID']

BaseRequestRoute.request(:delete, "/payment-methods/#{PAYMENT_METHOD_ID}")