const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example GET /order-items/requiring-attention

const COMPANY_ID = process.env.COMPANY_ID

params = {
  company_ids: [COMPANY_ID]
}

token = baseRequest.request.token({ path: '/order-items/requiring-attention' });

baseRequest.request.get({ path: '/order-items/requiring-attention', token: token, queryParams: params });