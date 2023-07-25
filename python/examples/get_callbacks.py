import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /callbacks

class GetCallbacksRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_callbacks(self):
        path = "/callbacks"
        return self.make_request("GET", path)

get_callbacks_request = GetCallbacksRequest()
callbacks = get_callbacks_request.get_callbacks()

pprint.pprint(callbacks)