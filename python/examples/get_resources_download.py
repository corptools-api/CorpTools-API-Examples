import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /resources/:resource_id/download

# The specified resource is saved as a pdf in the 'documents' directory

class GetResourcesDownloadRequest(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_resources_download(self):
        path = f"/resources/{resource_id}/download"
        return self.make_request("GET", path)

resource_id = config['AGENCY_RESOURCE_ID']

request = GetResourcesDownloadRequest()
response = request.get_resources_download()

pprint.pprint(response)
