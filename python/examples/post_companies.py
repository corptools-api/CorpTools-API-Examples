import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /companies

class PostCompaniesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_companies(self, name, home_state, entity_type):
        path = "/companies"
        body = {'companies': [{'name': name, 'home_state': home_state, 'entity_type': entity_type}]}
        return self.make_request("POST", path, body=body)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    name = config['COMPANY_NAME']
    home_state = config['JURISDICTION']
    entity_type = config['ENTITY_TYPE']

    post_companies_request = PostCompaniesRequest()
    post_companies_response = post_companies_request.post_companies(name, home_state, entity_type)

    pprint.pprint(post_companies_response)