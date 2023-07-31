require_relative '../request.rb'

# Example of POST /auth/login

EMAIL = ENV['EMAIL']
PASSWORD = ENV['PASSWORD']
WEBSITE_ID = ENV['WEBSITE_ID'] # optional

params = {
  'email': EMAIL,
  'password': PASSWORD,
  'website_id': WEBSITE_ID
}.to_json

BaseRequestRoute.request(:post, '/auth/login', body: params)