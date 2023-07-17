import logging
import hashlib
import json
import jwt
import requests
from dotenv import dotenv_values

config = dotenv_values()

ACCESS_KEY = config['ACCESS_KEY']
SECRET_KEY = config['SECRET_KEY']
API_URL    = config['API_URL']

logger = logging.getLogger(__name__)

path = "/companies"
body = json.dumps({'companies': [{'name': 'XYZ Company', 'jurisdictions': ['Maine'], 'entity_type': 'Limited Liability Company'}]})

headers = {"access_key": ACCESS_KEY}
payload = {
    "path": path,
    "content": hashlib.sha256(body.encode('ascii')).hexdigest()
}

token = jwt.encode(payload, SECRET_KEY, algorithm='HS256', headers=headers)

try:
    url = API_URL + "/companies"
    headers = {"Authorization": 'Bearer %s'%(token), "Content-Type": "json"}
    r = requests.post(url, headers=headers, data=body)

    print(r.json())
except Exception as e:
    logger.error(msg="{e}".format(e=e))
    raise e
