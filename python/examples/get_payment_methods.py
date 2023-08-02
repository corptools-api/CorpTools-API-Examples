import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /payment-methods

class GetPaymentMethodsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_payment_methods(self):
        return self.make_request('GET', '/payment-methods')

request = GetPaymentMethodsRequest()
response = request.get_payment_methods()

pprint.pprint(response)