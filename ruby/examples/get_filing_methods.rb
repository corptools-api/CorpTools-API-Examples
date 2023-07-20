require_relative '../request.rb'

# Lists filing methods for filing product if eligible for offering to company

COMPANY_ID        = ENV['COMPANY_ID']
FILING_PRODUCT_ID = ENV['FILING_PRODUCT_ID']
JURISDICTION      = ENV['JURISDICTION']

params = {
  company_id: COMPANY_ID,
  filing_product_id: FILING_PRODUCT_ID,
  jurisdiction: JURISDICTION
}

BaseRequestRoute.request(:get, '/filing-methods', query_params: params)