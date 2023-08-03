import pprint
import os
import sys
import json

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /order-items/requiring-attention

class PostOrderItemsRequiringAttentionRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_requring_attention(self, company_id, order_item_id, form_data):
        body = {
            'company_id': company_id,
            'order_item_id': order_item_id,
            'form_data': form_data
        }
        return self.make_request('POST', '/order-items/requiring-attention', body=body)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    ORDER_ITEM_ID = config['ORDER_ITEM_ID']
    COMPANY_ID = config['COMPANY_ID']
    cwd = os.getcwd();
    file_path = f"{cwd}/../data/form_data_ein_tax_id.json";

    with open(file_path, 'r') as file:
        FORM_DATA = json.load(file)
        print(f"form_data: {FORM_DATA}\n")
        request = PostOrderItemsRequiringAttentionRequest()
        response = request.post_requring_attention(COMPANY_ID, ORDER_ITEM_ID, FORM_DATA)
        pprint.pprint(response)