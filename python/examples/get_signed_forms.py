import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /signed-forms

class GetSignedFormsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_signed_forms(self, filing_method_id, website_id):
        params = {
            'filing_method_id': filing_method_id,
            'website_id': website_id
        }
        return self.make_request('GET', '/signed-forms', params=params)

filing_method_id = config['FILING_METHOD_ID']
website_id  = config['WEBSITE_ID']

request = GetSignedFormsRequest()
response = request.get_signed_forms(filing_method_id, website_id)

pprint.pprint(response)