import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /services

class GetServicesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_services(self, company_id, company_name):
        params = {
            'company_id': company_id,
            # 'company_name': company_name
        }
        return self.make_request('GET', '/services', params=params)

company_id  = config['COMPANY_ID']
company_name  = config['COMPANY_NAME']

request = GetServicesRequest()
response = request.get_services(company_id, company_name)

pprint.pprint(response)