require_relative '../request.rb'

# Example of POST /shopping-cart/checkout

COMPANY_ID        = ENV['COMPANY_ID']
ITEM_ID           = ENV['SHOPPING_CART_ITEM_ID']
PAYMENT_METHOD_ID = ENV['PAYMENT_METHOD_ID']

parameters = {
  'payment_token': PAYMENT_METHOD_ID,
  'company_ids': [COMPANY_ID],
  'item_ids': [ITEM_ID]
}.to_json

BaseRequestRoute.request(:post, '/shopping-cart/checkout', body: parameters)