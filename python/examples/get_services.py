import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /services

class GetServicesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_services(self, company_id, company_name, limit, offset):
        params = {
            'company_id': company_id,
            # 'company_name': company_name,
            # 'limit': limit,
            # 'offset': offset
        }
        return self.make_request('GET', '/services', params=params)

company_id  = config['COMPANY_ID']
company_name  = config['COMPANY_NAME']
limit = 3
offset = 0

request = GetServicesRequest()
response = request.get_services(company_id, company_name, limit, offset)

pprint.pprint(response)