import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

CARD_NUMBER = '6011000990139424'
EXP_MONTH = '12'
EXP_YEAR = '2028'
CVC = '123'
FIRST_NAME = 'Abby'
LAST_NAME = 'Cadabby'
BILLING_ADDRESS= {
    "city": "New York",
    "state": "NY",
    "zip": "10463",
    "country": "US",
    "address1": "1314 Seasame Street",
    "address2": ""
}

PAYMENT_METHOD = { 
    'number': CARD_NUMBER,
    'exp_month': EXP_MONTH,
    'exp_year': EXP_YEAR,
    'cvc': CVC,
    'first_name': FIRST_NAME,
    'last_name': LAST_NAME,
    'billing_address': BILLING_ADDRESS
}

# Example of POST /payment-methods

class PostPaymentMethodsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_payment_methods(self):
        body = PAYMENT_METHOD
        return self.make_request('POST', '/payment-methods', body=body)

request = PostPaymentMethodsRequest()
response = request.post_payment_methods()

pprint.pprint(response)