const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example GET /services

const COMPANY_ID = process.env.COMPANY_ID
const COMPANY_NAME = process.env.COMPANY_NAME

params = {
	company_id: COMPANY_ID,
	// company: COMPANY_NAME
}

token = baseRequest.request.token({ path: '/services' });

baseRequest.request.get({ path: '/services', token: token, queryParams: params });