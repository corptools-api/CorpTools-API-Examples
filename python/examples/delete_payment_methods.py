import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of DELETE /payment-methods/:id

class DeletePaymentMethodsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def delete_payment_methods(self, payment_method_id):
        return self.make_request('DELETE', f'/payment-methods/{payment_method_id}')

payment_method_id = config['PAYMENT_METHOD_ID']

request = DeletePaymentMethodsRequest()
response = request.delete_payment_methods(payment_method_id)

pprint.pprint(response)