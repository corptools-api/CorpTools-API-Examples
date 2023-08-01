import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /registered-agent-products

class GetRegisteredAgentProductsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_products(self, website_url):
        params = {
            'url': website_url
        }
        return self.make_request('GET', '/registered-agent-products', params=params)

website_url = config['WEBSITE_URL']

request = GetRegisteredAgentProductsRequest()
response = request.get_products(website_url)

pprint.pprint(response)