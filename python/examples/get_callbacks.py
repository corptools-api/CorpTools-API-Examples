import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest

# Example of GET /callbacks

class GetCallbacksRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_callbacks(self):
        path = "/callbacks"
        return self.make_request("GET", path)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    get_callbacks_request = GetCallbacksRequest()
    callbacks = get_callbacks_request.get_callbacks()

    pprint.pprint(callbacks)