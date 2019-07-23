import logging
import hashlib
import json
import jwt
import requests

ACCESS_KEY = 'xxxxx'
SECRET_KEY = 'xxxxx'

logger = logging.getLogger(__name__)

path = "/compliance-events"
body = json.dumps({ 'start_date': 'Aug 1, 2018', 'end_date': 'Dec 31, 2018', 'limit': 40 })

headers = {"access_key": ACCESS_KEY}
payload = {
    "path": path,
    "content": hashlib.sha256(body.encode('ascii')).hexdigest()
}

token = jwt.encode(payload, SECRET_KEY, algorithm='HS256', headers=headers).decode('utf-8')

try:
    url = "https://api.corporatetools.com/compliance-events"
    headers = {"Authorization": 'Bearer %s'%(token), "Content-Type": "json"}
    r = requests.get(url, headers=headers, data=body)

    print(r.json())
except Exception as e:
    logger.error(msg="{e}".format(e=e))
    raise e
