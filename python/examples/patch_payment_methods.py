import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

CARD_NUMBER = '6011000990139424'
EXP_MONTH = '09'
EXP_YEAR = '2035'
CVC = '999'
FIRST_NAME = 'Peter'
LAST_NAME = 'Parker'
BILLING_ADDRESS= {
    "city": "New York",
    "state": "NY",
    "zip": "11375",
    "country": "US",
    "address1": "20 Ingram St.",
    "address2": "Queens"
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

# Example of PATCH /payment-methods/:payment_method_id

class PatchPaymentMethodsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def patch_payment_methods(self, payment_method_id):
        body = PAYMENT_METHOD
        path = f'/payment-methods/{payment_method_id}'
        return self.make_request('PATCH', path, body=body)

payment_method_id = config['PAYMENT_METHOD_ID']
request = PatchPaymentMethodsRequest()
response = request.patch_payment_methods(payment_method_id)

pprint.pprint(response)