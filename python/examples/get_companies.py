import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

class GetCompaniesRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_companies(self):
        path = f"/companies"
        return self.make_request("GET", path)

get_companies_request = GetCompaniesRequest()
companies = get_companies_request.get_companies()

pprint.pprint(companies)