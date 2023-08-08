import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

# Example of GET /websites

class GetWebsites(BaseRequest):
    def __init__(self):
        super().__init__()

    def get_websites(self, url):
        params = {
            'url': website_url
        }
        return self.make_request('GET', '/websites', params=params)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    website_url  = config['WEBSITE_URL']

    request = GetWebsites()
    response = request.get_websites(website_url)

    pprint.pprint(response)
