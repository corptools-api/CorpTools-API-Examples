const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example POST /services

const COMPANY_ID = process.env.COMPANY_ID
const COMPANY_NAME = process.env.COMPANY_NAME
const JURISDICTION_ID = process.env.JURISDICTION_ID

body = {
	company_id: COMPANY_ID,
	// company: COMPANY_NAME,
	jurisdiction_ids: [JURISDICTION_ID]
}

token = baseRequest.request.token({ path: '/services', body: body });

baseRequest.request.post({ path: '/services', token: token, body: body });