import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# GET /filing-methods/schemas
class GetFilingMethodsSchemasRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_filing_methods_schemas(self, company_id, method_id):
        params = {
            'company_id': company_id,
            'filing_method_id': method_id
        }
        return self.make_request('GET', '/filing-methods/schemas', params=params)

company_id = config['COMPANY_ID']
method_id = config['FILING_METHOD_ID']

request = GetFilingMethodsSchemasRequest()
response = request.get_filing_methods_schemas(company_id, method_id)

pprint.pprint(response)
