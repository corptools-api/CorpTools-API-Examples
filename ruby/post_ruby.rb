require 'dotenv'
require 'json'
require 'jwt'
require 'rest-client'

Dotenv.load

access_key = ENV['ACCESS_KEY']
secret_key = ENV['SECRET_KEY']
base_url   = ENV['API_URL']

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
    'HS256',
    headers
)

begin
  res = RestClient::Request.execute(
    method: :post,
    url: base_url + '/companies',
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

