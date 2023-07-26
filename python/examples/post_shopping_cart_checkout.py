import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /shopping-cart/checkout

class PostShoppingCartCheckoutRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_checkout(self,company_id, item_id, payment_method_id):
        body = {
            'company_ids': [company_id],
            'item_ids': [item_id],
            'payment_token': payment_method_id
        }
        return self.make_request('POST', '/shopping-cart/checkout', body=body)

company_id = config['COMPANY_ID']
item_id = config['SHOPPING_CART_ITEM_ID']
payment_method_id = config['PAYMENT_METHOD_ID']

request = PostShoppingCartCheckoutRequest()
response = request.post_checkout(company_id, item_id, payment_method_id)

pprint.pprint(response)