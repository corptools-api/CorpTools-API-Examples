import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /documents

class GetDocumentsRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_documents(self, status):
        params = {
            'status': status
        }
        path = "/documents"
        return self.make_request("GET", path, params=params)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    status = config['STATUS']

    get_documents_request = GetDocumentsRequest()
    get_documents_response = get_documents_request.get_documents(status)

    pprint.pprint(get_documents_response)
