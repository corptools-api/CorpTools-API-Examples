require_relative '../request.rb'

# Example POST /payment-methods

CARD_NUMBER = '6011111111111117'
EXP_MONTH = '12'
EXP_YEAR = '2028'
CVC = '456'
FIRST_NAME = 'Ernie'
LAST_NAME = 'Bert'
BILLING_ADDRESS= {
    "city": "New York",
    "state": "NY",
    "zip": "10463",
    "country": "US",
    "address1": "1415 Seasame Street",
    "address2": nil
  }

body = { 
	number: CARD_NUMBER,
	exp_month: EXP_MONTH,
	exp_year: EXP_YEAR,
	cvc: CVC,
	first_name: FIRST_NAME,
	last_name: LAST_NAME,
	billing_address: BILLING_ADDRESS
}.to_json

BaseRequestRoute.request(:post, '/payment-methods', body: body)