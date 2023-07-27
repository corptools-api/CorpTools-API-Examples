const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example GET /websites

const WEBSITE_URL = process.env.WEBSITE_URL

params = {
  url: WEBSITE_URL
}

token = baseRequest.request.token({ path: '/websites' });

baseRequest.request.get({ path: '/websites', token: token, queryParams: params });
