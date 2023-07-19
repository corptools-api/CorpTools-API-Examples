import pprint
from request import BaseRequest
from dotenv import dotenv_values

config = dotenv_values()

class ComplianceEventsRequest(BaseRequest):
    def __init__(self):
        super().__init__()
    
    def get_compliance_events(self, start_date, end_date, limit=40):
        path = "/compliance-events"
        body = { 'start_date': start_date, 'end_date': end_date, 'limit': limit }
        return self.make_request("GET", path, body)

start_date = config['START_DATE']
end_date = config['END_DATE']

compliance_request = ComplianceEventsRequest()
compliance_events = compliance_request.get_compliance_events(start_date, end_date)

pprint.pprint(compliance_events)