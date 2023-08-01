import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /resources/:id/page/:page

class GetResourcePageRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_resource_page(self, resource_id, page):
        return self.make_request('GET', f'/resources/{resource_id}/page/{page}')

resource_id = config['AGENCY_RESOURCE_ID']
page = 1
request = GetResourcePageRequest()
response = request.get_resource_page(resource_id, page)

pprint.pprint(response)