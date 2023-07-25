import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example POST /callbacks

class PostCallbacksRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_callbacks(self, url):
        path = "/callbacks"
        body = { 'url': url }
        return self.make_request("POST", path, body=body)

url = config['CALLBACK_URL']

post_callbacks_request = PostCallbacksRequest()
post_callbacks_response = post_callbacks_request.post_callbacks(url)

pprint.pprint(post_callbacks_response)