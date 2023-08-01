const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /registered-agent-products

const WEBSITE_URL = process.env.WEBSITE_URL;

params = {
	url: WEBSITE_URL
}

token = baseRequest.request.token({ path: '/registered-agent-products' });

baseRequest.request.get({ path: '/registered-agent-products', token: token, queryParams: params });