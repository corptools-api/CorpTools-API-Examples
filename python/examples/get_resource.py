import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /resources/:id

class GetResourceRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_resource(self, resource_id):
        return self.make_request('GET', f'/resources/{resource_id}')

resource_id = config['AGENCY_RESOURCE_ID']
request = GetResourceRequest()
response = request.get_resource(resource_id)

pprint.pprint(response)