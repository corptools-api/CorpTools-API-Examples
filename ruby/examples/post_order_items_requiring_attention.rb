require_relative '../request.rb'

# Example of POST /order-items/requiring-attention

COMPANY_ID    = ENV['COMPANY_ID']
ORDER_ITEM_ID = ENV['ORDER_ITEM_ID']
# replace with JSON file for the specific filing
current_directory="#{File.dirname(File.expand_path(__FILE__))}"
FORM_DATA = JSON.parse(File.read("#{current_directory}/../data/form_data.json"))

params = {
  'company_id': COMPANY_ID,
  'form_data': FORM_DATA,
  'order_item_id': ORDER_ITEM_ID
}.to_json

BaseRequestRoute.request(:post, '/order-items/requiring-attention', body: params)