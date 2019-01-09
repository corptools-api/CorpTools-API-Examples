require 'jwt'
require 'rest-client'
require 'json'

access_key = 'xxxx'
secret_key = 'xxxx'

body = { companies: [
	{ 
		name: 'Sample Z', 
		entity_type: 'Limited Liability Company', 
		jurisdictions: ['Maine', 'Washington']
	}
]}.to_json

payload = {
  path: '/companies',
  content: Digest::SHA2.hexdigest(body)
}

headers = { access_key: access_key }

token = JWT.encode(
    payload,
    secret_key,
    'HS256',ß
    headers
)

begin
  res = RestClient::Request.execute(
    method: :post,
    url: 'https://api.corporatetools.com/companies',
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

