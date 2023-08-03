import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /order-items/requiring-attention

class GetOrderItemsRequiringAttentionRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_requiring_attention(self, company_ids):
        params = {
            'company_ids': company_ids
        }
        return self.make_request('GET', '/order-items/requiring-attention', params=params)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    company_id = config['COMPANY_ID']
    company_ids = [company_id]

    request = GetOrderItemsRequiringAttentionRequest()
    response = request.get_requiring_attention(company_ids)

    pprint.pprint(response)