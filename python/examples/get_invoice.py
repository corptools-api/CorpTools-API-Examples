import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

class GetInvoiceRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_invoice(self):
        path = f"/invoices/{invoice_id}"
        return self.make_request("GET", path)

invoice_id = config['INVOICE_ID']

get_invoice_request = GetInvoiceRequest()
invoice = get_invoice_request.get_invoice()

pprint.pprint(invoice)
