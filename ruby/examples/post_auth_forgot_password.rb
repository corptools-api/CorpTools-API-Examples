require_relative '../request.rb'

# Example of POST /auth/forgot-password

EMAIL = ENV['EMAIL']
SUBDOMAIN = ENV['SUBDOMAIN'] # optional
WEBSITE_ID = ENV['WEBSITE_ID'] # optional

params = {
  'email_address': EMAIL,
  # 'subdomain': SUBDOMAIN,
  'website_id': WEBSITE_ID
}.to_json

BaseRequestRoute.request(:post, '/auth/forgot-password', body: params)