import pprint
import os
import sys
import json

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of POST /services/:id/info

class PostServicesInfoRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def post_info(self, service_id, service_info):
        return self.make_request('POST', f'/services/{service_id}/info', body=service_info)

service_id = config['SERVICE_ID'];
cwd = os.getcwd();
file_path = f"{cwd}/../data/services/add_info_corp.json";

with open(file_path, 'r') as file:
    service_info = json.load(file)
    request = PostServicesInfoRequest()
    response = request.post_info(service_id, service_info)
    pprint.pprint(response)