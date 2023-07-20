import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

class PostCompaniesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_companies(self, name, jurisdictions, entity_type):
        path = "/companies"
        body = {'companies': [{'name': name, 'jurisdiction': [jurisdictions], 'entity_type': entity_type}]}
        return self.make_request("POST", path, body=body)

name = config['COMPANY_NAME']
jurisdictions = config['JURISDICTIONS']
entity_type = config['ENTITY_TYPE']

post_companies_request = PostCompaniesRequest()
post_companies_response = post_companies_request.post_companies(name, jurisdictions, entity_type)

pprint.pprint(post_companies_response)