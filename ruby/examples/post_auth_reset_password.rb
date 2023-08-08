require_relative '../request.rb'

# Example of POST /auth/reset-password

TOKEN = ENV['RESET_PASSWORD_TOKEN']
PASSWORD = ENV['PASSWORD']

params = {
  'token': TOKEN,
  'password': PASSWORD,
  'password_confirmation': PASSWORD 
}.to_json

BaseRequestRoute.request(:post, '/auth/reset-password', body: params)