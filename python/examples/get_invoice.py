import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /invoices/:invoice_id

class GetInvoiceRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_invoice(self, id):
        path = f"/invoices/{id}"
        return self.make_request("GET", path)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    invoice_id = config['INVOICE_ID']

    get_invoice_request = GetInvoiceRequest()
    invoice = get_invoice_request.get_invoice(invoice_id )

    pprint.pprint(invoice)
