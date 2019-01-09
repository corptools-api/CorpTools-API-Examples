require 'jwt'
require 'rest-client'
require 'json'

access_key = 'xxxx'
secret_key = 'xxxx'

body = { status: 'unread' }.to_json

payload = {
  path: '/documents',
  content: Digest::SHA2.hexdigest(body)
}

headers = { access_key: access_key }

token = JWT.encode(
    payload,
    secret_key,
    'HS256',
    headers
)

begin
  res = RestClient::Request.execute(
    method: :get,
    url: 'https://api.corporatetools.com/documents',
    payload: body,
    headers: {
      authorization: "Bearer #{token}",
      content_type: :json
    }
  )
  
  pp JSON(res.body)
rescue

  pp JSON($!.response)
end
