const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /filing-products

const WEBSITE_URL = process.env.WEBSITE_URL;
const JURISDICTION = process.env.JURISDICTION;

params = {
  url: WEBSITE_URL,
  jurisdiction: JURISDICTION
}

token = baseRequest.request.token({ path: '/filing-products' });

baseRequest.request.get({ path: '/filing-products', token: token, queryParams: params });