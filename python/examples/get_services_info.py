import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /services/:service_id/info

class GetServicesInfoRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_info(self, service_id):
        return self.make_request('GET', f'/services/{service_id}/info')

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    service_id = config['SERVICE_ID']

    request = GetServicesInfoRequest()
    response = request.get_info(service_id)

    pprint.pprint(response)