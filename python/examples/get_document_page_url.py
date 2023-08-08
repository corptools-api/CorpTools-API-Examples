import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /documents/:document_id/page/:page_number/url

class GetDocumentPageUrlRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_document_page_url(self):
        path = f"/documents/{document_id}/page/{page_number}/url"
        return self.make_request("GET", path)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    document_id = config['DOCUMENT_ID']
    page_number = config['PAGE_NUMBER']

    get_document_page_url_request = GetDocumentPageUrlRequest()
    url = get_document_page_url_request.get_document_page_url()

    pprint.pprint(url)
