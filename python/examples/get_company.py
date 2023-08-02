import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /companies/:id

class GetCompanyRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_company(self):
        path = f"/companies/{company_id}"
        return self.make_request("GET", path)

company_id = config['COMPANY_ID']

get_company_request = GetCompanyRequest()
company = get_company_request.get_company()

pprint.pprint(company)