require_relative '../request.rb'

# Example of POST /shopping-cart

COMPANY_ID			= ENV['COMPANY_ID']
FILING_PRODUCT_ID 	= ENV['FILING_PRODUCT_ID']
FILING_METHOD_ID 	= ENV['FILING_METHOD_ID']
QUANTITY = 1
# const FORM_DATA = {}; # optional, expects JSON mapping to fields of filing method schema

body = {
	company_id: COMPANY_ID,
	product_id: FILING_PRODUCT_ID,
	product_option_id: FILING_METHOD_ID,
	quantity: QUANTITY,
	#form_data: FORM_DATA
}.to_json

BaseRequestRoute.request(:post, '/shopping-cart', body: body)