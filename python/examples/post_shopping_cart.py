import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /shopping-cart

class PostShoppingCartRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_shopping_cart(self, company_id, filing_product_id, filing_method_id, quantity):
        body = {
            'company_id': company_id,
            'product_id': filing_product_id, 
            'product_option_id': filing_method_id,
            'quantity': 1
        }
        return self.make_request('POST', '/shopping-cart', body=body)

company_id = config['COMPANY_ID'];
filing_product_id = config['FILING_PRODUCT_ID'];
filing_method_id  = config['FILING_METHOD_ID'];
quantity = 1;
# form_data = {}; # optional, expects JSON mapping to fields of filing method schema

request = PostShoppingCartRequest()
response = request.post_shopping_cart(company_id, filing_product_id, filing_method_id, quantity)

pprint.pprint(response)