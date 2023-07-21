import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

class PatchCompaniesRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def patch_companies(self, company, name, home_state, entity_type):
         path = "/companies"
         body = {'companies': [{'company': company, 'name': name, 'home_state': home_state, 'entity_type': entity_type}]}
         return self.make_request("PATCH", path, body=body)

#  this example will update the company name, home_state, and entity_type
company = config['COMPANY_NAME']
name = 'The Best Fake Company'
home_state = 'Arizona'
entity_type = 'Corporation'

patch_companies_request = PatchCompaniesRequest()
patch_companies_response = patch_companies_request.patch_companies(company, name, home_state, entity_type)

pprint.pprint(patch_companies_response)
