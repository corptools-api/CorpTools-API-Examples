const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /filing-products/offerings

const COMPANY_ID	= process.env.COMPANY_ID;
const JURISDICTION 	= process.env.JURISDICTION;

params = {
	company_id: COMPANY_ID,
  	jurisdiction: JURISDICTION
}

token = baseRequest.request.token({ path: '/filing-products/offerings' });

baseRequest.request.get({ path: '/filing-products/offerings', token: token, queryParams: params });