import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /services/:id/cancel-request

class PostServicesCancelRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_cancel(self, service_id):
        return self.make_request('POST', f'/services/{service_id}/cancel-request')

service_id = config['SERVICE_ID'];

request = PostServicesCancelRequest()
response = request.post_cancel(service_id)
pprint.pprint(response)