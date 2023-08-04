import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of DELETE /callbacks/:callback_id

class DeleteCallbacksRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def delete_callbacks(self, callback_id):
        return self.make_request('DELETE', f'/callbacks/{callback_id}')

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    callback_id = config['CALLBACK_ID']

    request = DeleteCallbacksRequest()
    response = request.delete_callbacks(callback_id)

    pprint.pprint(response)