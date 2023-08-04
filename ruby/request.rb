require 'dotenv'
require 'json'
require 'jwt'
require 'rest-client'
require 'base64'

Dotenv.load('../.env')

module BaseRequestRoute

  DEBUG       = ENV['DEBUG']&.downcase == 'true'
  ACCESS_KEY  = ENV['ACCESS_KEY']
  SECRET_KEY  = ENV['SECRET_KEY']
  BASE_URL    = ENV['API_URL']

  def self.request(method, path, query_params: {}, body: '')
    p "#{method.to_s.upcase} #{path} query_params=#{query_params} body=#{body}" if DEBUG

    payload = {
      path: path,
      content: Digest::SHA2.hexdigest(body)
    }

    url = "#{BASE_URL}#{path}"

    headers = { access_key: ACCESS_KEY }

    token = JWT.encode(
      payload,
      SECRET_KEY,
      'HS256',
      headers
    )

    p "token=#{token}" if DEBUG

    if method == :get && !query_params.empty?
      query_string = []

      query_params.each do |key, val|
        case val
        when Array
          val.each do |v|
            query_string << "#{key}[]=#{URI.encode_www_form_component(v)}"
          end
        when Hash
          serialized_hash = URI.encode_www_form_component(val.to_json)
          query_string << "#{key}=#{serialized_hash}"
        else
          query_string << "#{key}=#{URI.encode_www_form_component(val)}"
        end
      end
      url = "#{BASE_URL}#{path}?#{query_string.join('&')}"
    end

    begin
        res = RestClient::Request.execute(
          method: method,
          url: url,
          payload: body,
          headers: {
            authorization: "Bearer #{token}",
            content_type: :json
          }
        )

        puts "Response status code: #{res.code}"

        request_name = method.to_s + path.gsub('/', '_')

        if res.headers[:content_type] == 'image/png'
          File.open("./documents/#{request_name}_response.png", 'wb') do |file|
            file.write(res.body)
          end
          puts "Image saved as #{request_name}_response.png"
        elsif res.headers[:content_type] == 'application/pdf'
          File.open("./documents/#{request_name}_response.pdf", 'wb') do |file|
            file.write(res.body)
          end
          puts "PDF saved as get_#{request_name}_response.pdf"
    else
      puts JSON.pretty_generate(JSON.parse(res.body))
      JSON.parse(res.body)
    end
    rescue StandardError => error
      puts error
      puts error.http_body if defined?(error.http_body) && error.to_s != '500 Internal Server Error'
      puts error.res if defined?(error.res)
      end
    end
end
