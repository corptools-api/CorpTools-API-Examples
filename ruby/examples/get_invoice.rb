require_relative '../request.rb'

# GET /invoices/:invoice_id
INVOICE_ID = ENV['INVOICE_ID']

BaseRequestRoute.request(:get, "/invoices/#{INVOICE_ID}")
