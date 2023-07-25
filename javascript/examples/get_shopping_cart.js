const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example GET /shopping-cart

const COMPANY_ID = process.env.COMPANY_ID

params = {
	company_ids: [COMPANY_ID]
}

token = baseRequest.request.token({ path: '/shopping-cart' });

baseRequest.request.get({ path: '/shopping-cart', token: token, queryParams: params });