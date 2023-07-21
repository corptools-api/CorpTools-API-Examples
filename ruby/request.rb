require 'dotenv'
require 'json'
require 'jwt'
require 'rest-client'

Dotenv.load('../.env')

module BaseRequestRoute

  DEBUG       = ENV['DEBUG']&.downcase == 'true'
  ACCESS_KEY  = ENV['ACCESS_KEY']
  SECRET_KEY  = ENV['SECRET_KEY']
  BASE_URL    = ENV['API_URL']

  def self.request(method, path, query_params: nil, body: '')
      p "#{method.to_s.upcase} #{path} query_params=#{query_params} body=#{body}" if DEBUG
      
      payload = {
        path: path,
        content: Digest::SHA2.hexdigest(body)
      }

      headers = { access_key: ACCESS_KEY }

      token = JWT.encode(
          payload,
          SECRET_KEY,
          'HS256',
          headers
      )

      p "token=#{token}" if DEBUG

      begin
        res = RestClient::Request.execute(
          method: method,
          url: BASE_URL + path,
          payload: query_params || body,
          headers: {
            authorization: "Bearer #{token}",
            content_type: :json
          }
        )
        
        pp JSON(res.body)
      rescue

        pp JSON($!.response)
      end

    end
end