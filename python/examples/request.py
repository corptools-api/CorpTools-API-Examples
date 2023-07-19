import logging
import hashlib
import json
import jwt
import requests
from dotenv import dotenv_values

config = dotenv_values()

class BaseRequest:
  def __init__(self):
    self.access_key = config['ACCESS_KEY']
    self.secret_key = config['SECRET_KEY']
    self.api_url = config['API_URL']
    self.logger = logging.getLogger(__name__)

  def generate_token(self, path, body):
    headers = {"access_key": self.access_key}
    payload = {
      "path": path,
      "content": hashlib.sha256(body.encode('ascii')).hexdigest()
    }
    return jwt.encode(payload, self.secret_key, algorithm='HS256', headers=headers)
  
  def make_request(self, method, path, body=None, headers=None):
    if headers is None:
      headers = {}
    if body:
      body = json.dumps(body)
    
    try:
      url = self.api_url + path
      headers["Authorization"] = 'Bearer %s' % self.generate_token(path, body)
      headers["Content-Type"] = "application/json"
      response = requests.request(method, url, headers=headers, data=body)

      return response.json()
    except Exception as e:
      self.logger.error(msg="{e}".format(e=e))
      raise e