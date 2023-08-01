import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example GET /documents/bulk-download

class GetDocumentsBulkDownloadRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def bulk_download_documents(self, company_ids):
        params = {
            'ids': document_ids
        }
        return self.make_request('GET', '/documents/bulk-download', params=params)

document_id  = config['DOCUMENT_ID']
document_ids = [document_id]

request = GetDocumentsBulkDownloadRequest()
response = request.bulk_download_documents(document_ids)

pprint.pprint(response)
