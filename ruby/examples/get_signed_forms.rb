require_relative '../request.rb'

# Example of GET /signed-forms

FILING_METHOD_ID = ENV['FILING_METHOD_ID']
WEBSITE_ID       = ENV['WEBSITE_ID']

params = {
	filing_method_id: FILING_METHOD_ID,
	website_id: WEBSITE_ID
}

BaseRequestRoute.request(:get, '/signed-forms', query_params: params)