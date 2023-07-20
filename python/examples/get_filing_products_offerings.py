import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

class GetFilingProductsOfferingsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_filing_products_offerings(self, company_id, jurisdiction):
        params = {
            'company_id': company_id,
            'jurisdiction': jurisdiction
        }
        return self.make_request('GET', '/filing-products/offerings', params=params)

company_id = config['COMPANY_ID']
jurisdiction = config['JURISDICTION']

request = GetFilingProductsOfferingsRequest()
response = request.get_filing_products_offerings(company_id, jurisdiction)

pprint.pprint(response)