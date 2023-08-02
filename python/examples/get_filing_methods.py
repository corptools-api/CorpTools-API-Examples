import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /filing-methods

class GetFilingMethodsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_filing_methods(self, company_id, product_id, jurisdiction):
        params = {
            'company_id': company_id,
            'filing_product_id': product_id,
            'jurisdiction': jurisdiction
        }
        return self.make_request('GET', '/filing-methods', params=params)

company_id = config['COMPANY_ID']
product_id = config['FILING_PRODUCT_ID']
jurisdiction = config['JURISDICTION']

request = GetFilingMethodsRequest()
response = request.get_filing_methods(company_id, product_id, jurisdiction)

pprint.pprint(response)