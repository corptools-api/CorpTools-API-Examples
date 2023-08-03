require_relative '../request.rb'

# Example of DELETE /shopping-cart

COMPANY_ID = ENV['COMPANY_ID']
ITEM_ID    = ENV['SHOPPING_CART_ITEM_ID']

body = {
   company_ids: [COMPANY_ID],
   item_ids: [ITEM_ID]
}.to_json

BaseRequestRoute.request(:delete, '/shopping-cart', body: body)
