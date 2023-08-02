const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

//  Example of GET /compliance-events

//  Either a company or company_id may be provided, but not both
//  Either an array of jurisdictions or jurisdiction_ids may be provided, but not both
//  Start_date and end_date are required

const COMPANY_ID	= process.env.COMPANY_ID;
const START_DATE 	= process.env.START_DATE;
const END_DATE    = process.env.END_DATE;

params = {
  company_id: COMPANY_ID,
  start_date: START_DATE,
  end_date: END_DATE
}

token = baseRequest.request.token({ path: '/compliance-events' });

baseRequest.request.get({ path: '/compliance-events', token: token, queryParams: params });
