require_relative '../request.rb'

# Example of DELETE /callbacks/:callback_id

CALLBACK_ID = ENV['CALLBACK_ID']

BaseRequestRoute.request(:delete, "/callbacks/#{CALLBACK_ID}")