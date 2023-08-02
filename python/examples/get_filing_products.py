import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /filing-products

class GetFilingProductsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_filing_products(self, url, jurisdiction):
        path = "/filing-products"
        params = { 'url': url, 'jurisdiction': jurisdiction }
        return self.make_request("GET", path, params=params)

url = config['WEBSITE_URL']
jurisdiction = config['JURISDICTION']

filing_products_request = GetFilingProductsRequest()
filing_products = filing_products_request.get_filing_products(url, jurisdiction)

pprint.pprint(filing_products)
