import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /services

class PostServicesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_services(self, company_id, company_name, jurisdiction_id):
        body = {
            'company_id': company_id,
            # 'company': company_name, 
            'jurisdiction_ids': [jurisdiction_id]
        }
        return self.make_request('POST', '/services', body=body)

company_id = config['COMPANY_ID'];
company_name = config['COMPANY_NAME'];
jurisdiction_id = config['JURISDICTION_ID'];

request = PostServicesRequest()
response = request.post_services(company_id, company_name, jurisdiction_id)

pprint.pprint(response)