require_relative '../request.rb'

# Example of GET /resources/:resource_id/download
# The specified resource is saved as a pdf in the 'documents' directory

RESOURCE_ID = ENV['AGENCY_RESOURCE_ID']

BaseRequestRoute.request(:get, "/resources/#{RESOURCE_ID}/download")
