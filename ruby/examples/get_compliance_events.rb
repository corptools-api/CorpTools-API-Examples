require_relative '../request.rb'

# Example of GET /compliance-events

# Lists compliance events for specified company
# Either a company or company_id may be provided, but not both
# Either an array of jurisdictions or jurisdiction_ids may be provided, but not both
# Start_date and end_date are required

COMPANY_ID        = ENV['COMPANY_ID']
START_DATE        = ENV['START_DATE']
END_DATE          = ENV['END_DATE']

params = {
  company_id: COMPANY_ID,
  start_date: START_DATE,
  end_date: END_DATE
}

BaseRequestRoute.request(:get, '/compliance-events', query_params: params)
