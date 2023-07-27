import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /documents/:document_id/download

class GetDocumentDownloadRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_document_download(self):
        path = f"/documents/{document_id}/download"
        return self.make_request("GET", path)

document_id = config['DOCUMENT_ID']

get_document_download_request = GetDocumentDownloadRequest()
document_download = get_document_download_request.get_document_download()

pprint.pprint(document_download)
