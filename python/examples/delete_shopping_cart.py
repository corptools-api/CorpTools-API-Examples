import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of DELETE /shopping-cart

class DeleteShoppingCartRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def delete_shopping_cart(self, company_id, item_id):
        body = {
            'company_ids': [company_id],
            'item_ids': [item_id]
        }
        return self.make_request('DELETE', '/shopping-cart', body=body)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    company_id = config['COMPANY_ID']
    item_id = config['SHOPPING_CART_ITEM_ID']

    request = DeleteShoppingCartRequest()
    response = request.delete_shopping_cart(company_id, item_id)

    pprint.pprint(response)
