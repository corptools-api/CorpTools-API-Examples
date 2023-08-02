import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /documents/:document_id/page/:page_number

# The specified page of the document is saved as a png in the 'documents' directory

class GetDocumentPageRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_document_page(self):
        path = f"/documents/{document_id}/page/{page_number}"
        return self.make_request("GET", path)

document_id = config['DOCUMENT_ID']
page_number = config['PAGE_NUMBER']

get_document_page_request = GetDocumentPageRequest()
page = get_document_page_request.get_document_page()

pprint.pprint(page)
