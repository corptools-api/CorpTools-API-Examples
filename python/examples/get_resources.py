import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest

# Example of GET /resources

class GetResourcesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_resources(self):
        return self.make_request('GET', '/resources')

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    request = GetResourcesRequest()
    response = request.get_resources()

    pprint.pprint(response)