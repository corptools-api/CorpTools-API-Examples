require_relative '../request.rb'

# Example of DELETE /callbacks/:id

CALLBACK_ID = ENV['CALLBACK_ID']

BaseRequestRoute.request(:delete, "/callbacks/#{CALLBACK_ID}")