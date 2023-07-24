require_relative '../request.rb'

INVOICE_ID = ENV['INVOICE_ID']

BaseRequestRoute.request(:get, "/invoices/#{INVOICE_ID}")
