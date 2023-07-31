import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /documents/:document_id
# The specified document is saved as a pdf in the 'documents' directory

class GetDocumentRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_document(self):
        path = f"/documents/{document_id}"
        return self.make_request("GET", path)

document_id = config['DOCUMENT_ID']

get_document_request = GetDocumentRequest()
document = get_document_request.get_document()

pprint.pprint(document)
