require 'dotenv'
require 'json'
require 'jwt'
require 'rest-client'

Dotenv.load('../.env')

module BaseRequestRoute

  def self.request(method, path, query_params: nil, body: '')
      debug = ENV['DEBUG']&.downcase == 'true'

      access_key = ENV['ACCESS_KEY']
      secret_key = ENV['SECRET_KEY']
      base_url   = ENV['API_URL']

      p "#{method.to_s.upcase} #{path} query_params=#{query_params} body=#{body}" if debug
      
      payload = {
        path: path,
        content: Digest::SHA2.hexdigest(body)
      }

      headers = { access_key: access_key }

      token = JWT.encode(
          payload,
          secret_key,
          'HS256',
          headers
      )

      p "token=#{token}" if debug

      begin
        res = RestClient::Request.execute(
          method: method,
          url: base_url + path,
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

