import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /invoices
# An array of company names or company_ids may be provided, but not both

class GetInvoicesRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_invoices(self, company_ids):
        params = {
            'company_ids': company_ids
        }
        return self.make_request('GET', '/shopping-cart', params=params)

company_id  = config['COMPANY_ID']
company_ids = [company_id]

request = GetInvoicesRequest()
response = request.get_invoices(company_ids)

pprint.pprint(response)
