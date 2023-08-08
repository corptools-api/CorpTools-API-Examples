require_relative '../request.rb'

# Example of POST /invoices/pay

# This request pays all invoices given by invoice ids

PAYMENT_METHOD_ID = ENV['PAYMENT_METHOD_ID']
INVOICE_ID        = ENV['INVOICE_ID']

params = {
  'payment_token': PAYMENT_METHOD_ID,
  'invoice_ids': [INVOICE_ID]
}.to_json

BaseRequestRoute.request(:post, '/invoices/pay', body: params)
