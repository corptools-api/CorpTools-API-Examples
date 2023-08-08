import pprint
import os
import sys

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from request import BaseRequest

# Example of GET /account/dashpanel

class GetAccountDashPanelRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_account_dashpanel(self):
        path = "/account/dashpanel"
        return self.make_request("GET", path)

# run as standalone script by passing any command line argument
if len(sys.argv) > 1:
    request = GetAccountDashPanelRequest()
    account = request.get_account_dashpanel()

    pprint.pprint(account)