require_relative '../request.rb'

# Example of POST /services/:id/info

SERVICE_ID = ENV['SERVICE_ID']

current_directory="#{File.dirname(File.expand_path(__FILE__))}"
body = JSON.parse(File.read("#{current_directory}/../../data/services/add_info_corp.json"))

BaseRequestRoute.request(:post, "/services/#{SERVICE_ID}/info", body: body)