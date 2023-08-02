import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /resources/:resource_id/page/:page_number

class GetResourcePageRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_resource_page(self, resource_id, page_number):
        return self.make_request('GET', f'/resources/{resource_id}/page/{page_number}')

resource_id = config['AGENCY_RESOURCE_ID']
page_number = config['PAGE_NUMBER']
request = GetResourcePageRequest()
response = request.get_resource_page(resource_id, page_number)

pprint.pprint(response)