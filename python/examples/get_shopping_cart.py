import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /shopping-cart

class GetShoppingCartRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_shopping_cart(self, company_ids):
        params = {
            'company_ids': company_ids
        }
        return self.make_request('GET', '/shopping-cart', params=params)

company_id  = config['COMPANY_ID']
company_ids = [company_id]

request = GetShoppingCartRequest()
response = request.get_shopping_cart(company_ids)

pprint.pprint(response)