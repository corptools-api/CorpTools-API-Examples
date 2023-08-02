import logging
import hashlib
import json
from multiprocessing.sharedctypes import Value
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

  def generate_token(self, path, payload):
    headers = {"access_key": self.access_key}
    payload_data = {
      "path": path,
      "content": hashlib.sha256(payload.encode('ascii')).hexdigest()
    }
    return jwt.encode(payload_data, self.secret_key, algorithm='HS256', headers=headers)
  
  def make_request(self, method, path, params=None, body=None, headers=None):
    if headers is None:
      headers = {}
    if params and body:
      raise ValueError("Both 'params' and 'body' cannot be provided simultaneously. Please modify request.")
    if params:
        payload = json.dumps(params)
    elif body:
      payload = json.dumps(body)
    else:
      payload = ""
    
    try:
      url = self.api_url + path
      headers["Authorization"] = 'Bearer %s' % self.generate_token(path, payload)
      headers["Content-Type"] = "application/json"
      print(f'{method} {path} body={body}')
      response = requests.request(method, url, headers=headers, data=payload)
      request_name = method.lower() + path.replace('/', '_')

      if response.headers.get("content-type") == "application/json":
        return response.json()
      elif response.headers.get("content-type") == "image/png":
        with open(f'./documents/{request_name}_response.png', 'wb') as file:
            file.write(response.content)
        print(f'PNG image saved as {request_name}_response.png')
        return "PNG image downloaded."
      elif response.headers.get("content-type") == "application/pdf":
        with open(f'./documents/{request_name}_response.pdf', 'wb') as file:
            file.write(response.content)
        print(f'PDF file saved as {request_name}_response.pdf')
        return "PDF file downloaded"
      else:
        return response.text

    except Exception as e:
      self.logger.error(msg="{e}".format(e=e))
      raise e
