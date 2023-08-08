require_relative '../request.rb'

# Example of DELETE /payment-methods/:payment_method_id

PAYMENT_METHOD_ID = ENV['PAYMENT_METHOD_ID']

BaseRequestRoute.request(:delete, "/payment-methods/#{PAYMENT_METHOD_ID}")