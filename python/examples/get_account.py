import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest

# Example of GET /account

class GetAccountRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_account(self):
        path = "/account"
        return self.make_request("GET", path)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    get_account_request = GetAccountRequest()
    account = get_account_request.get_account()

    pprint.pprint(account)