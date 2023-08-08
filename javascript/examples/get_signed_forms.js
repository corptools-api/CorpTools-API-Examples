const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /signed-forms

const FILING_METHOD_ID = process.env.FILING_METHOD_ID
const WEBSITE_ID = process.env.WEBSITE_ID

params = {
	filing_method_id: FILING_METHOD_ID,
	website_id: WEBSITE_ID
}

token = baseRequest.request.token({ path: '/signed-forms' });

baseRequest.request.get({ path: '/signed-forms', token: token, queryParams: params });