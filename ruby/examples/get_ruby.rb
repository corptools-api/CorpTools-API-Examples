require_relative '../request.rb'

params = { status: 'unread' }.to_json

BaseRequestRoute.request(:get, '/documents', body: params)
