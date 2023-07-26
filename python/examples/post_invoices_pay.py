import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()
# Example of POST /invoices/pay
class PostInvoicesPayRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def post_invoices_pay(self, payment_method_id, invoice_ids):
        path = "/invoices/pay"
        body = {
            'payment_token': payment_method_id,
            'invoice_ids': [invoice_ids]
        }
        return self.make_request("POST", path, body=body)

payment_method_id = config['PAYMENT_METHOD_ID']
invoice_ids = config['INVOICE_ID']

post_invoices_pay_request = PostInvoicesPayRequest()
post_invoices_pay_response = post_invoices_pay_request.post_invoices_pay(payment_method_id, invoice_ids)

pprint.pprint(post_invoices_pay_response)
